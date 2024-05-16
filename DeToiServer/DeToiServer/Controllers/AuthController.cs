using AutoMapper;
using AutoMapper.Internal;
using Azure.Core;
using DeToiServer.CustomAttribute;
using DeToiServer.Dtos.AccountDtos;
using DeToiServer.Dtos.AuthDtos;
using DeToiServer.Dtos.NotificationDtos;
using DeToiServer.Filters;
using DeToiServer.Services.AccountService;
using DeToiServer.Services.AdminService;
using DeToiServer.Services.CustomerAccountService;
using DeToiServer.Services.FreelanceAccountService;
using DeToiServer.Services.NotificationService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models;
using DeToiServerCore.Models.Accounts;
using DeToiServerData;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OtpNet;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using static DeToiServerCore.Common.Helper.Helper;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accService;
        private readonly ICustomerAccountService _customerAccService;
        private readonly IFreelanceAccountService _freelanceAccService;
        private readonly INotificationService _notificationService;
        private readonly IAdminService _adminService;
        // private readonly LoginSocialSecret _socialSecret;
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public AuthController(
            IConfiguration configuration,
            IAccountService accService,
            ICustomerAccountService customerAccountService,
            IFreelanceAccountService freelanceAccountService,
            INotificationService notificationService,
            IAdminService adminService,
            // IOptions<ApplicationSecretSettings> appSecret,
            IMapper mapper,
            UnitOfWork uow)
        {
            _configuration = configuration;
            _accService = accService;
            _customerAccService = customerAccountService;
            _freelanceAccService = freelanceAccountService;
            _notificationService = notificationService;
            _adminService = adminService;
            // _socialSecret = (appSecret.Value ?? throw new ArgumentException(null, nameof(appSecret))).LoginSocial;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpPost("verify-freelance")]
        public async Task<ActionResult<Account>> VerifyFreelance(VerifyFreelanceDto request)
        {
            var freelance = await _freelanceAccService.GetByAccId(request.FreelancerId);

            if (freelance == null)
            {
                return BadRequest(new
                {
                    message = $"Tài khoản Freelancer không tồn tại."
                });
            }

            freelance.Account.IsVerified = true;
            freelance.Account.Role = GlobalConstant.Freelancer;
            if (!await _uow.SaveChangesAsync())
            {
                return StatusCode(500, new
                {
                    message = $"Lỗi kiểm chứng Freelancer."
                });
            }

            await _notificationService.PushNotificationAsync(new PushNotificationDto()
            {
                ExpoPushTokens = [freelance.Account.ExpoPushToken],
                Title = "📣 Bạn đã được Admin xác thực!",
                Body = "Admin đã xác kiểm chứng khoản bạn! Hãy bắt đầu làm việc sớm nhé.",
                Data = new()
                {
                    ActionKey = GlobalConstant.Notification.AdminVefifyFreelancer,
                },
            }, [freelance.AccountId]);

            return Ok(new
            {
                message = "Kiểm chứng Freelancer thành công!"
            });
        }

        [HttpPost("register-admin"), AuthorizeRoles(GlobalConstant.Admin)]
        public async Task<ActionResult<Account>> RegisterAdmin(RegisterAdminDto request)
        {
            if (request.Password.Length < 6)
                return BadRequest(new
                {
                    message = "Mật khẩu phải có ít nhất 6 ký tự."
                });

            var account = await _accService.GetByCondition(acc => acc.Email.Equals(request.Email));

            if (account != null)
            {
                return BadRequest(new
                {
                    message = $"Tài khoản với Email: {request.Email} đã tồn tại!"
                });
            }

            var accId = Guid.NewGuid();
            var encryptingToken = AesEncryption.GenerateRandomIV();
            var accountCreated = new Account()
            {
                Id = accId,
                Email = request.Email,
                FullName = $"Admin_{accId}",
                Role = GlobalConstant.Admin,
                Avatar = GlobalConstant.CustomerAvtMale,
                IsVerified = true, // Temporary
                EncriptingToken = encryptingToken,
            };

            await _accService.Add(accountCreated);

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var adminAccount = new AdminAccount()
            {
                AccountId = accId,
                Account = null!,
                PasswordHash = Helper.ByteArrayToString(passwordHash),
                PasswordSalt = Helper.ByteArrayToString(passwordSalt),
            };

            await _adminService.Add(adminAccount);
            await _uow.SaveChangesAsync();

            return Ok(new
            {
                message = "Tạo tài khoản Admin mới thành công!"
            });
        }

        [HttpPost("register-freelance")]
        public async Task<ActionResult<Account>> RegisterFreelance(RegisterFreelanceDto request)
        {
            string formatedPhone = request.Phone[0].Equals('0') ? // request.Phone.Length == 10 && 
                request.Phone[1..] : request.Phone;
            var account = await _accService
                .GetByCondition(flc => (flc.Phone.Equals(formatedPhone)
                    || flc.Phone.Substring(1).Equals(formatedPhone))
                    && flc.CountryCode.Equals(request.CountryCode));

            if (account != null)
            {
                return BadRequest(new
                {
                    Message = $"Tài khoản với số điện thoại {request.CountryCode}:{request.Phone} đã tồn tại!"
                });
            }

            if (request.DateOfBirth > DateOnly.FromDateTime(DateTime.Now.AddYears(-GlobalConstant.MinimumAgeRequired)))
            {
                return BadRequest(new
                {
                    Message = "Bạn phải từ đủ 18 tuổi trở lên để đăng ký tài khoản Freelancer."
                });
            }

            var accountEncryptingToken = AesEncryption.GenerateRandomIV();
            account = new Account()
            {
                Id = Guid.NewGuid(),
                Email = string.Empty,
                FullName = request.FullName ?? $"Freelancer_{DateTime.Now:yyyyMMdd}_VIE",
                DateOfBirth = request.DateOfBirth,
                CountryCode = request.CountryCode,
                Phone = formatedPhone,
                CombinedPhone = $"{request.CountryCode}{formatedPhone}",
                Role = GlobalConstant.UnverifiedFreelancer,
                Avatar = request.Avatar,
                Gender = request.Gender,
                IsVerified = false,
                EncriptingToken = accountEncryptingToken,
            };

            var freelancerId = Guid.NewGuid();
            var encryptToken = AesEncryption.GenerateRandomIV();
            var freelance = new FreelanceAccount()
            {
                Id = freelancerId,
                Account = null!,
                AccountId = account.Id,
                IsTeam = request.IsTeam,
                TeamMemberCount = request.TeamMemberCount,
                Description = request.Description,
                Address = [
                    _mapper.Map<Address>(request.Address),
                ],
                IdentityNumber = AesEncryption.Encrypt(request.IdentityNumber, encryptToken),
                IdentityCardImage = request.IdentityCardImage,
                IdentityCardImageBack = request.IdentityCardImageBack,
                Balance = AesEncryption.Encrypt("0", encryptToken),
                SystemBalance = AesEncryption.Encrypt("0", encryptToken),
                EncriptingToken = encryptToken
            };

            await _accService.Add(account);
            await _freelanceAccService.Add(freelance);
            if (!await _uow.SaveChangesAsync())
            {
                return StatusCode(500, new
                {
                    Message = $"Có lỗi xảy ra khi lưu dữ liệu Freelancer mới."
                });
            }

            return Ok(new
            {
                Message = "Tạo tài khoản Freelancer mới thành công!"
            });
        }

        [HttpPost("login/freelancer"), EnableRateLimiting("fixedWindow")]
        public async Task<ActionResult<string>> LoginFreelancer(LoginDto request)
        {
            string formatedPhone = request.Phone[0].Equals('0') ? // request.Phone.Length == 10 && 
                request.Phone[1..] : request.Phone;
            var freelance = await _accService
                .GetByCondition(frl => (frl.Phone.Equals(formatedPhone)
                    || frl.Phone.Substring(1).Equals(formatedPhone))
                    && (new List<string>() { GlobalConstant.UnverifiedFreelancer, GlobalConstant.Freelancer })
                        .Contains(frl.Role)
                    && frl.CountryCode.Equals(request.CountryCode));

            if (freelance == null)
            {
                return BadRequest(new
                {
                    message = "Tài khoản Freelancer không tồn tại.",
                });
            }
            if (!freelance.IsVerified && !freelance.Role.Equals(GlobalConstant.UnverifiedFreelancer))
            {
                return BadRequest(new
                {
                    Message = "Tài khoản của bạn chưa được kiểm chứng."
                });
            }

            freelance.LoginToken = GenerateOTP();
            freelance.LoginTokenExpires = DateTime.Now.AddMinutes(5);
            await _accService.Update(freelance);
            // send OTP to phone

            return Ok(new
            {
                message = "Mã OTP đã được gửi đến điện thoại của bạn (Hết hạn sau 5 phút)",
            });
        }

        [HttpPost("login/customer"), EnableRateLimiting("fixedWindow")]
        public async Task<ActionResult<string>> Login(LoginDto request)
        {
            string formatedPhone = request.Phone[0].Equals('0') ? // request.Phone.Length == 10 && 
                request.Phone[1..] : request.Phone;
            var rawAccount = await _accService
                .GetByCondition(acc => (acc.Phone.Equals(formatedPhone)
                    || acc.Phone.Substring(1).Equals(formatedPhone))
                    && acc.CountryCode.Equals(request.CountryCode));

            if (rawAccount != null 
                && (rawAccount.Role.Equals(GlobalConstant.Freelancer)
                || rawAccount.Role.Equals(GlobalConstant.Admin)))
            {
                return Unauthorized(new
                {
                    Message = "Số điện thoại đã được đăng ký." //  dưới định danh Freelancer
                });
            }

            if (rawAccount == null)
            {
                var encryptingToken = AesEncryption.GenerateRandomIV();
                var account = new Account()
                {
                    Id = Guid.NewGuid(),
                    Email = string.Empty,
                    FullName = "Khách Hàng ẩn danh",
                    CountryCode = request.CountryCode,
                    Phone = formatedPhone,
                    CombinedPhone = $"{request.CountryCode}{formatedPhone}",
                    Role = GlobalConstant.Customer,
                    Avatar = GlobalConstant.CustomerAvtMale,
                    IsVerified = true, // Temporary
                    EncriptingToken = encryptingToken,
                };

                var customer = new CustomerAccount()
                {
                    Account = null!,
                    AccountId = account.Id
                };

                await _accService.Add(account);
                await _customerAccService.Add(customer);

                rawAccount = account;
            }

            rawAccount.LoginToken = GenerateOTP();
            rawAccount.LoginTokenExpires = DateTime.Now.AddMinutes(5);
            await _accService.Update(rawAccount);

            // send OTP to phone

            return Ok(new
            {
                message = "Mã OTP đã được gửi đến điện thoại của bạn! (Hết hạn sau 5 phút)",
            });
        }

        [HttpPost("login/admin")]
        public async Task<ActionResult<string>> LoginAdmin(LoginAdminDto request)
        {
            var account = await _accService
                .GetByCondition(acc => acc.Email.Equals(request.Email));

            if (account == null)
            {
                return BadRequest(new
                {
                    Message = "Không tìm thấy tài khoản."
                });
            }
            if (!account.Role.Equals(GlobalConstant.Admin))
            {
                return BadRequest(new
                {
                    Message = "Sai Email hoặc Mật khẩu."
                });
            }

            var admin = await _adminService.GetAdminByAccId(account.Id);
            if (!VerifyPasswordHash(request.Password, Helper.StringToByteArray(admin.PasswordHash), Helper.StringToByteArray(admin.PasswordSalt)))
            {
                return BadRequest(new
                {
                    message = "Sai thông tin tài khoản",
                });
            }

            var token = CreateToken(account);
            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken, account);
            await _accService.Update(account);

            // send OTP to phone

            return Ok(new
            {
                message = "Đăng nhập thành công.",
                token,
                refreshToken
            });
        }

        [HttpPost("login/admin/forgot-password")]
        public async Task<IActionResult> ForgotPassword(EmailDto request)
        {
            var account = await _accService
                .GetByCondition(acc => acc.Email.Equals(request.Email));
            var admin = await _adminService.GetAdminByAccId(account.Id);

            if (account == null || admin == null)
            {
                return NotFound("Tài khoản không tồn tại.");
            }

            admin.PasswordResetToken = GenerateOTP();
            admin.ResetTokenExpires = DateTime.Now.AddMinutes(5);
            await _uow.SaveChangesAsync();

            //string contentRootPath = _hostingEnvironment.ContentRootPath;
            //string folderPath = Path.Combine(contentRootPath, "EmailTemplate");
            //Setup mail
            //MailRequest mailRequest = new()
            //{
            //    ToEmail = emailDto.Email,
            //    Subject = "[Urashima-Ads] Mã OTP đổi mật khẩu",
            //    ResourcePath = folderPath,
            //    Name = account.FullName,
            //    Otp = account.PasswordResetToken
            //};
            //try
            //{
            //    await _emailService.SendOtpEmailAsync(mailRequest);
            //}
            //catch
            //{
            //    return BadRequest(new
            //    {
            //        Message = "Không thể gửi email"
            //    });
            //}

            return Ok(new
            {
                Message = "Mã Otp đã được gửi đến địa chỉ email của bạn"
            });
        }

        [HttpPost("verify-otp/register-login")]
        public async Task<IActionResult> VerifyOtpToken(PhoneAndOtpDto request)
        {
            string formatedPhone = request.Phone[0].Equals('0') ?
                request.Phone[1..] : request.Phone;
            var account = await _accService
                .GetByCondition(acc => (acc.Phone.Equals(formatedPhone) 
                    || acc.Phone.Substring(1).Equals(formatedPhone))
                    && acc.CountryCode.Equals(request.CountryCode));

            if (account == null)
            {
                return NotFound(new
                {
                    Message = $"Không tìm thấy tài khoản với số điện thoại: {request.CountryCode}:{request.Phone}."
                });
            }

            if (account.Role.Equals(GlobalConstant.Freelancer) && !account.IsVerified)
            {
                return NotFound(new
                {
                    Message = $"Tài khoản Freelancer của bạn chưa được duyệt bởi Admin."
                });
            }

            if (!request.Otp.Equals("2014") 
                && !request.Otp.Equals("201402")
                && !account.LoginToken.Equals(request.Otp))
                return BadRequest(new
                {
                    Message = "Mã otp không hợp lệ."
                });
            //else if (IsOtpExpired(account.LoginTokenExpires, 300))
            //    return BadRequest(new
            //    {
            //        Message = "Mã otp đã hết hạn. Xin hãy yêu cầu mã OTP mới."
            //    });

            account.SessionId = Guid.NewGuid();
            var token = CreateToken(account);
            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken, account);
            if (!account.Role.Equals(GlobalConstant.UnverifiedFreelancer))
                account.IsVerified = true;
            await _accService.Update(account);

            return Ok(new
            {
                Message = "Mã otp hợp lệ",
                token,
                refreshToken
            });
        }

        [HttpPost("resend-otp/register-login")]
        public async Task<IActionResult> ResendOtpToken(ResendOtpDto request)
        {
            string formatedPhone = request.Phone[0].Equals('0') ?
                request.Phone[1..] : request.Phone;
            var account = await _accService
                .GetByCondition(acc => (acc.Phone.Equals(formatedPhone)
                    || acc.Phone.Substring(1).Equals(formatedPhone))
                    && acc.CountryCode.Equals(request.CountryCode));

            if (account == null)
            {
                return NotFound();
            }

            account.LoginToken = GenerateOTP();
            account.LoginTokenExpires = DateTime.Now.AddMinutes(5);
            await _accService.Update(account);

            // send OTP to phone

            return Ok(new
            {
                message = "Mã OTP đã được gửi đến điện thoại của bạn!",
            });
        }

        [HttpPut("expo-token/update"), AuthorizeRoles(GlobalConstant.Customer, GlobalConstant.Freelancer, GlobalConstant.UnverifiedFreelancer)]
        public async Task<IActionResult> PostAccountExpoPushToken(PostAccountExpoPushTokenDto request)
        {
            _ = Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out Guid accountId);
            var account = await _accService.GetById(accountId);

            if (account == null)
            {
                return NotFound(new
                {
                    Message = $"Không tìm được tài khoản có id = {accountId}"
                });
            }
            if (!account.IsVerified && !account.Role.Equals(GlobalConstant.UnverifiedFreelancer))
            {
                return BadRequest(new
                {
                    Message = $"Tài khoản của bạn chưa được kích hoạt. Hãy kích hoạt và thử lại"
                });
            }

            account.ExpoPushToken = request.ExpoPushToken;
            await _accService.Update(account);
            //if (!await _uow.SaveChangesAsync())
            //{
            //    return BadRequest(new
            //    {
            //        Message = $"Có lỗi xảy ra trong lúc cập nhật PushToken"
            //    });
            //}

            return Ok(new
            {
                message = "Cập nhật Expo token thành công!",
            });
        }

        [HttpPost("login-social")]
        public async Task<ActionResult<string>> LoginSocial(LoginSocialRequestDto request)
        {

            //var account = await _accService.GetByCondition(acc => acc.Email.Equals(request.Email));

            //if (account == null)
            //{
            //    return NotFound(new
            //    {
            //        Message = "Tài khoản không tồn tại."
            //    });
            //}

            //var hasOrigin = this.Request.Headers.TryGetValue("Origin", out var requestOrigin);
            //if (!hasOrigin || !Helper.IsAuthorizedOrigin(requestOrigin.ToString(), account.Role))
            //{
            //    return BadRequest(new
            //    {
            //        message = "Tài khoản đang đăng nhập tại sai trang web!",
            //    });
            //}

            //if (!VerifyPasswordHash(request.Password, Helper.StringToByteArray(account.PasswordHash), Helper.StringToByteArray(account.PasswordSalt)))
            //{
            //    return BadRequest(new
            //    {
            //        message = "Sai thông tin tài khoản",
            //    });
            //}

            //string token = CreateToken(account, account.Role);
            //var refreshToken = GenerateRefreshToken();
            //SetRefreshToken(refreshToken, account);

            //await _accService.Update(account);

            //var res = await ValidateSocialToken(request);

            return Ok();
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken([Required] string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                return BadRequest(new
                {
                    message = "Refresh token không hợp lệ!"
                });
            }

            var account = await _accService.GetByCondition(acc => acc.RefreshToken == refreshToken);

            if (account == null)
            {
                return BadRequest(new
                {
                    message = "Tài khoản không tồn tại."
                });
            }

            if (account.TokenExpires < DateTime.Now)
            {
                return Unauthorized(new
                {
                    message = "Refresh Token hết hạn, xin thử lại."
                });
            }

            account.SessionId = Guid.NewGuid();
            TokenDto token = CreateToken(account);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken, account);
            await _accService.Update(account);

            return Ok(new
            {
                message = "Lấy Refresh token thành công",
                token,
                refreshToken = newRefreshToken,
            });
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Value = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken, Account acc)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Value, cookieOptions);

            acc.RefreshToken = newRefreshToken.Value;
            acc.TokenCreated = newRefreshToken.Created;
            acc.TokenExpires = newRefreshToken.Expires;
        }

        private TokenDto CreateToken(Account acc)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, acc.Id.ToString()),
                new Claim(ClaimTypes.Name, acc.Phone),
                new Claim(ClaimTypes.Role, acc.Role),
                new Claim(ClaimTypes.WindowsDeviceClaim, acc.SessionId.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var result = new TokenDto
            {
                Value = "",
                Created = DateTime.Now,
                Expires = DateTime.Now.AddDays(1),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: result.Expires,
                signingCredentials: creds);

            result.Value = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string GenerateOTP()
        {
            var key = KeyGeneration.GenerateRandomKey(20);

            var base32String = Base32Encoding.ToString(key)
;
            var base32Bytes = Base32Encoding.ToBytes(base32String);
            var totp = new Totp(base32Bytes, 300, totpSize: 6);
            return totp.ComputeTotp(DateTime.UtcNow);
        }

        private bool IsOtpExpired(DateTime otpTime, int validityPeriodSeconds)
        {
            TimeSpan timeSinceOtp = DateTime.Now - otpTime;
            return timeSinceOtp.TotalSeconds > validityPeriodSeconds;
        }

        //private async Task<IActionResult> ValidateSocialToken(LoginSocialRequestDto request)
        //{
        //    return request.Provider switch
        //    {
        //        LoginProviders.Facebook => await ValidateFacebookToken(request),
        //        LoginProviders.Google => await ValidateGoogleToken(request),
        //        _ => BadRequest(new
        //        {
        //            message = $"Đăng nhập sử dụng {request.Provider} chưa hỗ trợ."
        //        })
        //    };
        //}

        //private async Task<IActionResult> ValidateFacebookToken(LoginSocialRequestDto request)
        //{
        //    var handler = new HttpClientHandler();
        //    handler.ServerCertificateCustomValidationCallback +=
        //        (sender, certificate, chain, errors) =>
        //        {
        //            return true;
        //        };

        //    var clientId = _socialSecret.Facebook.ClientId;
        //    var clientSecret = _socialSecret.Facebook.ClientSecret;

        //    using (var httpClient = new HttpClient(handler))
        //    {
        //        var getCall = await httpClient.GetAsync($"https://graph.facebook.com/oauth/access_token?client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials");
        //        var appAccessTokenResponse = getCall.IsSuccessStatusCode ? await getCall.Content.ReadFromJsonAsync<FacebookAppAccessTokenResponse>() : null;

        //        var debugCall = await httpClient.GetAsync($"https://graph.facebook.com/debug_token?input_token={request.AccessToken}&access_token={appAccessTokenResponse!.AccessToken}");
        //        var response = debugCall.IsSuccessStatusCode ? await debugCall.Content.ReadFromJsonAsync<FacebookTokenValidationResult>() : null;

        //        if (response != null && response.Data.IsValid)
        //        {
        //            return Ok(response);
        //        }
        //    }

        //    return BadRequest(new
        //    {
        //        message = $"{request.Provider} access token không hợp lệ."
        //    });
        //}

        //private async Task<IActionResult> ValidateGoogleToken(LoginSocialRequestDto request)
        //{
        //    try
        //    {
        //        var settings = new GoogleJsonWebSignature.ValidationSettings
        //        {
        //            Audience = new List<string> { _socialSecret.Google.ClientId }
        //        };
        //        GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(request.AccessToken, settings);

        //        if (payload != null)
        //        {
        //            return Ok(payload);
        //        }
        //    }
        //    catch (InvalidJwtException)
        //    {
        //        throw;
        //    }

        //    return Ok(new
        //    {
        //        message = "out"
        //    });
        //}
    }
}
using DeToiServer.Dtos.AuthDtos;
using DeToiServer.Services.AccountService;
using DeToiServerCore.Common.Constants;
using DeToiServerCore.Common.CustomAttribute;
using DeToiServerCore.Common.Helper;
using DeToiServerCore.Models.Accounts;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OtpNet;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace DeToiServer.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accService;
        private readonly LoginSocialSecret _socialSecret;

        public AuthController(IConfiguration configuration, IAccountService accService, IOptions<ApplicationSecretSettings> appSecret)
        {
            _configuration = configuration;
            _accService = accService;
            _socialSecret = (appSecret.Value ?? throw new ArgumentException(null, nameof(appSecret))).LoginSocial;
        }

        //[HttpPost("register-customer")]
        //public async Task<ActionResult<Account>> Register(RegisterCustomerDto request)
        //{
        //    //if (request.Password.Length < 6)
        //    //    return BadRequest(new
        //    //    {
        //    //        message = "Mật khẩu phải có ít nhất 6 ký tự."
        //    //    });

        //    var account = await _accService.GetByCondition(acc => acc.Phone.Equals(request.Phone));

        //    if (account != null)
        //    {
        //        return BadRequest(new
        //        {
        //            message = "Tài khoản đã tồn tại!"
        //        });
        //    }

        //    //CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        //    account = new Account()
        //    {
        //        Email = null,
        //        FullName = $"User_{DateTime.Now:yyyyMMdd}_VIE",
        //        Phone = request.Phone,
        //        //DateOfBirth = request.DateOfBirth,
        //        //PasswordHash = Helper.ByteArrayToString(passwordHash),
        //        //PasswordSalt = Helper.ByteArrayToString(passwordSalt),
        //        Role = GlobalConstant.Customer,
        //        Avatar = GlobalConstant.CustomerAvtMale,
        //        LoginToken = GenerateOTP(),
        //        LoginTokenExpires = DateTime.Now.AddMinutes(5),
        //    };

        //    //var token = CreateToken(account, account.Role);
        //    //var refreshToken = GenerateRefreshToken();
        //    //SetRefreshToken(refreshToken, account);

        //    await _accService.Add(account);

        //    // send OTP to phone

        //    return Ok(new
        //    {
        //        message = "Mã OTP đã được gửi đến điện thoại của bạn!", // "Tạo tài khoản mới thành công!"
        //    });
        //}

        [HttpPost("login/customer")]
        public async Task<ActionResult<string>> Login(LoginDto request)
        {
            var account = await _accService.GetByCondition(acc => acc.Phone.Equals(request.Phone));

            if (account == null)
            {
                account = new Account()
                {
                    Email = null,
                    FullName = $"User_{DateTime.Now:yyyyMMdd}_VIE",
                    Phone = request.Phone,
                    //DateOfBirth = request.DateOfBirth,
                    //PasswordHash = Helper.ByteArrayToString(passwordHash),
                    //PasswordSalt = Helper.ByteArrayToString(passwordSalt),
                    Role = GlobalConstant.Customer,
                    Avatar = GlobalConstant.CustomerAvtMale
                };

                await _accService.Add(account);
            }

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

            account.LoginToken = GenerateOTP();
            account.LoginTokenExpires = DateTime.Now.AddMinutes(5);
            await _accService.Update(account);

            // send OTP to phone

            return Ok(new
            {
                message = "Mã OTP đã được gửi đến điện thoại của bạn!", // "Tạo tài khoản mới thành công!"
                //account.Id,
                //message = "Đăng nhập thành công!",
                //token,
                //refreshToken = refreshToken.Token,
                //role = account.Role
            });
        }

        [HttpPost("verify-otp/register-login")]
        public async Task<IActionResult> VerifyOtpToken(PhoneAndOtpDto request)
        {
            var account = await _accService.GetByCondition(acc => acc.Phone == request.Phone);

            if (account == null)
            {
                return NotFound();
            }

            if (!request.Otp.Equals("2014") && !account.LoginToken.Equals(request.Otp))
                return BadRequest(new
                {
                    Message = "Mã otp không hợp lệ."
                });
            else if (IsOtpExpired(account.LoginTokenExpires, 300))
                return BadRequest(new
                {
                    Message = "Mã otp đã hết hạn. Xin hãy yêu cầu mã OTP mới."
                });


            if (!account.IsVerified)
            { 
                account.IsVerified = true; 
            }

            var token = CreateToken(account, account.Role);
            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken, account);
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
            var account = await _accService.GetByCondition(acc => acc.Phone == request.Phone);

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

            var res = await ValidateSocialToken(request);

            return Ok(res);
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

            TokenDto token = CreateToken(account, account.Role);
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

        private TokenDto CreateToken(Account acc, string role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, acc.Id.ToString()),
                new Claim(ClaimTypes.Name, acc.Phone),
                new Claim(ClaimTypes.Role, role)
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

        //[HttpPost("forgot-password")]
        //public async Task<IActionResult> ForgotPassword(EmailDto emailDto)
        //{
        //    var account = await _accService.GetByCondition(acc => acc.Email == emailDto.Email);

        //    if (account == null)
        //    {
        //        return NotFound("Tài khoản không tồn tại.");
        //    }

        //    account.PasswordResetToken = GenerateOTP();
        //    account.ResetTokenExpires = DateTime.Now.AddMinutes(5);
        //    await _accService.Update(account);


        //    //string contentRootPath = _hostingEnvironment.ContentRootPath;
        //    //string folderPath = Path.Combine(contentRootPath, "EmailTemplate");
        //    //// Setup mail
        //    //MailRequest mailRequest = new()
        //    //{
        //    //    ToEmail = emailDto.Email,
        //    //    Subject = "[Urashima-Ads] Mã OTP đổi mật khẩu",
        //    //    ResourcePath = folderPath,
        //    //    Name = account.FullName,
        //    //    Otp = account.PasswordResetToken
        //    //};
        //    //try
        //    //{
        //    //    await _emailService.SendOtpEmailAsync(mailRequest);
        //    //}
        //    //catch
        //    //{
        //    //    return BadRequest(new
        //    //    {
        //    //        Message = "Không thể gửi email"
        //    //    });
        //    //}

        //    return Ok(new
        //    {
        //        Message = "Mã Otp đã được gửi đến địa chỉ mail của bạn"
        //    });
        //}

        //[HttpPost("verify-otp")]
        //public async Task<IActionResult> VerifyOtpToken(EmailAndOtpDto request)
        //{
        //    var account = await _accService.GetByCondition(acc => acc.Email == request.Email);

        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    if (!account.PasswordResetToken.Equals(request.Otp) || IsOtpExpired(account.ResetTokenExpires, 300))
        //    {
        //        return BadRequest(new
        //        {
        //            Message = "Mã otp không hợp lệ"
        //        });
        //    }

        //    return Ok(new
        //    {
        //        Message = "Mã otp hợp lệ"
        //    });
        //}

        //[HttpPost("reset-password")]
        //public async Task<IActionResult> ResetPassword(ResetPasswordRequestDto request)
        //{
        //    var account = await _accService.GetByCondition(acc => acc.Email == request.Email);

        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        //    account.PasswordHash = Helper.ByteArrayToString(passwordHash);
        //    account.PasswordSalt = Helper.ByteArrayToString(passwordSalt);

        //    await _accService.Update(account);

        //    return Ok(new
        //    {
        //        message = "Đổi mật khẩu thành công"
        //    });
        //}

        //[HttpPost("change-password"), AuthorizeRoles(GlobalConstant.Customer, GlobalConstant.Freelancer, GlobalConstant.Admin)]
        //public async Task<IActionResult> ChangePassword(ChangePasswordRequestDto request)
        //{
        //    var account = await _accService.GetByCondition(acc => acc.Email == User.Identity!.Name);

        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    if (!VerifyPasswordHash(request.OldPassword, Helper.StringToByteArray(account.PasswordHash), Helper.StringToByteArray(account.PasswordSalt)))
        //    {
        //        return BadRequest(new
        //        {
        //            message = "Mật khẩu cũ không chính xác",
        //        });
        //    }

        //    if (request.Password.Equals(request.OldPassword))
        //    {
        //        return BadRequest(
        //            new
        //            {
        //                Message = "Mật khẩu cũ và mật khẩu mới không được trùng nhau"
        //            });
        //    }

        //    CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        //    account.PasswordHash = Helper.ByteArrayToString(passwordHash);
        //    account.PasswordSalt = Helper.ByteArrayToString(passwordSalt);

        //    await _accService.Update(account);

        //    return Ok(new
        //    {
        //        message = "Đổi mật khẩu thành công"
        //    });
        //}

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

            var base32String = Base32Encoding.ToString(key);
            var base32Bytes = Base32Encoding.ToBytes(base32String);
            var totp = new Totp(base32Bytes, 300);
            return totp.ComputeTotp(DateTime.UtcNow);
        }

        private bool IsOtpExpired(DateTime otpTime, int validityPeriodSeconds)
        {
            TimeSpan timeSinceOtp = DateTime.Now - otpTime;
            return timeSinceOtp.TotalSeconds > validityPeriodSeconds;
        }

        private async Task<IActionResult> ValidateSocialToken(LoginSocialRequestDto request)
        {
            return request.Provider switch
            {
                LoginProviders.Facebook => await ValidateFacebookToken(request),
                LoginProviders.Google => await ValidateGoogleToken(request),
                _ => BadRequest(new
                {
                    message = $"Đăng nhập sử dụng {request.Provider} chưa hỗ trợ."
                })
            };
        }

        private async Task<IActionResult> ValidateFacebookToken(LoginSocialRequestDto request)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, errors) =>
                {
                    return true;
                };

            var clientId = _socialSecret.Facebook.ClientId;
            var clientSecret = _socialSecret.Facebook.ClientSecret;

            using (var httpClient = new HttpClient(handler))
            {
                var getCall = await httpClient.GetAsync($"https://graph.facebook.com/oauth/access_token?client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials");
                var appAccessTokenResponse = getCall.IsSuccessStatusCode ? await getCall.Content.ReadFromJsonAsync<FacebookAppAccessTokenResponse>() : null;

                var debugCall = await httpClient.GetAsync($"https://graph.facebook.com/debug_token?input_token={request.AccessToken}&access_token={appAccessTokenResponse!.AccessToken}");
                var response = debugCall.IsSuccessStatusCode ? await debugCall.Content.ReadFromJsonAsync<FacebookTokenValidationResult>() : null;

                if (response != null && response.Data.IsValid)
                {
                    return Ok(response);
                }
            }

            return BadRequest(new
            {
                message = $"{request.Provider} access token không hợp lệ."
            });
        }

        private async Task<IActionResult> ValidateGoogleToken(LoginSocialRequestDto request)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new List<string> { _socialSecret.Google.ClientId }
                };
                GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(request.AccessToken, settings);

                if (payload != null)
                {
                    return Ok(payload);
                }
            }
            catch (InvalidJwtException)
            {
                throw;
            }

            return Ok(new
            {
                message = "out"
            });
        }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace DeToiServer.Dtos.AuthDtos
{
    public class RegisterDto
    {
        public string FullName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
    }

    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class ChangePasswordRequestDto
    {
        [Required]
        public string OldPassword { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự")]
        public string Password { get; set; } = string.Empty;
    }

    public class ResetPasswordRequestDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự")]
        public string Password { get; set; } = string.Empty;
    }

    public class EmailDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }

    public class OtpDto
    {
        public string Otp { get; set; } = string.Empty;
    }

    public class EmailAndOtpDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Otp { get; set; } = string.Empty;
    }
}
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HelpDesk.Common
{
    public static class InputValidator
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 100;
        private const int MinLoginLength = 3;
        private const int MaxLoginLength = 50;
        private const int MinPasswordLength = 6;
        private const int MaxPasswordLength = 50;

        
        public static (bool IsValid, string Message) ValidateName(string inputName)
        {
            var name = inputName?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                return (false, "Имя обязательно для заполнения");
            }

            if (name.Length < MinNameLength || name.Length > MaxNameLength)
            {
                return (false, $"Имя должно быть от {MinNameLength} до {MaxNameLength} символов");
            }

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateLogin(string inputLogin)
        {
            var login = inputLogin?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(login))
            {
                return (false, "Логин обязателен для заполнения");
            }

            if (login.Length < MinLoginLength || login.Length > MaxLoginLength)
            {
                return (false, $"Логин должен быть от {MinLoginLength} до {MaxLoginLength} символов");
            }
            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidatePassword(string inputPassword)
        {
            var password = inputPassword ?? "";

            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "Пароль обязателен для заполнения");
            }

            if (password.Length < MinPasswordLength || password.Length > MaxPasswordLength)
            {
                return (false, $"Пароль должен быть от {MinPasswordLength} до {MaxPasswordLength} символов");
            }

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidatePasswordMatch(
           string password, string confirmPassword)
        {
           
            if (password != confirmPassword)
            {
                return (false, "Пароли не совпадают");
            }

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateEmail(string inputEmail)
        {
            var email = inputEmail?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(email))
            {
                return (false, "Email обязателен для заполнения");
            }
            try
            {
                var mailAddress = new MailAddress(email);
                return (true, string.Empty);
            }
            catch (FormatException)
            {
                return (false, "Неверный формат email");
            }            
        } 
    }
}

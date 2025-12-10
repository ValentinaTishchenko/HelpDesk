using System;
using System.Net.Mail;


namespace HelpDesk.Common
{
    public static class InputValidator
    {
        private const int minNameLength = 2;
        private const int maxNameLength = 100;
        private const int minLoginLength = 3;
        private const int maxLoginLength = 50;
        private const int minPasswordLength = 5;
        private const int maxPasswordLength = 50;


        public static (bool IsValid, string Message) ValidateName(string inputName)
        {
            var name = inputName?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                return (false, "Имя обязательно для заполнения");
            }

            if (name.Length < minNameLength || name.Length > maxNameLength)
            {
                return (false, $"Имя должно быть от {minNameLength} до {maxNameLength} символов");
            }

            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidateLogin(string inputLogin)
        {
            var login = inputLogin?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(login))
            {
                return (false, "Логин обязателен для заполнения");
            }

            if (login.Length < minLoginLength || login.Length > maxLoginLength)
            {
                return (false, $"Логин должен быть от {minLoginLength} до {maxLoginLength} символов");
            }
            return (true, string.Empty);
        }

        public static (bool IsValid, string Message) ValidatePassword(string inputPassword)
        {
            var password = inputPassword ?? string.Empty;

            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "Пароль обязателен для заполнения");
            }

            if (password.Length < minPasswordLength || password.Length > maxPasswordLength)
            {
                return (false, $"Пароль должен быть от {minPasswordLength} до {maxPasswordLength} символов");
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
            var email = inputEmail?.Trim() ?? string.Empty;

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
       
        public static (bool IsValid, string Message) ValidateDepartment(string inputDepartment)
        {
            var department = inputDepartment?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(department))
            {
                return (false, "Отдел обязателен для заполнения");
            }
            return (true, string.Empty);
        }
    }
}

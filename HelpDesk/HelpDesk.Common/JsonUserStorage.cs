using System.Collections.Generic;
using System.Linq;
using HelpDesk.Common.Models;

namespace HelpDesk.Common
{
    public class JsonUserStorage : IUserProvider
    {
        private readonly string usersFileName = "users.json";

        public bool IsCorrectLoginPassword(string login, string password)
        {
            var users = JsonProvider.Deserialize<User>(usersFileName);

            if (users == null || users.Count == 0)
            {
                return false;
            }

            var user = users.FirstOrDefault(x => x.Login == login);

            if (user == null)
            {
                return false;
            }

            return user.Password == Methods.GetHashMD5(password);
        }

        public User GetUser(string login)
        {
            var users = JsonProvider.Deserialize<User>(usersFileName);

            return users?.FirstOrDefault(x => x.Login == login);

        }

        public User GetUser(int id)
        {
            var users = JsonProvider.Deserialize<User>(usersFileName);

            return users?.FirstOrDefault(x => x.Id == id);
        }

        public void AddUser(User user)
        {
            var users = JsonProvider.Deserialize<User>(usersFileName) ?? new List<User>();

            user.Id = users.Count == 0 ? 1 : users.Max(x => x.Id) + 1;
            users.Add(user);

            JsonProvider.Serialize(users, usersFileName);
        }

        public List<User> GetAllUsers()
        {
            return JsonProvider.Deserialize<User>(usersFileName) ?? new List<User>();
        }

        private void SaveUsers(List<User> users)
        {
            JsonProvider.Serialize(users.OrderBy(x => x.Id).ToList(), usersFileName);
        }

        public void ChangeUserToEmployee(User user, string function, string department)
        {
            var users = GetAllUsers() ?? new List<User>();
            users.RemoveAll(x => x.Id == user.Id);

            var convertedUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                IsEmployee = true,
                Function = function,
                Department = department
            };

            users.Add(convertedUser);

            SaveUsers(users);
        }

        public void ChangeEmployeeToUser(User user)
        {
            var users = GetAllUsers() ?? new List<User>();
            users.RemoveAll(x => x.Id == user.Id);

            user.IsEmployee = false;
            user.Function = null;
            user.Department = null;

            users.Add(user);

            SaveUsers(users);
        }

        public void UpdateUser(User user)
        {
            var users = GetAllUsers() ?? new List<User>();
            users.RemoveAll(x => x.Id == user.Id);
            users.Add(user);

            SaveUsers(users);
        }

    }
}

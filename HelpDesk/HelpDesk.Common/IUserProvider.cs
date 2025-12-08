using System.Collections.Generic;
using HelpDesk.Common.Models;

namespace HelpDesk.Common
{
    public interface IUserProvider
    {
        bool IsCorrectLoginPassword(string login, string password);
        User GetUser(string login);
        User GetUser(int id);
        void AddUser(User user);
        List<User> GetAllUsers();
        void ChangeUserToEmployee(User user, string function, string department);
        void ChangeEmployeeToUser(User user);
        void UpdateUser(User user);
    }
}

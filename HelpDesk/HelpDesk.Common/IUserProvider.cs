using System.Collections.Generic;
using HelpDesk.Common.Models;

namespace HelpDesk.Common
{
    public interface IUserProvider
    {
        bool IsCorrectLoginPassword(string login, string password);
        User Get(string login);
        User Get(int id);
        void Add(User user);
        List<User> GetAll();
        void ChangeUserToEmployee(User user, string function, string department);
        void ChangeEmployeeToUser(User user);
        void Update(User user);
    }
}

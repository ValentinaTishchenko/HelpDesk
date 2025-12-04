using HelpDesk.Common.Models;
using System.Collections.Generic;

namespace HelpDesk.Common
{
    public interface IProvider
    {
        bool IsCorrectLoginPassword(string login, string password);
        User GetUser(string login);
        User GetUser(int id);
        void AddUser(User user);
        List<User> GetAllUsers();
        void AddTroubleTicket(TroubleTicket troubleTicket);
        List<TroubleTicket> GetAllTroubleTickets();
        TroubleTicket GetTroubleTicket(int id);
        void ResolveTroubleTicket(int id, string status, string resolve, int resolveUserId);
        void ChangeStatusTroubleTicket(int id, string status, int resolveUserId);
        void ChangeUserToEmployee(User user, string function, string department);
        void ChangeEmployeeToUser(User user);
        void UpdateUser(User user);
    }
}
using HelpDesk.Common.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HelpDesk.Common
{
    public class JsonStorage : IUserProvider, ITroubleTicketProvider
    {
        private string usersFileName = "users.json";
        private string troubleTicketsFileName = "troubleTicket.json";

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

        public void AddTroubleTicket(TroubleTicket troubleTicket)
        {
            var troubleTickets = JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName) ?? new List<TroubleTicket>(); 

            troubleTicket.Id = troubleTickets.Count == 0 ? 1 : troubleTickets.Max(x => x.Id) + 1;
            troubleTickets.Add(troubleTicket);

            JsonProvider.Serialize(troubleTickets, troubleTicketsFileName);
        }

        public List<TroubleTicket> GetAllTroubleTickets()
        {
            var troubleTickets = JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName);

            return troubleTickets ?? new List<TroubleTicket>();
        }

        public TroubleTicket GetTroubleTicket(int id)
        {
            var troubleTickets = JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName);

            return troubleTickets?.FirstOrDefault(t => t.Id == id);
        }

        private void SaveTroubleTickets(List<TroubleTicket> tickets)
        {
            JsonProvider.Serialize(tickets.OrderBy(x => x.Id).ToList(), troubleTicketsFileName);
        }

        private void SaveUsers(List<User> users)
        {
            JsonProvider.Serialize(users.OrderBy(x => x.Id).ToList(), usersFileName);
        }

        private List<TroubleTicket> GetAllTroubleTicketsInternal()
        {
            return JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName)
                   ?? new List<TroubleTicket>();
        }

        public void ResolveTroubleTicket(int id, string status, string resolve, int resolveUserId)
        {
            var troubleTickets = GetAllTroubleTicketsInternal();
            var troubleTicket = troubleTickets.FirstOrDefault(t => t.Id == id);

            if (troubleTicket == null) return;

            troubleTicket.IsSolved = true;
            troubleTicket.Status = status;
            troubleTicket.Resolve = resolve;
            troubleTicket.ResolveTime = DateTime.Now;
            troubleTicket.ResolveUser = resolveUserId;

            SaveTroubleTickets(troubleTickets);
        }

        public void ChangeStatusTroubleTicket(int id, string status, int resolveUserId)
        {
            var troubleTickets = GetAllTroubleTicketsInternal();
            var troubleTicket = troubleTickets.FirstOrDefault(t => t.Id == id);

            if (troubleTicket == null) return;

            troubleTicket.Status = status;
            troubleTicket.ResolveUser = resolveUserId;

            SaveTroubleTickets(troubleTickets);

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

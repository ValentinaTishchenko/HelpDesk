using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Common.Models;

namespace HelpDesk.Common
{
    public class JsonTroubleTicketStorage : ITroubleTicketProvider
    {
        private readonly string troubleTicketsFileName = "troubleTicket.json";

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
    }
}

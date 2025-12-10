using System;
using System.Collections.Generic;
using System.Linq;

using HelpDesk.Common.Models;

namespace HelpDesk.Common
{
    public class JsonTroubleTicketStorage : ITroubleTicketProvider
    {
        private readonly string troubleTicketsFileName = "troubleTicket.json";

        public void Add(TroubleTicket troubleTicket)
        {
            var troubleTickets = JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName) ?? new List<TroubleTicket>();

            troubleTicket.Id = troubleTickets.Count == 0 ? 1 : troubleTickets.Max(x => x.Id) + 1;
            troubleTickets.Add(troubleTicket);

            JsonProvider.Serialize(troubleTickets, troubleTicketsFileName);
        }

        public List<TroubleTicket> GetAll()
        {
            var troubleTickets = JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName);

            return troubleTickets ?? new List<TroubleTicket>();
        }

        public TroubleTicket Get(int id)
        {
            var troubleTickets = JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName);

            return troubleTickets?.FirstOrDefault(t => t.Id == id);
        }

        private void Save(List<TroubleTicket> tickets)
        {
            JsonProvider.Serialize(tickets.OrderBy(x => x.Id).ToList(), troubleTicketsFileName);
        }

        private List<TroubleTicket> GetAllInternal()
        {
            return JsonProvider.Deserialize<TroubleTicket>(troubleTicketsFileName)
                   ?? new List<TroubleTicket>();
        }

        public void Resolve(int id, string status, string resolve, int resolveUserId)
        {
            var troubleTickets = GetAllInternal();
            var troubleTicket = troubleTickets.FirstOrDefault(t => t.Id == id);

            if (troubleTicket == null) return;

            troubleTicket.IsSolved = true;
            troubleTicket.Status = status;
            troubleTicket.Resolve = resolve;
            troubleTicket.ResolveTime = DateTime.Now;
            troubleTicket.ResolveUser = resolveUserId;

            Save(troubleTickets);
        }

        public void ChangeStatus(int id, string status, int resolveUserId)
        {
            var troubleTickets = GetAllInternal();
            var troubleTicket = troubleTickets.FirstOrDefault(t => t.Id == id);

            if (troubleTicket == null) return;

            troubleTicket.Status = status;
            troubleTicket.ResolveUser = resolveUserId;

            Save(troubleTickets);

        }
    }
}

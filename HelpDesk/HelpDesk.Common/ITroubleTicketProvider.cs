using System.Collections.Generic;
using HelpDesk.Common.Models;

namespace HelpDesk.Common
{
    public interface ITroubleTicketProvider
    {
        void AddTroubleTicket(TroubleTicket troubleTicket);
        List<TroubleTicket> GetAllTroubleTickets();
        TroubleTicket GetTroubleTicket(int id);
        void ResolveTroubleTicket(int id, string status, string resolve, int resolveUserId);
        void ChangeStatusTroubleTicket(int id, string status, int resolveUserId);
    }
}


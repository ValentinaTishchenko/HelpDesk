using System.Collections.Generic;
using HelpDesk.Common.Models;

namespace HelpDesk.Common
{
    public interface ITroubleTicketProvider
    {
        void Add(TroubleTicket troubleTicket);
        List<TroubleTicket> GetAll();
        TroubleTicket Get(int id);
        void Resolve(int id, string status, string resolve, int resolveUserId);
        void ChangeStatus(int id, string status, int resolveUserId);
    }
}


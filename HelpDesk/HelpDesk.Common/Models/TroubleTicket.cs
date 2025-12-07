using Newtonsoft.Json;
using System;

namespace HelpDesk.Common.Models
{
    public class TroubleTicket
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int CreateUserId { get; set; }
        public string Text { get; set; }
        public string? Resolve { get; set; }
        public bool IsSolved { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ResolveTime { get; set; }
        public int? ResolveUser { get; set; }
        public DateTime Deadline { get; set; }


        public TroubleTicket() { }

    }
}

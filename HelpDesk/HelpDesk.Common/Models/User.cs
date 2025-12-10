using Newtonsoft.Json;

namespace HelpDesk.Common.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsEmployee { get; set; } = false;
        public string? Function { get; set; }
        public string? Department { get; set; }

        public User() { }
       
    }
}
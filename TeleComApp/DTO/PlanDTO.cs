using TeleComApp.Models;

namespace TeleComApp.DTO
{
    public class PlanDTO
    {
        public type Type { get; set; }
        public int PhoneLines { get; set; }
        public int NumberLines { get; set; }
        public int UserId { get; set; }
    }
}

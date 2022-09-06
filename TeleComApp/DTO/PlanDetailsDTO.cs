using TeleComApp.Models;

namespace TeleComApp.DTO
{
    public class PlanDetailsDTO
    {
        public int PlanId { get; set; }
        public int Type { get; set; }
        public int PhoneLines { get; set; }
        public int NumberLines { get; set; }
        public int UserId { get; set; }
        public List<Device> Devices { get; set; }
    }
}

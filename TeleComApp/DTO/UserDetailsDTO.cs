using TeleComApp.Models;

namespace TeleComApp.DTO
{
    public class UserDetailsDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Device> Devices { get; set; }
        public List<Plan> Plans { get; set; }
    }
}
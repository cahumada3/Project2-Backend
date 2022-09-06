using TeleComApp.DTO;

namespace TeleComApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }

        public User() { }
        public User(UserDTO dto)
        {
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.Email = dto.Email;
            this.Address = "";
            this.Devices = new List<Device>();
            this.Plans = new List<Plan>();
        }

        public User(UserDTO dto, int id)
        {
            this.UserId = id;
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.Email = dto.Email;
            this.Address = "";
            this.Devices = new List<Device>();
            this.Plans = new List<Plan>();
        }
    }
}
using TeleComApp.DTO;

namespace TeleComApp.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string Type { get; set; }
        public int PhoneLines { get; set; }
        public int NumberLines => Devices?.Count ?? 0;
        public int UserId { get; set; }
        public virtual ICollection<Device> Devices { get; set; }

        public Plan() { }

        public Plan(PlanDTO dto)
        {
            this.Type = dto.Type;
            this.PhoneLines = dto.PhoneLines;
            this.UserId = dto.UserId;
            this.Devices = new List<Device>();
        }

        public Plan(PlanDTO dto, int id)
        {
            this.PlanId = id;
            this.Type = dto.Type;
            this.PhoneLines = dto.PhoneLines;
            this.UserId = dto.UserId;
            this.Devices = new List<Device>();
        }

    }
}

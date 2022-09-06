using TeleComApp.DTO;

namespace TeleComApp.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public int Type { get; set; }
        public int PhoneLines { get; set; }
        public int NumberLines => Devices?.Count ?? 0;
        public int UserId { get; set; }
        public virtual ICollection<Device> Devices { get; set; }

        public Plan() { }

        public Plan(PlanDTO dto)
        {
            if (dto.Type.Contains("f"))
                this.Type = 0;
            if (dto.Type.Contains("work"))
                this.Type = 1;
            if (dto.Type.Contains("enter"))
                this.Type = 2;
            this.PhoneLines = dto.PhoneLines;
            this.UserId = dto.UserId;
            this.Devices = new List<Device>();
        }

        public Plan(PlanDTO dto, int id)
        {
            this.PlanId = id;
            if (dto.Type.Contains("f"))
                this.Type = 0;
            if (dto.Type.Contains("work"))
                this.Type = 1;
            if (dto.Type.Contains("enter"))
                this.Type = 2;
            this.PhoneLines = dto.PhoneLines;
            this.UserId = dto.UserId;
            this.Devices = new List<Device>();
        }

    }
}

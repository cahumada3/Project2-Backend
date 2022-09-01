using TeleComApp.DTO;

namespace TeleComApp.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string Model { get; set; }
        public int PhoneNumber { get; set; }
        public Boolean IsActive => PlanId != null;

        public int UserId { get; set; }
        public int? PlanId { get; set; }

        public Device() { }

        public Device(DeviceDTO dto)
        {
            this.Model = dto.Model;
            this.PhoneNumber = dto.PhoneNumber;
            this.UserId = dto.UserId;
            this.PlanId = dto.PlanId;
        }

        public Device(DeviceDTO dto, int id)
        {
            this.DeviceId = id;
            this.Model = dto.Model;
            this.PhoneNumber = dto.PhoneNumber;
            this.UserId = dto.UserId;
            this.PlanId = dto.PlanId;
        }
    }
}

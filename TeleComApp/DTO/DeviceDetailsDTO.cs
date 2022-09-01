namespace TeleComApp.DTO
{
    public class DeviceDetailsDTO
    {
        public int DeviceId { get; set; }
        public string Model { get; set; }
        public int PhoneNumber { get; set; }
        public Boolean IsActive { get; set; }

        public int UserId { get; set; }
        public int? PlanId { get; set; }
    }
}

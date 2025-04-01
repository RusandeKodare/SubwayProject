namespace subway_shared.DTOs.QueueDTOs
{
    public class QueueDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderReceived { get; set; } = DateTime.Now;
        public DateTime? OrderInProgress { get; set; }
        public DateTime? OrderCompleted { get; set; }
        public DateTime? OrderCollected { get; set; }
    }
}

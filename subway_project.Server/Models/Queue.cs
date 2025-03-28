namespace subway_project.Server.Models
{
    public class Queue
    {
        public int Id { get; set; }
        public required Order Order { get; set; }
        public DateTime OrderReceived { get; set; }
        public DateTime? OrderInProgress { get; set; }
        public DateTime? OrderCompleted { get; set; }
        public DateTime? OrderCollected { get; set; }
    }
}

namespace courser_project.Core.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }

        public Room()
        {
            IsAvailable = true;
        }
    }
}

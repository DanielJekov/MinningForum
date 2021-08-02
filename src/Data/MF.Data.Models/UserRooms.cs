namespace MF.Data.Models
{
    public class UserRooms
    {
        public int RoomId { get; set; }

        public Room Room { get; set; }

        public string UserId { get; set; }

        public MFUser User { get; set; }
    }
}

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        public Room Room { get; set; }
        public Amenity Amenity { get; set; }
    }
}

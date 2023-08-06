namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public RoomLayout Layout { get; set; }

        public List<RoomAmenities> Amenities { get; set; }

        public List<HotelRoom> HotelRooms { get; set;}

        public enum RoomLayout
        {
            Studio = 0,
            OneBedroom = 1,
            TwoBedroom = 2
        }
    }
}

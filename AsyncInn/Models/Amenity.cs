﻿namespace AsyncInn.Models
{
    public class Amenity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<RoomAmenities>? Amenities { get; set; }

    }
}

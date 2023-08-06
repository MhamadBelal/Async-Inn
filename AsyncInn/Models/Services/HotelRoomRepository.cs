using AsyncInn.Data;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }


        public async Task<HotelRoomDTO> Create(int hotelId, HotelRoomDTO hotelRoom)
        {
            var room = await _context.Rooms.FindAsync(hotelRoom.RoomID);
            var hotel = await _context.Hotels.FindAsync(hotelRoom.HotelID);

            var HotelRoom = new HotelRoom
            {
                HotelID = hotelId,
                RoomID = hotelRoom.RoomID,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
            };

            _context.HotelRooms.Add(HotelRoom);
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int roomId, int hotelId)
        {
            var HotelRoom = await _context.HotelRooms.Where(x=>x.RoomID==roomId && x.HotelID==hotelId).FirstOrDefaultAsync();
            if (HotelRoom != null)
            {
                _context.Entry(HotelRoom).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HotelRoomDTO>> GetAll(int hotelId)
        {
            var hotelRoom = await _context.HotelRooms
                .Include(r => r.Room)
                .ThenInclude(ar => ar.Amenities)
                .ThenInclude(a => a.Amenity)
                .Where(hr => hr.HotelID == hotelId).ToListAsync();

            var HotelRoom = hotelRoom.Select(hr=>new HotelRoomDTO
            {
                HotelID = hr.HotelID,
                RoomNumber = hr.RoomNumber,
                Rate = hr.Rate,
                PetFriendly = hr.PetFriendly,
                RoomID = hr.RoomID,
                Room = new RoomDTO
                {
                    ID = hr.Room.ID,
                    Name = hr.Room.Name,
                    Layout = hr.Room.Layout.ToString(),
                    Amenities = hr.Room.Amenities.Select(a => new AmenityDTO
                    {
                        ID = a.Amenity.ID,
                        Name = a.Amenity.Name
                    }).ToList()
                }
            }).ToList();

            return HotelRoom;
        }

        public async Task<HotelRoomDTO> GetbyId(int roomId, int hotelId)
        {
            var hotelRoom = await _context.HotelRooms
                .Include(r => r.Room)
                .ThenInclude(ar => ar.Amenities)
                .ThenInclude(a => a.Amenity)
                .Where(hr => hr.RoomID == roomId && hr.HotelID == hotelId).FirstOrDefaultAsync();
            
            if (hotelRoom == null)
            {
                return null;
            }

            var HotelRoom= new HotelRoomDTO
            {
                HotelID = hotelRoom.HotelID,
                RoomNumber=hotelRoom.RoomNumber,
                Rate=hotelRoom.Rate,
                PetFriendly=hotelRoom.PetFriendly,
                RoomID=hotelRoom.RoomID,
                Room= new RoomDTO
                {
                    ID=hotelRoom.Room.ID,
                    Name=hotelRoom.Room.Name,
                    Layout=hotelRoom.Room.Layout.ToString(),
                    Amenities=hotelRoom.Room.Amenities.Select(a=> new AmenityDTO
                    {
                        ID=a.Amenity.ID,
                        Name=a.Amenity.Name
                    }).ToList()
                }
            };

            return HotelRoom;
        }

        public async Task<HotelRoomDTO> Update(int hotelId, int roomId, HotelRoomDTO hotelRoom)
        {
            var HotelRoom = await _context.HotelRooms.Where(x => x.RoomID == roomId && x.HotelID == hotelId).FirstOrDefaultAsync();
            if(HotelRoom != null)
            {
                HotelRoom.HotelID = hotelRoom.HotelID;
                HotelRoom.RoomID = hotelRoom.RoomID;
                HotelRoom.RoomNumber=hotelRoom.RoomNumber;
                HotelRoom.Rate=hotelRoom.Rate;
                HotelRoom.PetFriendly=hotelRoom.PetFriendly;

                await _context.SaveChangesAsync();
            }
            return hotelRoom;
        }
    }
}

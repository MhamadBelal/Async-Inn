using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: /api/Hotels/{hotelId}/Rooms
        [HttpGet("{hotelId}")]
        [Route("Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {
            return await _hotelRoom.GetAll(hotelId);
        }

        // GET: api/Hotels/{hotelId}/Rooms/{roomNumber}
        [HttpGet("{id}")]
        [Route("Hotels/{hotelId}/Rooms/{hotelId}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int roomId,int hotelId)
        {
            var amenity = await _hotelRoom.GetbyId(roomId, hotelId);

            return amenity;
        }

        // PUT: api/Hotels/{hotelId}/Rooms/{roomNumber}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Hotels/{hotelId}/Rooms/{hotelId}")]
        public async Task<IActionResult> PutHotelRoom(int roomId,int hotelId, HotelRoom hotelRoom)
        {
            if (roomId != hotelRoom.RoomID || hotelId!=hotelRoom.HotelID)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.Update(hotelRoom);

            return Ok(updateHotelRoom);
        }

        // Post: api/Hotels/{hotelId}/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int hotelId,HotelRoom hotelRoom)
        {
            hotelRoom.HotelID = hotelId;
            var addedHotelRoom = await _hotelRoom.Create(hotelRoom);
            return CreatedAtAction(nameof(GetHotelRoom), new { hotelId, roomId = addedHotelRoom.RoomID }, addedHotelRoom);
        }

        // DELETE: api/Hotels/{hotelId}/Rooms/{roomNumber}
        [HttpDelete("{id}")]
        [Route("Hotels/{hotelId}/Rooms/{hotelId}")]
        public async Task<IActionResult> DeleteHotelRoom(int roomId,int hotelId)
        {
            await _hotelRoom.Delete(roomId, hotelId);

            return NoContent();
        }

    }
}

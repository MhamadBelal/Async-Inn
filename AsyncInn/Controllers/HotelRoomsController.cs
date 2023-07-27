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
    [Route("api/Hotels/{hotelId}/Rooms")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: /api/Hotels/{hotelId}/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {
            return await _hotelRoom.GetAll(hotelId);
        }

        // GET: api/HotelRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int roomId,int hotelId)
        {
            var amenity = await _hotelRoom.GetbyId(roomId, hotelId);

            return amenity;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelRoom(int roomId,int hotelId, HotelRoom hotelRoom)
        {
            if (roomId != hotelRoom.RoomID || hotelId!=hotelRoom.HotelID)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.Update(hotelRoom);

            return Ok(updateHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            await _hotelRoom.Create(hotelRoom);

            // Rurtn a 201 Header to Browser or the postmane
            return CreatedAtAction("GetHotelRoom", new { roomId = hotelRoom.RoomID }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelRoom(int roomId,int hotelId)
        {
            await _hotelRoom.Delete(roomId, hotelId);

            return NoContent();
        }

    }
}

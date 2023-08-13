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
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "District Manager,Property Manager,Agent", Policy = "read")]
        [AllowAnonymous]
        [HttpGet("Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms(int hotelId)
        {
            return await _hotelRoom.GetAll(hotelId);
        }

        // GET: api/Hotels/{hotelId}/Rooms/{roomId}
        [Authorize(Roles = "District Manager,Property Manager,Agent", Policy = "read")]
        [AllowAnonymous]
        [HttpGet("Hotels/{hotelId}/Rooms/{roomId}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int roomId,int hotelId)
        {
            var amenity = await _hotelRoom.GetbyId(roomId, hotelId);

            return amenity;
        }

        // PUT: api/Hotels/{hotelId}/Rooms/{roomId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager,Property Manager,Agent", Policy = "update")]
        [HttpPut("Hotels/{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> PutHotelRoom(int roomId,int hotelId, HotelRoomDTO hotelRoom)
        {
            var updateHotelRoom = await _hotelRoom.Update(hotelId,roomId,hotelRoom);

            return Ok(updateHotelRoom);
        }

        // Post: api/Hotels/{hotelId}/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager,Property Manager", Policy = "create")]
        [HttpPost("Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(int hotelId, HotelRoomDTO hotelRoom)
        {
           /// hotelRoom.HotelID = hotelId;
            var addedHotelRoom = await _hotelRoom.Create(hotelId,hotelRoom);
            //return CreatedAtAction(nameof(GetHotelRoom), new { hotelId, roomId = addedHotelRoom.RoomID }, addedHotelRoom);
            return Ok("added successfully!");
        }

        // DELETE: api/Hotels/{hotelId}/Rooms/{roomId}
        [Authorize(Roles = "District Manager", Policy = "delete")]
        [HttpDelete("Hotels/{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> DeleteHotelRoom(int roomId,int hotelId)
        {
            await _hotelRoom.Delete(roomId, hotelId);

            return Ok("Removed Successfully");
        }

    }
}

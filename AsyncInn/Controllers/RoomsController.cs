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
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [Authorize(Roles = "District Manager", Policy = "read")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return await _room.GetAll();
        }

        // GET: api/Rooms/5
        [Authorize(Roles = "District Manager", Policy = "read")]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await _room.GetbyId(id);

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager", Policy = "update")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            var updateRoom = await _room.Update(id, room);

            return Ok(updateRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager", Policy = "create")]
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {
            await _room.Create(room);

            // Rurtn a 201 Header to Browser or the postmane
            return CreatedAtAction(nameof(GetRoom), new { id = room.ID }, room);
        }

        // DELETE: api/Rooms/5
        [Authorize(Roles = "District Manager", Policy = "delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _room.Delete(id);

            return Ok("removed successfuly");
        }
        [Authorize(Roles = "District Manager,Property Manager,Agent", Policy = "create")]
        [HttpPost("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
            return Ok("added successfuly");
        }

        [Authorize(Roles = "District Manager,Agent", Policy = "delete")]
        [HttpDelete("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmentityFromRoom(roomId,amenityId);
            return Ok("removed successfuly");
        }
    }
}

﻿using System;
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
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        // GET: api/Hotels
        [Authorize(Roles = "District Manager", Policy = "read")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            return await _hotel.GetAll();
        }

        // GET: api/Hotels/5
        [Authorize(Roles = "District Manager", Policy = "read")]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await _hotel.GetbyId(id);

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager", Policy = "update")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDTO hotel)
        {
            var updateHotel = await _hotel.Update(id, hotel);

            return Ok(updateHotel);
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager", Policy = "create")]
        [HttpPost]
        public async Task<ActionResult<HotelDTO>> PostHotel(HotelDTO hotel)
        {
            await _hotel.Create(hotel);

            // Rurtn a 201 Header to Browser or the postmane
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.ID }, hotel);
        }

        // DELETE: api/Hotels/5
        [Authorize(Roles = "District Manager", Policy = "delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotel.Delete(id);

            return Ok("Removed Successfully");
        }
    }
}

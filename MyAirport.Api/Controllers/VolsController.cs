﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LLTM.MyAirport.EF;

namespace MyAirport.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly MyAirportContext _context;

        public VolsController(MyAirportContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Show every Flight.
        /// </summary>
        // GET: api/Vols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols([FromQuery(Name ="bagages")] bool bagage)
        {
            DbSet<Vol> vols = _context.Vols;

            if (bagage)
            {
                return await vols.Include(vol => vol.Bagages).ToListAsync();
            }
            return await vols.ToListAsync();
        }

        /// <summary>
        /// Show a specific Flight.
        /// </summary>
        // GET: api/Vols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);

            if (vol == null)
            {
                return NotFound();
            }
            await _context.Entry(vol).Collection(v => v.Bagages).LoadAsync();

            return vol;
        }

        /// <summary>
        /// Modify a specific Flight.
        /// </summary>
        // PUT: api/Vols/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolID)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Add a specific Flight.
        /// </summary>
        // POST: api/Vols
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetVol", new { id = vol.VolID }, vol);
            return CreatedAtAction(nameof(GetVol), new { id = vol.VolID }, vol);
        }

        /// <summary>
        /// Delete a specific Flight.
        /// </summary>
        // DELETE: api/Vols/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.VolID == id);
        }
    }
}

using System;
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

        // GET: api/Vols
        /// <summary>
        /// Find every Vols.
        /// </summary>
        /// <returns>Found Vols</returns>
        /// <response code="200">Vols found successfully</response>
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

        // GET: api/Vols/5
        /// <summary>
        /// Find a specific Bagage.
        /// </summary>
        /// /// <param name="id">Vol Id</param>
        /// <returns>Found a specific Vol</returns>
        /// <response code="200">Vol found successfully</response>
        /// <response code="404">Vol not found</response>
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

        // PUT: api/Vols/5
        /// <summary>
        /// Modify a specific Vol.
        /// </summary>
        /// /// <param name="id">Vol Id</param>
        /// <returns>Deleted Bagage</returns>
        /// <response code="200">Vol modified successfully</response>
        /// <response code="404">Vol not found</response>
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

        // POST: api/Vols
        /// <summary>
        /// Add a specific Vol.
        /// </summary>
        /// <returns>Add Bagage</returns>
        /// <response code="200">Bagage added successfully</response>
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetVol", new { id = vol.VolID }, vol);
            return CreatedAtAction(nameof(GetVol), new { id = vol.VolID }, vol);
        }

        // DELETE: api/Vols/5
        /// <summary>
        /// Delete a specific Vol.
        /// </summary>
        /// /// <param name="id">Vol Id</param>
        /// <returns>Deleted Vol</returns>
        /// <response code="200">Vol deleted successfully</response>
        /// <response code="404">Vol not found</response>
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

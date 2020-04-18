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
    public class BagagesController : ControllerBase
    {
        private readonly MyAirportContext _context;

        public BagagesController(MyAirportContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Show every Bagages.
        /// </summary>
        // GET: api/Bagages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bagage>>> GetBagages()
        {
            DbSet < Bagage > bagages =_context.Bagages;

            return await bagages.ToListAsync();
        }

        /// <summary>
        /// Show a specific Bagage.
        /// </summary>
        // GET: api/Bagages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bagage>> GetBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);

            if (bagage == null)
            {
                return NotFound();
            }

            return bagage;
        }

        /// <summary>
        /// Modify a specific Bagage.
        /// </summary>
        // PUT: api/Bagages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBagage(int id, Bagage bagage)
        {
            if (id != bagage.BagageID)
            {
                return BadRequest();
            }

            _context.Entry(bagage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagageExists(id))
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
        /// Add a specific Bagage.
        /// </summary>
        // POST: api/Bagages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bagage>> PostBagage(Bagage bagage)
        {
            _context.Bagages.Add(bagage);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBagage", new { id = bagage.BagageID }, bagage);
            return CreatedAtAction(nameof(GetBagage), new { id = bagage.BagageID }, bagage);
        }


        // DELETE: api/Bagages/5
        /// <summary>
        /// Delete a specific Bagage.
        /// </summary>
        /// /// <param name="id">Bagage Id</param>
        /// <returns>Deleted Bagage</returns>
        /// <response code="200">Bagage deleted successfully</response>
        /// <response code="404">Bagage not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bagage>> DeleteBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);
            if (bagage == null)
            {
                return NotFound();
            }

            _context.Bagages.Remove(bagage);
            await _context.SaveChangesAsync();

            return bagage;
        }

        private bool BagageExists(int id)
        {
            return _context.Bagages.Any(e => e.BagageID == id);
        }
    }
}

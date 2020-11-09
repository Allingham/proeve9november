using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanteShopApi;
using PlanteShopService;

namespace PlanteShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanterController : ControllerBase
    {
        private readonly PlanteContext _context;

        public PlanterController(PlanteContext context)
        {
            _context = context;
        }



        // GET: api/Planter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plante>>> GetPlante()
        {
            return await _context.Plante.ToListAsync();
        }

        // GET: api/Planter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plante>> GetPlante(int id)
        {
            var plante = await _context.Plante.FindAsync(id);

            if (plante == null)
            {
                return NotFound();
            }

            return plante;
        }

        [HttpGet]
        [Route("GetByType/{type}")]
        public async Task<ActionResult<IEnumerable<Plante>>> GetByType(string type)
        {
            List<Plante> planterByType = _context.Plante.ToList();
            return planterByType.FindAll(p => p.PlanteType.ToLower().Contains(type.ToLower()));
        }

        // PUT: api/Planter/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlante(int id, Plante plante)
        {
            if (id != plante.PlanteId)
            {
                return BadRequest();
            }

            _context.Entry(plante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanteExists(id))
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

        // POST: api/Planter
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Plante>> PostPlante(Plante plante)
        {
            _context.Plante.Add(plante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlante", new { id = plante.PlanteId }, plante);
        }

        // DELETE: api/Planter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Plante>> DeletePlante(int id)
        {
            var plante = await _context.Plante.FindAsync(id);
            if (plante == null)
            {
                return NotFound();
            }

            _context.Plante.Remove(plante);
            await _context.SaveChangesAsync();

            return plante;
        }

        private bool PlanteExists(int id)
        {
            return _context.Plante.Any(e => e.PlanteId == id);
        }
    }
}

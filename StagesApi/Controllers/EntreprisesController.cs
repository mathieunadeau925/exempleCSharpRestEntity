using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StagesApi;

namespace StagesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntreprisesController : ControllerBase
    {
        private readonly StagesDbContext _context;

        public EntreprisesController(StagesDbContext context)
        {
            _context = context;
        }

        // GET: api/Entreprises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entreprise>>> GetEntreprise()
        {
            return await _context.Entreprise.ToListAsync();
        }

        // GET: api/Entreprises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entreprise>> GetEntreprise(int id)
        {
            var entreprise = await _context.Entreprise.FindAsync(id);

            if (entreprise == null)
            {
                return NotFound();
            }

            return entreprise;
        }

        // PUT: api/Entreprises/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntreprise(int id, Entreprise entreprise)
        {
            if (id != entreprise.Id)
            {
                return BadRequest();
            }

            _context.Entry(entreprise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrepriseExists(id))
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

        // POST: api/Entreprises
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Entreprise>> PostEntreprise(Entreprise entreprise)
        {
            _context.Entreprise.Add(entreprise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntreprise", new { id = entreprise.Id }, entreprise);
        }

        // DELETE: api/Entreprises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entreprise>> DeleteEntreprise(int id)
        {
            var entreprise = await _context.Entreprise.FindAsync(id);
            if (entreprise == null)
            {
                return NotFound();
            }

            _context.Entreprise.Remove(entreprise);
            await _context.SaveChangesAsync();

            return entreprise;
        }

        private bool EntrepriseExists(int id)
        {
            return _context.Entreprise.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaDbContext _context;

        public PizzasController(PizzaDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await _context.Pizzas.ToListAsync();
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return NotFound();
            return pizza;
        }

        // POST: api/Pizzas
        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);
        }

        // PUT: api/Pizzas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, Pizza pizza)
        {
            if (id != pizza.Id) return BadRequest();
            _context.Entry(pizza).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return NotFound();
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

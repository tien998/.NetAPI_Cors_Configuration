using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    ILogger<PizzaController> _logger;
    public PizzaController(ILogger<PizzaController> logger)
    {
        _logger = logger;
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaServices.GetAll();

    // GET by id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaServices.Get(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return pizza;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaServices.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
        if (PizzaServices.Get(id) is null)
            return NotFound();
        PizzaServices.Update(pizza);
        return NoContent();
        // return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if(PizzaServices.Get(id) is null)
            return NotFound();
        PizzaServices.Delete(id);
        return NoContent();
    }
}
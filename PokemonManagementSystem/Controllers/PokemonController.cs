using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonManagementSystem.DataAccess;
using PokemonManagementSystem.Services;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace PokemonManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonDbContext _dbContext;
        public PokemonController(PokemonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            dynamic resultSet;
            try
            {
                    resultSet = await _dbContext.Pokemons.ToListAsync();
            }
           
            catch (Exception ex)
            {
               
                return StatusCode((int)HttpStatusCode.ServiceUnavailable);
            }
            return Ok(resultSet);
        }
    }
}

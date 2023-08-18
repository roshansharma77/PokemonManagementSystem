using Microsoft.AspNetCore.Mvc;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<PokemonViewModel> pokemons = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7065/api/");
                //HTTP GET
                var responseTask = client.GetAsync("pokemon");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PokemonViewModel>>();
                    readTask.Wait();

                    pokemons = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    pokemons = Enumerable.Empty<PokemonViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(pokemons);
        }
    }
}

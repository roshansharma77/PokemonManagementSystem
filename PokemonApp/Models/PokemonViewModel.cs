using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonApp.Models
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
        public string PokemonPower { get; set; }
        public string PokemonImage { get; set; }
        public bool favourite { get; set; }

        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
    }
}

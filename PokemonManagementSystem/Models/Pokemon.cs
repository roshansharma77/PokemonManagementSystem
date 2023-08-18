using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonManagementSystem.Models
{
    public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
        public string PokemonPower { get; set; }
        public string PokemonImage { get; set; }
        public bool favourite { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

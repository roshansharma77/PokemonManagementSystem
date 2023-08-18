using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using PokemonManagementSystem.Models;

namespace PokemonManagementSystem.DataAccess
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext()
        {
                
        }
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
                
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlite(@"DataSource=mydatabase.db;");
        //}
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This will singularize all table names
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }
        }
    }
}

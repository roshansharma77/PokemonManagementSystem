using PokemonManagementSystem.DataAccess;

namespace PokemonManagementSystem.Services
{
    public class PokemonSecurity
    {
        public static bool Login(string username, string password)
        {
            using (PokemonDbContext DbContext = new PokemonDbContext())
            {
                return DbContext.Users.Any(user =>
                       user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.Password == password);
            }
        }
    }
}

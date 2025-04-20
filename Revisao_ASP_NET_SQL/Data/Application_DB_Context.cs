using Microsoft.EntityFrameworkCore;

using Revisao_ASP_NET_SQL.Models;

namespace Revisao_ASP_NET_SQL.Data
{

    public class Application_DB_Context : DbContext
    {

        public Application_DB_Context(DbContextOptions<Application_DB_Context> options) : base(options) {  }

        public DbSet<Models.Console> Consoles { get; set; }

        public DbSet<Models.Loja> Lojas { get; set; }

        public DbSet<Models.Game> Games { get; set; }

        public DbSet<Models.Game_Loja> Games_Loja { get; set; }

    }

}

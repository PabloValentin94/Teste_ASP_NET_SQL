namespace Revisao_ASP_NET_SQL.Models
{

    public class Game
    {

        public int Id { get; set; }

        public string? Nome { get; set; }

        public int ConsoleId { get; set; }  // Id (Console).

        public Console? Console { get; set; }

    }

}

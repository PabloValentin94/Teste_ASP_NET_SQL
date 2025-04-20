namespace Revisao_ASP_NET_SQL.Models
{

    public class Game_Loja
    {

        public int Id { get; set; }

        public int GameId { get; set; } // Id (Game).

        public int LojaId { get; set; } // Id (Loja).

        public Game? Game { get; set; }

        public Loja? Loja { get; set; }

    }

}

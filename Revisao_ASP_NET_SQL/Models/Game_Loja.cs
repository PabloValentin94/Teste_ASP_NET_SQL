using System.ComponentModel.DataAnnotations;

namespace Revisao_ASP_NET_SQL.Models
{
    public class Game_Loja
    {
        [Display(Name = "ID do Item")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "ID do Game Associado")]
        public int GameId { get; set; } // Id (Game).

        [Required]
        [Display(Name = "ID da Loja Associada")]
        public int LojaId { get; set; } // Id (Loja).

        [Display(Name = "Game Associado")]
        public Game? Game { get; set; }

        [Display(Name = "Loja Associada")]
        public Loja? Loja { get; set; }
    }
}

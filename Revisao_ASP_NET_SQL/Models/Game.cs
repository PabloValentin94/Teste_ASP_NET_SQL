using System.ComponentModel.DataAnnotations;

namespace Revisao_ASP_NET_SQL.Models
{
    public class Game
    {
        [Display(Name = "ID do Game")]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        [Display(Name = "ID do Console Associado")]
        public int ConsoleId { get; set; }  // Id (Console).

        [Display(Name = "Console Associado")]
        public Console? Console { get; set; }
    }
}

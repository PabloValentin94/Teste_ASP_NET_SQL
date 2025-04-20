using System.ComponentModel.DataAnnotations;

namespace Revisao_ASP_NET_SQL.Models
{
    public class Console
    {
        [Display(Name = "ID do Console")]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }
    }
}

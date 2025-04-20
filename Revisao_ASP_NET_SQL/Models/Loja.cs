using System.ComponentModel.DataAnnotations;

namespace Revisao_ASP_NET_SQL.Models
{
    public class Loja
    {
        [Display(Name = "ID da Loja")]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }
    }
}

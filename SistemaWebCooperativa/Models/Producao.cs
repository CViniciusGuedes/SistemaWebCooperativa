using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SistemaWebCooperativa.Models
{
    public class Producao
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Cooperado é obrigatório...")]
        [Display(Name = "Cooperado: ")]
        public Cooperado cooperado { get; set; }
        [Display(Name = "Cooperado: ")]
        public int cooperadoid { get; set; }

        [Required(ErrorMessage = "Produto é obrigatório...")]
        [Display(Name = "Produto: ")]
        public Produto produto { get; set; }
        [Display(Name = "Produto: ")]
        public int produtoid { get; set; }

        [Display(Name = "Quantidade: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float quantidade { get; set; }

        public ICollection<Transacao> transacoes { get; set; }
    }
}

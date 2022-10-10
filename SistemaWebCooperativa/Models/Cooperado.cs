using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SistemaWebCooperativa.Models
{
    public class Cooperado
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo telefone é obrigatório")]
        [Display(Name = "Telefone: ")]
        public string telefone { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo telefone é obrigatório")]
        [Display(Name = "Email: ")]
        public string email { get; set; }

        [Display(Name = "CPF")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int cpf { get; set; }

        [Display(Name = "Propriedade: ")]
        public Propriedade propriedade { get; set; }
    }
}

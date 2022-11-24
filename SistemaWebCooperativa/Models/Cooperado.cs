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

        [Display(Name = "CPF: ")]
        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        [MaxLength(11)]
        [MinLength(11)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O CPF deve conter apenas números")]
        public string cpf { get; set; }

        [Display(Name = "Propriedade: ")]
        public Propriedade propriedade { get; set; }
        [Display(Name = "Propriedade: ")]
        public int propriedadeid { get; set; }

        public ICollection<Producao> producoes { get; set; }
    }
}

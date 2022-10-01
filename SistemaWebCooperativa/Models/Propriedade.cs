using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SistemaWebCooperativa.Models
{
    public class Propriedade
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int Id { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo endereço é obrigatório")]
        [Display(Name = "Endereço: ")]
        public string endereco { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo bairro é obrigatório")]
        [Display(Name = "Bairro: ")]
        public string bairro { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo cidade é obrigatório")]
        [Display(Name = "Cidade: ")]
        public string cidade { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo UF é obrigatório")]
        [Display(Name = "UF: ")]
        public string uf { get; set; }

        [Display(Name = "Area")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float area { get; set; }
    }
}

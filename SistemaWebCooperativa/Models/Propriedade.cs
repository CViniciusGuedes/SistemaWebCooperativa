using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Xml.Linq;

namespace SistemaWebCooperativa.Models
{
    public enum UF { RS, SC, PR, SP, RJ, ES, MG, MS, MT, TO, GO, DF, RO, AC, AM, PA, PI, PE, PB, CE, RN }
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

        [Required(ErrorMessage = "Campo UF é obrigatório")]
        [Display(Name = "UF: ")]
        public UF uf { get; set; }

        [Display(Name = "Area")]
        [Required(ErrorMessage = "Campo Area é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float area { get; set; }

        public ICollection<Cooperado> cooperados { get; set; }
    }
}

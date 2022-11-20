using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SistemaWebCooperativa.Models
{
    public class Insumo
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        //[Required(ErrorMessage = "Tipo Insumo é obrigatório...")]
        //[Display(Name = "Tipo Insumo: ")]
        //public TipoInsumo tipoinsumo { get; set; }

        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float quantidade { get; set; }

        [Display(Name = "Preço: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float preco { get; set; }

        //[Required(ErrorMessage = "Cooperado é obrigatório...")]
        //[Display(Name = "Cooperado: ")]
        //public Cooperado cooperado { get; set; }
    }
}

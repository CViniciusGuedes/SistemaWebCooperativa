using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace SistemaWebCooperativa.Models
{
    public class Produto
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
        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }

        [Display(Name = "Preço: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float preco { get; set; }

        public ICollection<Producao> producoes { get; set; }
    }
}

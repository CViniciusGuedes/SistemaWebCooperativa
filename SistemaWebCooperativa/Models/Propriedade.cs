namespace SistemaWebCooperativa.Models
{
    public class Propriedade
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public float area { get; set; }
    }
}

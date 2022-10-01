namespace SistemaWebCooperativa.Models
{
    public class Cooperado
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public int cpf { get; set; }
        public Propriedade propriedade { get; set; }
    }
}

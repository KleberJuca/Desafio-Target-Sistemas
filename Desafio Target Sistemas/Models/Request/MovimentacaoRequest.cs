namespace Desafio_Target_Sistemas.Models.Request
{
    public class MovimentacaoRequest
    {
        public List<Produto> Estoque { get; set; } = new();
        public int CodigoProduto { get; set; }
        public string Tipo { get; set; } = string.Empty; // E / S
        public int Quantidade { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }

    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public int Estoque { get; set; }
    }
}

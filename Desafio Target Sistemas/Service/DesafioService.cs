using Desafio_Target_Sistemas.Interface;
using Desafio_Target_Sistemas.Models.Request;
using Desafio_Target_Sistemas.Models.Response;
using Desafio_Target_Sistemas.Uteis;

namespace Desafio_Target_Sistemas.Service
{
    public class DesafioService : IDesafioService
    {
        public async Task<IEnumerable<ComissaoResponse>> CalcularComissoesAsync(IEnumerable<VendaRequest> vendas)
        {
            if (vendas is null)
                throw new ArgumentNullException(nameof(vendas));

            var resultado = vendas
                .GroupBy(v => v.Vendedor)
                .Select(g => new ComissaoResponse
                {
                    Vendedor = g.Key,
                    TotalVendido = g.Sum(v => v.Valor),
                    TotalComissao = g.Sum(v => CalcularComissao.Calcular(v.Valor))
                })
                .ToList();

            return await Task.FromResult(resultado);
        }


        public async Task<MovimentacaoResponse> MovimentarEstoqueAsync(MovimentacaoRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            if (request.Estoque is null || request.Estoque.Count == 0)
                throw new ArgumentException("Informe a lista de produtos (estoque).", nameof(request));

            var produto = request.Estoque.FirstOrDefault(p => p.CodigoProduto == request.CodigoProduto);

            if (produto is null)
                throw new InvalidOperationException($"Produto {request.CodigoProduto} não encontrado na lista enviada.");

            var tipo = request.Tipo?.Trim().ToUpperInvariant();
            if (tipo != "E" && tipo != "S")
                throw new ArgumentException("Tipo inválido. Use 'E' para Entrada ou 'S' para Saída.", nameof(request));

            if (request.Quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(request));

            if (tipo == "S" && request.Quantidade > produto.Estoque)
                throw new InvalidOperationException("Não há estoque suficiente para saída.");

            var estoqueAtualizado = request.Estoque
                .Select(p => new Produto
                {
                    CodigoProduto = p.CodigoProduto,
                    DescricaoProduto = p.DescricaoProduto,
                    Estoque = p.Estoque
                })
                .ToList();

            var produtoMovimentado = estoqueAtualizado.First(p => p.CodigoProduto == request.CodigoProduto);

            var quantidadeReal = tipo == "E" ? request.Quantidade : -request.Quantidade;
            produtoMovimentado.Estoque += quantidadeReal;

            var resposta = new MovimentacaoResponse
            {
                IdMovimentacao = Guid.NewGuid(),
                CodigoProduto = produtoMovimentado.CodigoProduto,
                DescricaoProduto = produtoMovimentado.DescricaoProduto,
                Tipo = tipo,
                Quantidade = request.Quantidade,
                DescricaoMovimento = request.Descricao,
                EstoqueFinal = produtoMovimentado.Estoque,
                EstoqueAtualizado = estoqueAtualizado
            };

            return await Task.FromResult(resposta);
        }

        public async Task<JurosResponse> CalcularJurosAsync(JurosRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var hoje = DateTime.Today;
            var diasAtraso = (hoje.Date - request.DataVencimento.Date).Days;

            if (diasAtraso <= 0)
            {
                var respostaSemAtraso = new JurosResponse
                {
                    ValorOriginal = request.Valor,
                    DataVencimento = request.DataVencimento.Date,
                    DiasAtraso = 0,
                    Juros = 0m,
                    ValorFinal = request.Valor
                };

                return await Task.FromResult(respostaSemAtraso);
            }

            const decimal taxaDiaria = 0.025m;
            var juros = request.Valor * taxaDiaria * diasAtraso;
            var valorFinal = request.Valor + juros;

            var resposta = new JurosResponse
            {
                ValorOriginal = request.Valor,
                DataVencimento = request.DataVencimento.Date,
                DiasAtraso = diasAtraso,
                Juros = juros,
                ValorFinal = valorFinal
            };

            return await Task.FromResult(resposta);
        }
    }
}

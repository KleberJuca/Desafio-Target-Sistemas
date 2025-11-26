using Desafio_Target_Sistemas.Models.Request;
using Desafio_Target_Sistemas.Models.Response;

namespace Desafio_Target_Sistemas.Interface
{
    public interface IDesafioService
    {
        Task<IEnumerable<ComissaoResponse>> CalcularComissoesAsync(IEnumerable<VendaRequest> vendas);
        Task<MovimentacaoResponse> MovimentarEstoqueAsync(MovimentacaoRequest request);
        Task<JurosResponse> CalcularJurosAsync(JurosRequest request);
    }
}

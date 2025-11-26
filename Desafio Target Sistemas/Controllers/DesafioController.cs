using Desafio_Target_Sistemas.Interface;
using Desafio_Target_Sistemas.Models.Request;
using Desafio_Target_Sistemas.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Target_Sistemas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DesafioController : ControllerBase
{
    private readonly IDesafioService _service;

    public DesafioController(IDesafioService service)
    {
        _service = service;
    }

    [HttpPost("comissoes")]
    public async Task<ActionResult<IEnumerable<ComissaoResponse>>> Comissoes([FromBody] IEnumerable<VendaRequest> vendas)
    {
        var resultado = await _service.CalcularComissoesAsync(vendas);
        return Ok(resultado);
    }

    [HttpPost("estoque/movimentar")]
    public async Task<ActionResult<MovimentacaoResponse>> Movimentar([FromBody] MovimentacaoRequest request)
    {
        var resultado = await _service.MovimentarEstoqueAsync(request);
        return Ok(resultado);
    }

    [HttpPost("juros")]
    public async Task<ActionResult<JurosResponse>> Juros([FromBody] JurosRequest request)
    {
        var resultado = await _service.CalcularJurosAsync(request);
        return Ok(resultado);
    }
}

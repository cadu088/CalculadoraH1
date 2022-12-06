using Microsoft.AspNetCore.Mvc;
using ProvaBimestralH1.Models;

namespace ProvaBimestralH1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GastoCaloricoController : Controller
    {
        private readonly ILogger<GastoCaloricoController> _logger;

        public GastoCaloricoController(ILogger<GastoCaloricoController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GastoCaloricoBasal")]
        public IActionResult GastoCaloricoBasal(GastoCaloricoModelEntrada data)
        {
            try
            {
                double resultado = 0;
                // Validações
                if (data.Sexo != "M" && data.Sexo != "F")
                {
                    return BadRequest(new { success = false, mensagem = "Entre com um sexo valido!" });
                }

                if (data.Quilo < 0)
                {
                    return BadRequest(new { success = false, mensagem = "Entre com um peso valido!" });
                }

                if (data.Idade < 0)
                {
                    return BadRequest(new { success = false, mensagem = "Entre com uma idade valida!" });
                }

                // regras de negocio 
                if (data.Idade >= 18 && data.Idade <= 30)
                {

                    if (data.Sexo == "M")
                    {
                        resultado = (0.063 * data.Quilo + 2.896) * 239;
                    }
                    else
                    {
                        resultado = (0.062 * data.Quilo + 2.036) * 239;
                    }

                }else if (data.Idade >= 31 && data.Idade <= 40)
                {

                    if (data.Sexo == "M")
                    {
                        resultado = (0.048 * data.Quilo + 3.653) * 239;
                    }
                    else
                    {
                        resultado = (0.034 * data.Quilo + 3.538) * 239;
                    }

                }
                else
                {
                    return BadRequest(new { success = false, mensagem = "Entre com uma idade entre 18 a 40 anos!" });
                }

                GastoCaloricoModelSaida saida = new GastoCaloricoModelSaida(resultado);

                return Ok(saida);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [HttpPost(Name = "GastoCaloricoAtividade")]

        public IActionResult GastoCaloricoAtividade()
        {

        }
    } 
}


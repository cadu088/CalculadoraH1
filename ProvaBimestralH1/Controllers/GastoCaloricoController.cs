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

        [Route("GastoCaloricoBasal")]
        [HttpPost]
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

                return Ok(new GastoCaloricoModelSaida(Convert.ToInt32(resultado)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }

        [Route("GastoCaloricoAtividade")]
        [HttpPost]
        public IActionResult GastoCaloricoAtividade(GastoCaloricoAtividadelEntrada data)
        {
            try
            {

                string[] exerciciosValidos = new string[]
                {
                    "Caminhada (piso plano)",
                    "Trabalho doméstico",
                    "Corrida (5 min/Km)",
                    "Bicicleta (9 km/h)",
                    "Bicicleta (15 Km/h)",
                    "Alongamento"
                };

                if (data.MinutosExercicio < 0)
                {
                   return BadRequest(new { success = false, mensagem = "Entre com minutos validos!" });
                }
                //.Contains(data.Exercicio)
                if (exerciciosValidos.Where(x => (x == data.Exercicio)).Count() <= 0)
                {
                   return BadRequest(new { success = false, mensagem = "atividade não existe, calculo não pode ser realizado" });
                }

                double resultado = 0;

                switch (data.Exercicio)
                {
                    case "Caminhada (piso plano)":
                        resultado = 6.1 * data.MinutosExercicio;
                        break;
                    case "Trabalho doméstico":
                        resultado = 4.6 * data.MinutosExercicio;
                        break;
                    case "Corrida (5 min/Km)":
                        resultado = 16 * data.MinutosExercicio;
                        break;
                    case "Bicicleta (9 km/h)":
                        resultado = 4.9 * data.MinutosExercicio;
                        break;
                    case "Bicicleta (15 Km/h)":
                        resultado = 7.7 * data.MinutosExercicio;
                        break;
                    case "Alongamento":
                        resultado = 5.4 * data.MinutosExercicio;
                        break;
                    //default:
                    //    return BadRequest(new { success = false, mensagem = "atividade não existe, calculo não pode ser realizado" });
                    //    break;
                }
                    
                return Ok(new GastoCaloricoAtividadelSaida(Convert.ToInt32(resultado)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, mensagem = ex.Message });
            }
        }
    } 
}


using Api.Server.Interfaces;
using Api.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerController(
        ICalculatorService calculatorService
        ) : ControllerBase
    {

        [HttpGet]
        [Route("user")]
        public IActionResult Index()
        {
            int resultSum = calculatorService.SumNumbers(10, 20);
            dynamic result = new
            {
                name = "Eduardo",
                age = resultSum
            };

            return Ok(result);

        }
        [HttpGet]
        [Route("birth")]
        public IActionResult Index2()
        {
            dynamic result = new
            {
                flavor = "Morango",
                fabDate = new DateTime(2024,10,19)
            };

            return Ok(result);

        }
    }
}

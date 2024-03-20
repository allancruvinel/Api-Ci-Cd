using Api.Server.Interfaces;

namespace Api.Server.Services
{
    public class CalculatorService() : ICalculatorService
    {
        public int SumNumbers(int x, int y)
        {
            return x + y;
        }
    }
}

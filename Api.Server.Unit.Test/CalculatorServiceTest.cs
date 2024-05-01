using Api.Server.Interfaces;
using Api.Server.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Server.Unit.Test
{
    public class CalculatorServiceTest
    {
        //Mock<ICalculatorService> _calculatorServiceMock;
        private CalculatorService _calculatorService;
        public CalculatorServiceTest() {
            //_calculatorServiceMock = new Mock<ICalculatorService>();
            //_calculatorService = new CalculatorService(_calculatorServiceMock.Object);
            _calculatorService = new CalculatorService();
        }

        [Theory]
        [InlineData(5,5)]
        [InlineData(4, 6)]
        [InlineData(3, 7)]
        public void SumNumberTest(int a, int b)
        {
            int result = _calculatorService.SumNumbers(a, b);

            Assert.Equal(10, result);

        }
    }
}

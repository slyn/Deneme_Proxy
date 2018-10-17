using System;
using System.Collections.Generic;
using System.Text;

namespace Deneme_DispatchProxy_Decorate
{
    public class CalculatorFactory
    {
        private readonly ILogger _logger;
        public CalculatorFactory(ILogger logger)
        {
            _logger = logger;
        }
        public ICalculator CreateCalculator()
        {
            return LoggingAdvice<ICalculator>.Create(
                new Calculator(),
                s => _logger.Log("Info:" + s),
                s => _logger.Log("Error:" + s),
                o => o?.ToString());
        }
    }
}

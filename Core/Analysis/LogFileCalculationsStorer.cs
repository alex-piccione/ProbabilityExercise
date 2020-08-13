using System;
using Probability.Core.Contracts;
using Probability.Core.Models;

using Serilog;
using Serilog.Formatting.Json;

namespace Probability.Core.Analysis
{

    public class LogFileCalculationsStorer : ICalculationStorer
    {
        ILogger logger;

        public LogFileCalculationsStorer(string logDirectory) {

            InitializeLogger(logDirectory);
        }

        private void InitializeLogger(string logDirectory)
        {
            var fileSizeLimit = (10L * 1024L * 1024L); // 10 MB
            var flushInterval = TimeSpan.FromSeconds(5);

            logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(new JsonFormatter(), logDirectory, Serilog.Events.LogEventLevel.Information,
                    fileSizeLimit, null, buffered: false, shared: false, flushInterval, RollingInterval.Day)
                .CreateLogger();

            Jil.JSON.SetDefaultOptions(Jil.Options.ISO8601);
        }
                

        public void StoreCalculation(ExecutedCalculation calculation)
        {            
            logger.Information(Jil.JSON.Serialize(calculation));
        }
    }
}

using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Diagnostics.EventFlow;
using Microsoft.Diagnostics.EventFlow.Inputs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EventFlowFunctionApp1
{
    public static class Function1
    {
        static Function1()
        {
            ApplicationHelper.Startup();
        }

        [FunctionName("Function1")]
        public static void Run([TimerTrigger("00:00:03")]TimerInfo myTimer, TraceWriter log)
        {
            string folder = @"C:\Rot\EventFlowFunctionApp1\EventFlowFunctionApp1\bin\Debug\net47\";
            using (var diagnosticsPipeline = DiagnosticPipelineFactory.CreatePipeline(Path.Combine(folder, "eventFlowConfig.json")))
            {
                // Configure logging
                var loggerFactory = new LoggerFactory()
                    .AddEventFlow(diagnosticsPipeline);
                IServiceProvider serviceProvider = new ServiceCollection()
                    .AddSingleton<ILoggerFactory>(loggerFactory)
                    .BuildServiceProvider();
                ILogger logger = loggerFactory.CreateLogger(typeof(Function1));
                logger.LogInformation("Some log item");
                log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            }
        }
    }
}

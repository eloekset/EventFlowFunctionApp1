# EventFlowFunctionApp1
Repo to reproduce issue using EventFlow and EntityFramework.Core 2.0.1 in an Azure Function App.

Run the Azure Function App from Visual Studio to see the behavior.
- When running from the master branch, an error pops up in the console every time the function is triggered. It says:
*Method not found: 'Microsoft.Extensions.Logging.ILoggerFactory Microsoft.Diagnostics.EventFlow.Inputs.LoggerFactoryExtensions.AddEventFlow(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Diagnostics.EventFlow.DiagnosticPipeline)'.*
- When running from the feature/FixRuntimeError branch, the function runs just fine.

The only difference between the two branches is the version of Microosft.Extensions.Logging, which is 2.0.0 when it fails and 1.1.1 when it works.

A depencency on Microsoft.EntityFrameworkCore 2.0.1 is incompatible with Microsoft.Extensions.Logging 1.1.1.


# EventFlowFunctionApp1
Repo to reproduce issue using EventFlow and EntityFramework.Core 2.0.1 in an Azure Function App.

A depencency on Microsoft.EntityFrameworkCore 2.0.1 is incompatible with Microsoft.Extensions.Logging 1.1.1.

Run the Azure Function App from Visual Studio to see the behavior.
- When running from the master branch, an error pops up in the console every time the function is triggered. It says:
*Method not found: 'Microsoft.Extensions.Logging.ILoggerFactory Microsoft.Diagnostics.EventFlow.Inputs.LoggerFactoryExtensions.AddEventFlow(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Diagnostics.EventFlow.DiagnosticPipeline)'.*
- When running from the feature/FixRuntimeError branch, the function runs just fine. Microsoft.Extensions.Logging has been downgraded to 1.1.1 in this branch, while it is 2.0.0 in the master branch.
- Explicit binding redirect workaround for Azure Functions in feature/ExplicitBindingRedirect. It doesn't solve the issue, and a breakpoint inside the anonymous AssemblyBindingRedirectHelper.RedirectAssembly method doesn't get hit for some reason. Implementation is based on this blog post, and it has helped me with a similar issue in another Azure Function project: https://codopia.wordpress.com/2017/07/21/how-to-fix-the-assembly-binding-redirect-problem-in-azure-functions/

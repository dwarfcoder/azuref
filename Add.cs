using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Globalization;

namespace AzureF.Function
{
    public static class Add
    {
        [FunctionName("Add")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // TODO: change to custom input object
            var p1 = req.Query["p1"];
            var p2 = req.Query["p2"];

            // TODO: replace with validation
            if(!float.TryParse(p1, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var a1)){
                return new BadRequestObjectResult("Please pass float parameter1 on the query string");
            }

            if(!float.TryParse(p2, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var a2)){
                return new BadRequestObjectResult("Please pass float parameter2 on the query string");
            }

            // TODO: Should be refactored. Dependency Injection must be implemented
            ICalculator calc = new Calculator();

            var res = calc.Add(a1, a2);

            return (ActionResult)new OkObjectResult(res);
        }
    }
}

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
using AzureF.Function.Models;

namespace AzureF.Function
{
    public static class Add
    {
        [FunctionName("Add")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] AdditionOperands req,
            ILogger log)
        {
            // TODO: catch that bind errors
            
            log.LogInformation("C# HTTP trigger function processed a request.");

            // TODO: Should be refactored. Dependency Injection must be implemented
            ICalculator calc = new Calculator();

            var res = calc.Add(req.P1, req.P2);

            return (ActionResult)new OkObjectResult(res);
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureF.Function.Models;

namespace AzureF.Function
{
    public static class Divide
    {
        [FunctionName("Divide")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] AdditionOperands req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            ICalculator calc = new Calculator();

            if(req.P2 == 0)
            {
                return new BadRequestObjectResult("Division by zero is not allowed in this country");
            }

            var res = calc.Divide(req.P1, req.P2);

            return (ActionResult)new OkObjectResult(res);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp.ViewModels;

namespace TestMakerFreeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        // GET api/result/all
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId)
        {
            var sampleResults = new List<ResultViewModel>();

            // add a first sample result
            sampleResults.Add(new ResultViewModel
            {
                Id = 1,
                QuizId = quizId,
                Text = "This is the first result",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            // add a bunch of other sample results
            for (int i = 2; i<=5; i++)
            {
                sampleResults.Add(new ResultViewModel
                {
                    Id = i,
                    QuizId = quizId,
                    Text = $"Sample Result {i}",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            // output the result in JSON format
            return new JsonResult(sampleResults, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}

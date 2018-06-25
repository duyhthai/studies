using System;
using System.Linq;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestMakerFreeWebApp.Data;
using TestMakerFreeWebApp.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestMakerFreeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        #region Private Fields
        private ApplicationDbContext Dbcontext;
        #endregion

        #region Constructor
        public QuizController(ApplicationDbContext context)
        {
            // Instantiate the ApplicationDbContext through DI
            Dbcontext = context;
        }
        #endregion

        #region RESTful conventions methods
        /// <summary>
        /// GET: api/quiz/{}id
        /// Retrieves the Quiz with the given {id}
        /// </summary>
        /// <param name="id">The ID of an existing Quiz</param>
        /// <returns>the Quiz with the given {id}</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quiz = Dbcontext.Quizzes.Where(i => i.Id == id).FirstOrDefault();

            // handle requests asking for non-existing quizzes
            if (quiz == null)
            {
                return NotFound(new
                {
                    Error = $"Quiz ID {id} has not been found"
                });
            }

            return new JsonResult(quiz.Adapt<QuizViewModel>(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Adds a new Quiz to the Database
        /// </summary>
        /// <param name="model">The QuizViewModel containing the data to insert</param>
        [HttpPut]
        public IActionResult Put([FromBody]QuizViewModel model)
        {
            // return a generic HTTP status 500 (Server Error)
            // if the client payload is invalid.
            if (model == null) return new StatusCodeResult(500);

            // handle the insert (without object-mapping)
            // properties taken from the request
            var quiz = new Quiz
            {
                Title = model.Title,
                Description = model.Description,
                Text = model.Text,
                Notes = model.Notes
            };

            // properties taken from server-side
            quiz.CreatedDate = DateTime.Now;
            quiz.LastModifiedDate = quiz.CreatedDate;

            // Set a temporary author using the Admin user's userId
            // as user login isn't supported yet: we'll change this later on
            quiz.UserId = Dbcontext.Users.Where(u => u.UserName == "Admin").FirstOrDefault().Id;

            // add the new quiz
            Dbcontext.Quizzes.Add(quiz);
            Dbcontext.SaveChanges();

            // return the newly-created Quiz to the client.
            return new JsonResult(quiz.Adapt<QuizViewModel>(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Edit the Quiz with the given {id}
        /// </summary>
        /// <param name="model">The QuizViewModel containing the data to update</param>
        [HttpPost]
        public IActionResult Post([FromBody]QuizViewModel model)
        {
            // return a generic HTTP status 500 (Server Error)
            // if the client payload is invalid.
            if (model == null) return new StatusCodeResult(500);

            // retrieve the quiz to edit
            var quiz = Dbcontext.Quizzes.Where(q => q.Id == model.Id).FirstOrDefault();

            // handle requests asking for non-existing quizzes
            if (quiz == null)
            {
                return NotFound(new { Error = $"Quiz ID {model.Id} has not been found" });
            }

            // handle the update (without object-mapping)
            // by manually assigning the properties
            // we want to accept from the request
            quiz.Title = model.Title;
            quiz.Description = model.Description;
            quiz.Text = model.Text;
            quiz.Notes = model.Notes;

            // properties set from server-side
            quiz.LastModifiedDate = DateTime.Now;

            // persit the changes into the Database.
            Dbcontext.SaveChanges();

            // return the updated Quiz to the client.
            return new JsonResult(quiz.Adapt<QuizViewModel>(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Deletes the Quiz with the given {id} from the Database
        /// </summary>
        /// <param name="id">The ID of an existing Test</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // retrieve the quiz from the Database
            var quiz = Dbcontext.Quizzes.Where(i => i.Id == id).FirstOrDefault();

            // handle requests asking for non-existing quizzes
            if (quiz == null)
            {
                return NotFound(new { Error = $"Quiz ID {id} has not been found" });
            }

            // remove the quiz from the DbContext.
            Dbcontext.Quizzes.Remove(quiz);
            Dbcontext.SaveChanges();

            // return an HTTP status 200 (OK)
            return new OkResult();
        }
        #endregion

        #region Attribute-based routing methods
        /// <summary>
        /// GET: api/quiz/latest
        /// Retrieves the {num} latest Quizzes
        /// </summary>
        /// <param name="num">the number of quizzes to retrieve</param>
        /// <returns>the {num} latest Quizzes</returns>
        [HttpGet("Latest/{num:int?}")]
        public IActionResult Latest(int num = 10)
        {
            var latest = Dbcontext.Quizzes.OrderByDescending(q => q.CreatedDate).Take(num).ToArray();
            return new JsonResult(latest.Adapt<QuizViewModel[]>(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get: api/quiz/ByTitle
        /// Retrievs the {num} Quizzes sorted by Title (A to Z)
        /// </summary>
        /// <param name="num">the number of quizzes to retrieve</param>
        /// <returns>{num} Quizzes sorted by Title</returns>
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10)
        {
            var byTitle = Dbcontext.Quizzes.OrderBy(q => q.Title).Take(num).ToArray();
            return new JsonResult(byTitle.Adapt<QuizViewModel[]>(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get: api/quiz/mostViewed
        /// Retrievs the {num} random Quizzes
        /// </summary>
        /// <param name="num">the number of quizzes to retrieve</param>
        /// <returns>{num} random Quizzes</returns>
        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10)
        {
            var random = Dbcontext.Quizzes.OrderBy(q => Guid.NewGuid()).Take(num).ToArray();
            return new JsonResult(random.Adapt<QuizViewModel[]>(), new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
        #endregion
    }
}

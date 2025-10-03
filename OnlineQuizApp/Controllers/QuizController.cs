using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineQuizApp.Helper;
using OnlineQuizApp.Model.DBModel;
using OnlineQuizApp.Services.Interfaces;

namespace OnlineQuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ILogger<QuizController> _logger;
        private readonly IQuizService _quizService;
        private readonly ApiResponse _apiResponse;
        public QuizController(IQuizService quizService,ILogger<QuizController> logger)
        {
            _logger = logger;
            _quizService = quizService;
            _apiResponse= new ApiResponse();
        }

        [HttpPost]  
        public async Task<IActionResult> AddQuestion([FromBody]Question question)
        {
            _logger.LogInformation("---------------------------------------Start Of addQuestion Controller Method---------------------------------");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                if (question == null)
                {
                    _apiResponse.status = false;
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.Data = null;
                    return BadRequest(_apiResponse);
                }
                 await _quizService.AddQuestionAsync(question);
                _apiResponse.status = true;
                _apiResponse.Data = question;
                _apiResponse.StatusCode = HttpStatusCode.Created;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error occured in addQuestion Action method");
                _apiResponse.Data = null;
                _apiResponse.status = false;
                _apiResponse.Errors.Add(new ExceptionMessage
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                });
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, _apiResponse);
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation("addQuestion Action Method completed in : {ElapsedMilliseconds} ms", stopwatch.ElapsedMilliseconds);
                _logger.LogInformation("--------------------------------------End Of addQuestion Controller Method-----------------------------");
            }
        }

        [HttpGet("{quizId}")]
        public async Task<IActionResult> GetAllQuestions(string quizId)
        {
            _logger.LogInformation("---------------------------------------Start Of GetAllQuestions Controller Method---------------------------------");
            var stopwatch = Stopwatch.StartNew();
            try
            {
                
                 var questions= await _quizService.GetAllQuestionsAsync(quizId);
                _apiResponse.status = true;
                _apiResponse.Data = questions;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error occured in GetAllQuestions Action method");
                _apiResponse.Data = null;
                _apiResponse.status = false;
                _apiResponse.Errors.Add(new ExceptionMessage
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                });
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, _apiResponse);
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation("GetAllQuestions Action Method completed in : {ElapsedMilliseconds} ms", stopwatch.ElapsedMilliseconds);
                _logger.LogInformation("--------------------------------------End Of GetAllQuestions Controller Method-----------------------------");
            }

        }
        [HttpPost(("{quizId}"))]
        public async Task<IActionResult> GetResult(string quizId, [FromBody] List<Answer> answers )
        {
            _logger.LogInformation("---------------------------------------Start Of GetResult Controller Method---------------------------------");
            var stopwatch = Stopwatch.StartNew();
            try
            {

                var result = await _quizService.GetResultAsync(quizId,answers);
                _apiResponse.status = true;
                _apiResponse.Data = result;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Error occured in GetResult Action method");
                _apiResponse.Data = null;
                _apiResponse.status = false;
                _apiResponse.Errors.Add(new ExceptionMessage
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                });
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, _apiResponse);
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation("GetResult Action Method completed in : {ElapsedMilliseconds} ms", stopwatch.ElapsedMilliseconds);
                _logger.LogInformation("--------------------------------------End Of GetResult Controller Method-----------------------------");
            }

        }
    }
}

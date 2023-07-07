using Microsoft.AspNetCore.Mvc;
using QuizAPI.Dtos;
using QuizAPI.Entities;
using QuizAPI.Respositories;
using System.Linq;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _repository;

        public QuestionsController(IQuestionRepository repository) 
        { 
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Question>>> Get_All_Questions ()
        {      
            var questions = await _repository.GetAll();
            return Ok(questions);
        }

        [HttpGet("{id}/answer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Answer>> Get_Question_With_Answer(int id)
        {
            var question = await _repository.Get(id);
            if(question == null)
            {
                return NotFound();
            }

            var answer = await _repository.GetAnswerAsync(question);
            return Ok(answer);
        }
    }
}

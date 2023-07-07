using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Dtos;
using QuizAPI.Entities;
using QuizAPI.Respositories;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizsController : ControllerBase
    {
        private readonly IQuizRepository _repository;

        public QuizsController(IQuizRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Quiz>>> Get_All_Quizes()
        {
            var quizzes = await _repository.GetAll();
            return Ok(quizzes);
        }


        [HttpGet("{id}/quizinfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Answer>> Get_Quiz_ById(int id)
        {
            var quiz = await _repository.Get(id);
            if (quiz == null)
            {
                return NotFound();
            }
      
            return Ok(quiz);        
        }

        [HttpGet("{id}/answer2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Answer>> Get_Quiz(int id)
        {
            var quiz = await _repository.Getq_Qiz(id);
            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

    }
}

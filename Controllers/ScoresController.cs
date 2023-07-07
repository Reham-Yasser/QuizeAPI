using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Dtos;
using QuizAPI.Entities;
using QuizAPI.Respositories;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private IScoreRepository _repository;

        public ScoresController(IScoreRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Post(ScoreCreateDto dtoModel)
        {
            var score = await _repository.Insert(dtoModel);
            return Ok(score);
        }

        

    }
}

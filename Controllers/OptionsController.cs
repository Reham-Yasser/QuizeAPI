﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuizAPI.Entities;
using QuizAPI.Respositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private IRepository<Option> _repository;
        public OptionsController(IRepository<Option> repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Option>>> Get()
        {
            var options = await _repository.GetAll();
            return Ok(options);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Option>> Get(int id)
        {
            if(id < 0)
            {
                return NotFound();
            }

            return Ok(await _repository.Get(id));
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        /// <summary>
        /// Get all notes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Note controller works");
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(string id)
        {
            return Ok(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            return Ok(note);
        }

        [HttpPut("{id}")]
        public IActionResult Post(string id, [FromBody] Note note)
        {
            return Ok(note);
        }

        //[HttpGet]
        //public IActionResult Get([FromQuery] string queryParam1)
        //{
        //    return Ok(queryParam1);
        //}

        //[HttpGet]
        //public IActionResult Get([FromHeader] string Accept)
        //{
        //    return Ok(Accept);
        //}

        //[HttpGet]
        //public IActionResult Get([FromHeader(Name = "User-Agent")] string UserAgent)
        //{
        //    return Ok(UserAgent);
        //}





    }
}

    


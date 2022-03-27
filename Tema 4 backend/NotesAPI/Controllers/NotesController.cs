using NotesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System; 
using System.Linq;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        static List<Note> _notes = new List<Note> {
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "First Note", Description = "First Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Fifth Note", Description = "Fifth Note Description" }

        };

        /// <summary>
        /// Get all notes.
        /// </summary>
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notes);
        }

        /// <summary>
        /// Add a new note.
        /// </summary>
        /// <response code="200">Success creating one note.</response>
        /// <response code="201">Success getting location header in post response.</response>
        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            _notes.Add(note);
            //return CreatedAtRoute("GetNoteById", new { id = note.Id.ToString() }, note);
            return Ok(note);
        }

        /// <summary>
        /// Get one note by OwnerId.
        /// </summary>
        /// <response code="200">Success getting one note from the list.</response>
        /// <response code="404">Getting the note failed because of invalid id.</response>
        /// <returns>Returns one note from the list</returns>
        [HttpGet("owner/{ownerId}")]
        public IActionResult GetNoteByOwnerId(Guid ownerId)
        {
            var note = _notes.FirstOrDefault(c => c.OwnerId == ownerId);
            if (note == null)
            {
                return NotFound($"Note with owner id {ownerId} not found");
            }

            return Ok(note);
        }

        /// <summary>
        /// Get one note by NoteId.
        /// </summary>
        /// <response code="200">Success getting one note from the list.</response>
        /// <response code="404">Getting the note failed because of invalid id.</response>
        /// <returns>Returns one note from the list</returns>
        [HttpGet("note/{noteId}", Name = "GetNoteById")]
        public IActionResult GetNoteById(Guid noteId)
        {
            var note = _notes.FirstOrDefault(c => c.Id == noteId);
            if (note == null)
            {
                return NotFound($"Note with id {noteId} not found");
            }

            return Ok(note);
        }


        /// <summary>
        /// Get all notes.
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok("Note controller works");
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetOne(string id)
        //{
        //    return Ok(id);
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody] Note note)
        //{
        //    return Ok(note);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Post(string id, [FromBody] Note note)
        //{
        //    return Ok(note);
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

        //[HttpGet]
        //public IActionResult Get([FromQuery] string queryParam1)
        //{
        //    return Ok(queryParam1);
        //}

    }
}

    


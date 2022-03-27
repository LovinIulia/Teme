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
        private static List<Note> _notes = new List<Note> { 
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
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
            if(note == null)
            {
                return BadRequest("Note is null");
            }
            _notes.Add(note);
            return CreatedAtRoute("GetNoteById", new { noteId = note.Id}, note);
            //return Ok(note);
        }

        /// <summary>
        /// Get one note by OwnerId.
        /// </summary>
        /// <response code="200">Success getting one note from the list.</response>
        /// <response code="404">Getting the note failed because of invalid id.</response>
        /// <returns>Returns one note from the list</returns>
        //[HttpGet("owner/{ownerId}")]
        //public IActionResult GetNoteByOwnerId(Guid ownerId)
        //{
        //    var note = _notes.FirstOrDefault(c => c.OwnerId == ownerId);
        //    if (note == null)
        //    {
        //        return NotFound($"Note with owner id {ownerId} not found");
        //    }

        //    return Ok(note);
        //}

        /// <summary>
        /// Get one note by NoteId.
        /// </summary>
        /// <response code="200">Success getting one note from the list.</response>
        /// <response code="404">Getting the note failed because of invalid id.</response>
        /// <returns>Returns one note from the list</returns>
        [HttpGet("{noteId}", Name = "GetNoteById")]
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
        /// Update note by NoteId.
        /// </summary>
        /// <response code="200">Success updating note.</response>
        /// <response code="404">Updating the note failed because of invalid id.</response>
        /// <returns>Updated note</returns>
        [HttpPut("note/{id}")]
        public IActionResult UpdateNoteById(Guid id, [FromBody] Note note)
        {
            if (note == null)
            {
                return NotFound($"Note with id {id} not found");
            }
            int index = _notes.FindIndex(n => n.Id == id);
            if(index == -1)
            {
                return CreateNote(note);
                //return NotFound("Index not found");
            }
            note.Id = id;
            _notes[index] = note;
            return Ok(_notes);
        }

        /// <summary>
        /// Update note by OwnerId.
        /// </summary>
        /// <response code="200">Success updating note.</response>
        /// <response code="404">Updating the note failed because of invalid id.</response>
        /// <returns>Updated note</returns>
        [HttpPut("owner/{ownerId}")]
        public IActionResult UpdateNoteByOwnerId(Guid ownerId, [FromBody] Note note)
        {
            if (note == null)
            {
                return NotFound($"Note with id {ownerId} not found");
            }
            note.OwnerId = ownerId;
            int index = _notes.FindIndex(n => n.OwnerId == ownerId);
            if (index == -1)
            {
                _notes.Add(note);
            }
            else
            {
                _notes[index] = note;
            }
            return Ok(_notes);
        }

        /// <summary>
        /// Delete note by NoteId.
        /// </summary>
        /// <response code="200">Success deleting note.</response>
        /// <response code="404">Deleting the note failed because of invalid id.</response>
        /// <returns>Ok. The note was deleted</returns>
        [HttpDelete("note/{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            int index = _notes.FindIndex(x => x.Id == id);
            if(index == -1)
            {
                return NotFound("The note doesn't exist");
            }

            _notes.RemoveAt(index);
            return Ok("The note was deleted");
        }

        /// <summary>
        /// Delete note by OwnerId.
        /// </summary>
        /// <response code="200">Success deleting note.</response>
        /// <response code="404">Deleting the note failed because of invalid id.</response>
        /// <returns>Ok. The note was deleted</returns>
        [HttpDelete("owner/{ownerId}")]
        public IActionResult DeleteNoteByOwnerId(Guid ownerId)
        {
            int index = _notes.FindIndex(x => x.OwnerId == ownerId);
            if (index == -1)
            {
                return NotFound("The note doesn't exist");
            }

            _notes.RemoveAt(index);
            return Ok("The note was deleted");
        }

        /// <summary>
        /// Delete all notes by OwnerId.
        /// </summary>
        /// <response code="200">Success deleting notes.</response>
        /// <response code="404">Deleting the notes failed because of invalid id.</response>
        /// <returns>Ok. The notes were deleted</returns>
        [HttpDelete("ownernotes/{ownerId}")]
        public IActionResult DeleteAllNotesByOwnerId(Guid ownerId)
        {
            _notes.RemoveAll(n => n.OwnerId == ownerId);
            return Ok("The notes were deleted");
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

    


using NotesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using NotesAPI.Services;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INoteCollectionService _noteCollectionService;
        public NotesController(INoteCollectionService noteCollectionService)
        {
            _noteCollectionService = noteCollectionService ?? throw new ArgumentNullException(nameof(noteCollectionService));
        }


        /// <summary>
        /// Get all notes.
        /// </summary>
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_noteCollectionService.GetAll());
        }

        /// <summary>
        /// Add a new note.
        /// </summary>
        /// <response code="200">Success creating one note.</response>
        /// <response code="201">Success getting location header in post response.</response>
        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note is null");
            }
            _noteCollectionService.Create(note);

            return CreatedAtRoute("GetNoteById", new { id = note.Id.ToString() }, note);

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
            var note = _noteCollectionService.GetNotesByOwnerId(ownerId);
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
            var note = _noteCollectionService.Get(noteId);
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
                return NotFound("Please provide Note body");
            }
            _noteCollectionService.Update(id, note);

            return Ok(note);
        }

        /// <summary>
        /// Update note by OwnerId.
        /// </summary>
        /// <response code="200">Success updating note.</response>
        /// <response code="404">Updating the note failed because of invalid id.</response>
        /// <returns>Updated note</returns>
        //[HttpPut("owner/{ownerId}")]
        //public IActionResult UpdateNoteByOwnerId(Guid ownerId, [FromBody] Note note)
        //{
        //    if (note == null)
        //    {
        //        return NotFound($"Note with id {ownerId} not found");
        //    }
        //    note.OwnerId = ownerId;
        //    int index = _notes.FindIndex(n => n.OwnerId == ownerId);
        //    if (index == -1)
        //    {
        //        _notes.Add(note);
        //    }
        //    else
        //    {
        //        _notes[index] = note;
        //    }
        //    return Ok(_notes);
        //}

        /// <summary>
        /// Delete note by NoteId.
        /// </summary>
        /// <response code="200">Success deleting note.</response>
        /// <response code="404">Deleting the note failed because of invalid id.</response>
        /// <returns>Ok. The note was deleted</returns>
        [HttpDelete("note/{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            return Ok(_noteCollectionService.Delete(id));
        }

        /// <summary>
        /// Delete note by OwnerId.
        /// </summary>
        /// <response code="200">Success deleting note.</response>
        /// <response code="404">Deleting the note failed because of invalid id.</response>
        /// <returns>Ok. The note was deleted</returns>
        //[HttpDelete("owner/{ownerId}")]
        //public IActionResult DeleteNoteByOwnerId(Guid ownerId)
        //{
        //    int index = _notes.FindIndex(x => x.OwnerId == ownerId);
        //    if (index == -1)
        //    {
        //        return NotFound("The note doesn't exist");
        //    }

        //    _notes.RemoveAt(index);
        //    return Ok("The note was deleted");
        //}

        /// <summary>
        /// Delete all notes by OwnerId.
        /// </summary>
        /// <response code="200">Success deleting notes.</response>
        /// <response code="404">Deleting the notes failed because of invalid id.</response>
        /// <returns>Ok. The notes were deleted</returns>
        //[HttpDelete("owner/{ownerId}")]
        //public IActionResult DeleteAllNotesByOwnerId(Guid ownerId)
        //{
        //    _notes.RemoveAll(n => n.OwnerId == ownerId);
        //    return Ok("The notes were deleted");
        //}




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




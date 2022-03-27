using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using NotesAPI.Models;


namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private static List<Owner> _owners = new List<Owner>() 
        { 

        };

        /// <summary>
        /// Get all owners.
        /// </summary>
        /// <response code="200">Success getting the list of owners.</response>
        /// <returns>Returns the list of owners</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_owners);
        }

        /// <summary>
        /// Add a new owner.
        /// </summary>
        /// <response code="200">Success adding owner in list.</response>
        /// <response code="403">Getting the owner in the list failed because of duplicated owner.</response>
        /// <returns>The new owner's id.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            var owner = new Owner()
            {
                Name = name,
                Id = Guid.NewGuid()
            };

            if (_owners.Any(item => item.Id == owner.Id || item.Name == owner.Name))
            {
                return Forbid("Duplicated owner");
            }
            _owners.Add(owner);
            return Ok(owner.Id);
        }

        /// <summary>
        /// Update owner.
        /// </summary>
        /// <response code="200">Success updating owner in list.</response>
        /// <response code="404">Updating owner failed because the id wasn't found.</response>
        /// <returns>Updated owner.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest("Invalid name provided");
            }

            int index = _owners.FindIndex(n => n.Id == id);
            if (index == -1)
            {
                var newRecord = new Owner()
                {
                    Id = Guid.NewGuid(),
                    Name = name
                };
                _owners.Add(newRecord);
                index = _owners.Count - 1;
            } else
            {
                _owners[index].Name = name;
            }

            return Ok(_owners[index]);
        }

        /// <summary>
        /// Delete owner.
        /// </summary>
        /// <response code="200">Success deleting owner in list.</response>
        /// <response code="404">Deleting owner failed because he doesn't exist in the list.</response>
        /// <returns>The owner was deleted.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            int index = _owners.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return NotFound("The owner doesn't exist");
            }

            _owners.RemoveAt(index);
            return Ok("The owner was deleted");
        }
    }
}

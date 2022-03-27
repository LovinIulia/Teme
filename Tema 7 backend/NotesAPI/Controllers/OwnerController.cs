using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using NotesAPI.Models;
using NotesAPI.Services;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        IOwnerCollectionService _ownerCollectionService;
        public OwnerController(IOwnerCollectionService ownerCollectionService)
        {
            _ownerCollectionService = ownerCollectionService ?? throw new ArgumentNullException(nameof(ownerCollectionService));
        }

        /// <summary>
        /// Get all owners.
        /// </summary>
        /// <response code="200">Success getting the list of owners.</response>
        /// <returns>Returns the list of owners</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ownerCollectionService.GetAll());
        }

        /// <summary>
        /// Add a new owner.
        /// </summary>
        /// <response code="200">Success adding owner in list.</response>
        /// <response code="403">Getting the owner in the list failed because of duplicated owner.</response>
        /// <returns>The new owner's id.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            var owner = new Owner()
            {
                Name = name
            };

            var result = await _ownerCollectionService.Create(owner);
            if (result == false)
            {
                return Forbid("Duplicated owner");
            }
            return Ok(owner.Name);
        }

        /// <summary>
        /// Update owner.
        /// </summary>
        /// <response code="200">Success updating owner in list.</response>
        /// <response code="404">Updating owner failed because the id wasn't found.</response>
        /// <returns>Updated owner.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(string id, [FromBody] Owner owner)
        {
            if (owner == null)
            {
                return NotFound($"Owner with id {id} not found");
            }

            await _ownerCollectionService.Update(id, owner);

            return Ok(owner);

            //owner.Id = id;
            //int index = _owners.FindIndex(n => n.Id == id);
            //if (index == -1)
            //{
            //    _owners.Add(owner);
            //} else
            //{
            //    _owners[index] = owner;
            //}
            //return Ok(_owners);
        }

        /// <summary>
        /// Delete owner.
        /// </summary>
        /// <response code="200">Success deleting owner in list.</response>
        /// <response code="404">Deleting owner failed because he doesn't exist in the list.</response>
        /// <returns>The owner was deleted.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(string id)
        {
            bool ok = await _ownerCollectionService.Delete(id);
            if (!ok)
            {
                return NotFound("Note not found");
            }
            return Ok("Note was deleted");
            //int index = _owners.FindIndex(x => x.Id == id);
            //if (index == -1)
            //{
            //    return NotFound("The owner doesn't exist");
            //}
            //return Ok(_ownerCollectionService.Delete(id));
        }
    }
}

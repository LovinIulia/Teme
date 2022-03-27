using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}

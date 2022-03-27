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
            new Owner(){OwnerId = Guid.NewGuid(), Name = "Mary"},
            new Owner(){OwnerId = Guid.NewGuid(), Name = "John"},
            new Owner(){OwnerId = Guid.NewGuid(), Name = "Jack"},

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
        /// <returns>200 Ok successful</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Owner owner)
        {
            if (_owners.Any(item => item.OwnerId == owner.OwnerId || item.Name == owner.Name))
            {
                return Forbid("Duplicated owner");
            }
            _owners.Add(owner);
            return Ok("Successfully added");
        }
    }
}

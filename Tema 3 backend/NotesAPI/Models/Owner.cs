using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Models
{
    public class Owner
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
    }
}

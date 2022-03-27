using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesAPI.Models;

namespace NotesAPI.Services
{
    public interface INoteCollectionService : ICollectionService<Note>
    {
        Task<List<Note>> GetNotesByOwnerId(string ownerId);
    }
}

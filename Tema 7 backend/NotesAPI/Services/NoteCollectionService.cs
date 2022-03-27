using MongoDB.Bson;
using MongoDB.Driver;
using NotesAPI.Models;
using NotesAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Services
{
    public class NoteCollectionService : INoteCollectionService
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _notes = database.GetCollection<Note>(settings.NoteCollectionName);
        }

        public async Task<Note> Get(string noteId)
        {
            return (await _notes.FindAsync(note => note.Id == noteId)).FirstOrDefault();
        }

        public async Task<List<Note>> GetAll()
        {
            var result = await _notes.FindAsync(note => true);
            return result.ToList();
        }

        public async Task<bool> Create(Note note)
        {
            if(string.IsNullOrEmpty(note.Id))
            {
                note.Id = Guid.NewGuid().ToString();
            }
            await _notes.InsertOneAsync(note);
            return true;
        }

        public async Task<bool> Update(string id, Note note)
        {
            note.Id = id;
            var result = await _notes.ReplaceOneAsync(note => note.Id == id, note);
            if(!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _notes.InsertOneAsync(note);
                return false;
            }
            return true;
        }

        public async Task<List<Note>> GetNotesByOwnerId(string ownerId)
        { 
            return (await _notes.FindAsync(note => note.OwnerId == ownerId)).ToList();
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _notes.DeleteOneAsync(note => note.Id == id);
            if (result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
            
        }


        //Task<List<Note>> INoteCollectionService.GetNotesByOwnerId(Guid ownerId)
        //{
        //    throw new NotImplementedException();
        //}

        //private static List<Note> _notes = new List<Note> {
        //new Note { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        //new Note { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        //new Note { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        //new Note { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        //new Note { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
        //};

        //public NoteCollectionService()
        //{

        //}

        //public bool Create(Note note)
        //{
        //    _notes.Add(note);
        //    return true;
        //}

        //public bool Delete(Guid id)
        //{
        //    int index = _notes.FindIndex(x => x.Id == id);
        //    _notes.RemoveAt(index);
        //    return true;
        //}


        //public List<Note> GetNotesByOwnerId(Guid ownerId)
        //{
        //    var note = _notes.FirstOrDefault(c => c.OwnerId == ownerId);
        //    return _notes;
        //}

        //public bool Update(Guid id, Note note)
        //{
        //    int index = _notes.FindIndex(n => n.Id == id);
        //    if (index == -1)
        //    {
        //        return Create(note);
        //    }

        //    note.Id = id;
        //    _notes[index] = note;
        //    return true;
        //}  

    }
}

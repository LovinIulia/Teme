using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using NotesAPI.Models;
using NotesAPI.Settings;

namespace NotesAPI.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {
        private readonly IMongoCollection<Owner> _owners;

        public OwnerCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _owners = database.GetCollection<Owner>(settings.OwnerCollectionName);
        }

        public OwnerCollectionService() { }

        public async Task<bool> Create(Owner owner)
        {
            owner.Id = Guid.NewGuid().ToString();
            await _owners.InsertOneAsync(owner);
            return true;
            //owner.Id = Guid.NewGuid();
            //if (_owners.Any(item => item.Id == owner.Id || item.Name == owner.Name))
            //{
            //    return false;
            //}
            //_owners.Add(owner);
            //return true;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _owners.DeleteOneAsync(x => x.Id == id);
            if (result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
            //int index = _owners.FindIndex(x => x.Id == id);
            //_owners.RemoveAt(index);
            //return true;
        }

        public async Task<Owner> Get(string id)
        {
            var result = await _owners.FindAsync(n => n.Id == id);
            if (result.ToList().Count == 0)
            {
                return null;
            }
            return result.ToList()[0];
        }

        public async Task<List<Owner>> GetAll()
        {
            var result = await _owners.FindAsync(owner => true);
            return result.ToList();
        }

        public async Task<bool> Update(string id, Owner owner)
        {
            owner.Id = id;
            var result = await _owners.ReplaceOneAsync(n => n.Id == id, owner);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _owners.InsertOneAsync(owner);
                return false;
            }
            return true;

            //owner.Id = id;
            //int index = _owners.FindIndex(n => n.Id == id);
            //if (index == -1)
            //{
            //    _owners.Add(owner);
            //}
            //else
            //{
            //    _owners[index] = owner;
            //}

            //return true;
        }
    }
}

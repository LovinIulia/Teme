using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesAPI.Models;

namespace NotesAPI.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {
        private static List<Owner> _owners = new List<Owner>()
        {

        };

        public OwnerCollectionService() { }

        public bool Create(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            if (_owners.Any(item => item.Id == owner.Id || item.Name == owner.Name))
            {
                return false;
            }
            _owners.Add(owner);
            return true;
        }

        public bool Delete(Guid id)
        {
            int index = _owners.FindIndex(x => x.Id == id);
            _owners.RemoveAt(index);
            return true;
        }

        public Owner Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetAll()
        {
            return _owners;
        }

        public bool Update(Guid id, Owner owner)
        {
            owner.Id = id;
            int index = _owners.FindIndex(n => n.Id == id);
            if (index == -1)
            {
                _owners.Add(owner);
            }
            else
            {
                _owners[index] = owner;
            }

            return true;
        }
    }
}

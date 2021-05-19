using System;
using System.Collections.Generic;
using castle.Models;
using castle.Repositories;


namespace castle.Services
{
    public class KnightsService
    {
        private readonly KnightsRepository _repo;

        public KnightsService(KnightsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Knight> GetAll()
        {
            return _repo.GetAll();
        }

        internal Knight GetById(int id)
        {
            Knight knight = _repo.GetById(id);
            if (knight == null)
            {
                throw new Exception("Invalid Id");
            }
            return knight;
        }

        internal Knight Create(Knight newKnight)
        {
            Knight knight = _repo.Create(newKnight);
            return knight;
        }

        internal Knight Update(Knight update)
        {
            Knight original = GetById(update.Id);
            if (_repo.Update(original))
            {
                return original;
            }
            throw new Exception("Something Went Wrong???");
        }

        internal void DeleteKnight(int id)
        {
            GetById(id);
            _repo.Delete(id);
        }
    }
}
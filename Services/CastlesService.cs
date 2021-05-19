using System;
using System.Collections.Generic;
using castle.Models;
using castle.Repositories;

namespace castle.Services
{
    public class CastlesService
    {
        private readonly CastlesRepository _repo;

        public CastlesService(CastlesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Castle> GetAll()
        {
            return _repo.GetAll();
        }

        internal Castle GetById(int id)
        {
            Castle castle = _repo.GetById(id);
            if (castle == null)
            {
                throw new Exception("Invalid Id");
            }
            return castle;
        }

        internal Castle Create(Castle newCastle)
        {
            Castle castle = _repo.Create(newCastle);
            return castle;
        }

        internal Castle Update(Castle update)
        {
            Castle original = GetById(update.Id);
            original.Name = update.Name.Length > 0 ? update.Name : original.Name;
            original.BirthYear = update.BirthYear > 0 ? update.BirthYear : original.BirthYear;
            original.DeathYear = update.DeathYear > 0 ? update.DeathYear : original.DeathYear;
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
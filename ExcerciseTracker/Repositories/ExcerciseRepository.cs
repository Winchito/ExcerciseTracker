using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcerciseTracker.Data;
using ExcerciseTracker.Models;
using ExcerciseTracker.Repositories.IRepository;

namespace ExcerciseTracker.Repositories
{
    internal class ExcerciseRepository: IExcerciseRepository
    {
        private readonly ExcerciseContext _db;

        public ExcerciseRepository(ExcerciseContext db)
        {
            _db = db;
        }

        public void CreateCategory(Excercise excercise) => _db.Add(excercise);

        public void DeleteCategory(int id)
        {
            var excercise = _db.Excercises.FirstOrDefault(e => e.Id == id);
            _db.Excercises.Remove(excercise);
        }

        public bool ExcerciseExists(int excerciseId) => _db.Excercises.Any(e => e.Id == excerciseId);
        

        public ICollection<Excercise> GetExcercises()
        {
            var excercises = _db.Excercises.ToList();
            return excercises;
        }

        public bool Save() => _db.SaveChanges() >= 0 ? true : false;


        public void UpdateCategory(int id, Excercise newExcercise)
        {
            var oldExcercise = _db.Excercises.Single(e => e.Id == id);

            oldExcercise.DateStart = newExcercise.DateStart;
            oldExcercise.DateEnd = newExcercise.DateEnd;
            oldExcercise.Duration = newExcercise.Duration;
            
            if(newExcercise.comments != "")
            {
                oldExcercise.comments = newExcercise.comments;
            } 

        }
    }
}

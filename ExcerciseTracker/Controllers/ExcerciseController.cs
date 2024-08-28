using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcerciseTracker.Models;
using ExcerciseTracker.Repositories.IRepository;

namespace ExcerciseTracker.Controllers
{
    internal class ExcerciseController
    {
        private readonly IExcerciseRepository _excerciseRepository;

        public ExcerciseController(IExcerciseRepository excerciseRepository)
        {
            _excerciseRepository = excerciseRepository;
        }

        public bool AddExcerciseRecordToDb(Excercise excercise)
        {
            _excerciseRepository.CreateCategory(excercise);

            if (_excerciseRepository.Save())
            {
                return true;
            }

            return false;
        }

        public List<Excercise> GetExcercises()
        {
            var excercisesList = _excerciseRepository.GetExcercises();

            return excercisesList.ToList();

        }

        public bool CheckRecordIdInDb(int id) => _excerciseRepository.ExcerciseExists(id);

        public bool UpdateRecordToDb(int id, Excercise excercise)
        {
            _excerciseRepository.UpdateCategory(id, excercise);

            if (_excerciseRepository.Save())
            {
                return true;
            }
            return false;
        }

        public bool DeleteRecordToDb(int id)
        {
            _excerciseRepository.DeleteCategory(id);

            if (_excerciseRepository.Save())
            {
                return true;
            }
            return false;
        }
    }
}

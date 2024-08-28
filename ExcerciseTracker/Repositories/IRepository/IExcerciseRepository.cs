using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcerciseTracker.Models;

namespace ExcerciseTracker.Repositories.IRepository
{
    internal interface IExcerciseRepository
    {
        ICollection<Excercise> GetExcercises();
        bool ExcerciseExists(int excerciseId);
        void CreateCategory(Excercise excercise);
        void UpdateCategory(int id, Excercise excercise);
        void DeleteCategory(int id);
        bool Save();
    }
}

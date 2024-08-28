using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcerciseTracker.Controllers;
using ExcerciseTracker.Models;

namespace ExcerciseTracker.Services
{
    internal class ExcerciseService
    {
        private readonly ExcerciseController _excerciseController;
        public ExcerciseService(ExcerciseController excerciseController) 
        {
            _excerciseController = excerciseController;
        }

        public void CreateExcerciseRecord(Excercise excerciseRecord)
        {
            if (excerciseRecord == null)
            {
                Console.WriteLine("There was an error creating a Excercise record! ");
                return;
            }

            bool operation = _excerciseController.AddExcerciseRecordToDb(excerciseRecord);

            if (operation)
            {
                Console.WriteLine("Record created!");
                return;
            }
            Console.WriteLine("There was an error creating a Excercise record! ");
            return;
        }

        public void ShowExcerciseRecords()
        {
            Console.WriteLine();
            var excercises = _excerciseController.GetExcercises();

            foreach (var item in excercises)
            {
                Console.Write($"Id: {item.Id} | Start Date: {item.DateStart} | End Date: {item.DateEnd} | Duration: {item.Duration} | ");
                if( item.comments == "")
                {
                    Console.Write("Comments: None\n");
                }
                else
                {
                    Console.WriteLine($"Comments: {item.comments}\n");
                }
                
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public bool RecordExists(int excerciseId)
        {
            if (_excerciseController.CheckRecordIdInDb(excerciseId))
            {
                return true;
            }
            return false;
        }

        public void UpdateRecord(int excerciseId, Excercise excerciseRecord)
        {

            bool operation = _excerciseController.UpdateRecordToDb(excerciseId, excerciseRecord);

            if (operation)
            {
                Console.WriteLine("Excercise Modified!");
                return;
            }

            Console.WriteLine("Update method failed!");
            return;
        }

        public void DeleteRecord(int id)
        {
            bool operation = _excerciseController.DeleteRecordToDb(id);

            if (operation)
            {
                Console.WriteLine("Excercise Deleted!");
                return;
            }

            Console.WriteLine("Delete method failed!");
            return;
        }
    }
}

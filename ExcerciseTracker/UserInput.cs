using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcerciseTracker.Models;
using ExcerciseTracker.Repositories.IRepository;
using ExcerciseTracker.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ExcerciseTracker.Services;
using System.Globalization;

namespace ExcerciseTracker
{
    internal class UserInput
    {
        private readonly ExcerciseService _excerciseService;
        public UserInput(ExcerciseService excerciseService)
        {
            _excerciseService = excerciseService;
        }
        public void UserMenu()
        {

            bool exit = false;
            int id;
            Excercise excerciseRecord;
            while (!exit)
            {
                Console.Write("Excercise Tracker\n1. Create Excercise Record\n2. Read Excercise Records\n3. Update Excercise Records\n4. Delete Excercise Records\n0. Exit Program\nSelect Option: ");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case ("0"):
                        exit = true;
                        break;
                    case ("1"):
                        excerciseRecord = CreateExerciseObject();
                        _excerciseService.CreateExcerciseRecord(excerciseRecord);
                        break;
                    case ("2"):
                        _excerciseService.ShowExcerciseRecords();
                        break;
                    case ("3"):
                        _excerciseService.ShowExcerciseRecords();
                        id = GetUserIdInput();
                        bool idExists = _excerciseService.RecordExists(id);
                        if (idExists)
                        {

                            excerciseRecord = CreateExerciseObject();
                            _excerciseService.UpdateRecord(id, excerciseRecord);
                        }
                        else
                        {
                            Console.WriteLine("ID Does not exist!");
                        }
                        break;
                    case ("4"):
                        _excerciseService.ShowExcerciseRecords();
                        id = GetUserIdInput();

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Select a valid option!");
                        break;

                }   
            }
        }

        private static Excercise CreateExerciseObject()
        {
            DateTime startDate, endDate;
            TimeSpan duration;

            startDate = GetUserDate();
            endDate = GetUserDate();

            duration = endDate - startDate;

            Console.WriteLine("Insert a comment for the excercise or leave it null");
            string? comments = Console.ReadLine();

            return new Excercise 
            {
                DateStart = startDate,
                DateEnd = endDate,
                Duration = duration,
                comments = comments
            };
        }

        private static int GetUserIdInput()
        {
            Console.Write("Insert a ID to search or type 0 to exit: ");
            string? userId = Console.ReadLine();
            while(userId == null || userId == "0" || userId == "")
            {
                if (userId == "0") Console.WriteLine("ID 0 Does not exists, please insert a valid ID!");

                Console.WriteLine("Insert a valid option!");
                userId = Console.ReadLine();
            }
            return Int32.Parse(userId);
        }

        private static DateTime GetUserDate()
        {
            DateTime dateTime;

            Console.WriteLine("Insert date in {dd/MM/yyyy hh:mm} format");
            string? startDateString = Console.ReadLine();

            while (!DateTime.TryParseExact(startDateString, "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out dateTime))
            {
                Console.WriteLine("Not a valid date! Please insert a valid date with dd/MM/yyyy hh:mm");
                startDateString = Console.ReadLine();
            }

            return dateTime;
        }

    }
}

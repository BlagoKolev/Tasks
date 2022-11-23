using Backend.Interfaces;
using Backend.Model;
using System;
using System.IO;
using System.Text;

namespace Backend.Services
{
    public class ApplicationService
    {
        private readonly ILogger consoleLogger;
        private readonly IMovieStarsService movieStarsService;
        private readonly ISalaryService salaryService;

        //Here you should create Menu which your Console application will show to user
        //User should be able to choose between: 1. Movie star 2. Calculate Net salary 3. Exit


        public ApplicationService(ILogger consoleLogger, IMovieStarsService movieStarsService, ISalaryService salaryService)
        {
            this.consoleLogger = consoleLogger;
            this.movieStarsService = movieStarsService;
            this.salaryService = salaryService;
        }

        public void Run()
        {
            var userChoice = DisplayMenu();

            if (userChoice == 1)
            {
                ShowMovieStars();
            }
            else if (userChoice == 2)
            {
                CalculateSalary();
            }
            else if (userChoice == 3)
            {
                return;
            }

        }

        private int DisplayMenu()
        {
            while (true)
            {
                consoleLogger.Write("Main Menu");
                consoleLogger.Write("---------");
                consoleLogger.Write("");
                consoleLogger.Write("1. View Movie Stars List");
                consoleLogger.Write("2. Calculate Net Salary");
                consoleLogger.Write("3. Exit");
                byte selection = 0;
                var isNumber = byte.TryParse(Console.ReadLine(), out selection);

                if (isNumber)
                {
                    if (selection == 1)
                    {
                        return 1;
                    }
                    else if (selection == 2)
                    {
                        return 2;
                    }
                    else if (selection == 3)
                    {
                        return 3;
                    }
                    else
                    {
                        consoleLogger.Write("Please choose between option 1, 2 or 3");
                        consoleLogger.Write("");
                    }
                }
                else
                {
                    consoleLogger.Write("Please choose a number between 1,2 or 3");
                    consoleLogger.Write("");
                }
            }
        }

        private void ShowMovieStars()
        {
            var movieStars = this.movieStarsService.GetMovieStars();

            foreach (var star in movieStars)
            {
                star.Age = movieStarsService.CalculateBirthday(star.DateOfBirth);
                var actorToPrint = this.movieStarsService.PreperaForPrint(star);
                consoleLogger.Write(actorToPrint);
            }
        }

        private void CalculateSalary()
        {
            while (true)
            {
                double salary = 0;
                consoleLogger.Write("Please enter a salary:");
                var isDouble = double.TryParse(Console.ReadLine(), out salary);

                if (isDouble)
                {
                    var netSalary = salaryService.CalculateSalary(salary);
                    consoleLogger.Write($"Your net salary is {netSalary} IDR.");
                }
                else
                {
                    consoleLogger.Write("Please enter correct salary:");
                }
            }
        }
    }
}

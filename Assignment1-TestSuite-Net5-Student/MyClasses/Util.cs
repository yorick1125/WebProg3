using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Assignment1
{
    public class Util
    {
        //GenerateEmployees() should be implemented efficiently:
        //avoid hard codding all 25 employees. Use random and loops to randomize data from //a set of first names, last names, departments, and positions. 

        public static List<Employee> GenerateEmployees()
        {
            const int MAXEMPLOYEEGENERATED = 25;
            const int MIN_SALARY = 30000;
            const int MAX_SALARY = 100000;
            const int MAX_EMPLOYEE_ID = 10000;

            // test data
            string[] firstNames = new string[] {"Yorick", "Vathusan", "Michael", "Riley", "David", "Bhavik", "Daniel", "Mansi", "Braeden", "Philip", "Liam" };
            string[] lastNames = new string[] { "Niyonkuru", "Vimalarajan", "Dumas", "Clahane", "Flores", "Patel", "Chieshvili", "Bhardwaj", "Tylbor", "Taddio", "Pichette", "Boucher"};
            string[] departments = new string[] {"Software", "IT", "Management", "Finance", "Legal" };
            string[] positions = new string[] { "Junior", "Intermediate", "Senior", "GOD"};

            List<Employee> employees = new List<Employee>();
            Random random = new Random();
            for(int i = 0; i < MAXEMPLOYEEGENERATED; i++)
            {
                employees.Add(new Employee(
                    Convert.ToUInt32(random.Next(0, MAX_EMPLOYEE_ID)),
                    firstNames[random.Next(0, firstNames.Length)],
                    lastNames[random.Next(0, lastNames.Length)],
                    departments[random.Next(0, departments.Length)],
                    positions[random.Next(0, positions.Length)],
                    random.Next(MIN_SALARY, MAX_SALARY)
                    ));
            }

            return employees;

        }

    //PickWinners implementation must be efficient
    //and not affect the original Employee List
    //Comment the algorithm used: how did you picked the winners? 
        public static List<Employee> PickWinners(List<Employee> list, int winnersNum = 3)
        {
            List<Employee> winners = new List<Employee>();
            int randomNumber;

            // storing used numbers in a dictionnary so we can check for duplicates using O(1) time complexity
            Dictionary<int, int> usedNumbers = new Dictionary<int, int>();
            while (winners.Count() < winnersNum)
            {
                randomNumber = new Random().Next(0, list.Count());
                // if we don't already have a duplicate
                if (!usedNumbers.ContainsValue(randomNumber))
                {
                    winners.Add(list[randomNumber]);
                    usedNumbers.Add(randomNumber, randomNumber);
                }
            }

            return winners;
        }

        public static int GetIntInput(string userInput, int min = int.MinValue, int max = int.MaxValue)
        {
            int i;
            while (!int.TryParse(userInput, out i) || i < min || i > max)
            {
                WriteLine("Please enter a valid number.");
                userInput = ReadLine();
            }
            return i;
        }

    }
}

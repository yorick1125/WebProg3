using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        public static void Main(string[] args)
        {

            // 1. Employee
            EmployeeWinners();

            // 2. Letters 
            //SendLetter();

            // 3. 
            //Cookies();

        }

        public static void EmployeeWinners()
        {
            List<Employee> employees = Util.GenerateEmployees();

            Console.WriteLine("Here is your list of employees: ");
            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee.ToString());
                Console.WriteLine("------------------------------------");
            }

            Console.WriteLine("Press enter to generate five winners and three winners. ");
            Console.ReadLine();
            List<Employee> winners = Util.PickWinners(employees, 5);
            Console.WriteLine("Here are five winners: ");
            Console.WriteLine("Platinum: \n" + winners[0]);
            Console.WriteLine("Gold: \n" + winners[1]);
            Console.WriteLine("Silver: \n" + winners[2]);
            Console.WriteLine("Bronze: \n" + winners[3]);
            Console.WriteLine("Fifth: \n" + winners[4]);

            winners = Util.PickWinners(employees);
            Console.WriteLine("Here are three winners: ");
            Console.WriteLine("Gold: \n" + winners[0]);
            Console.WriteLine("Silver: \n" + winners[1]);
            Console.WriteLine("Bronze: \n" + winners[2]);

            Console.ReadKey();
        }

        public static void SendLetter()
        {

            Console.WriteLine("Welcome! Would you like to send a normal or certified letter? ");
            Console.WriteLine("[1] Normal Letter");
            Console.WriteLine("[2] Certified Letter");
            int choice = GetIntInput(Console.ReadLine());
            Console.WriteLine("Please enter the recipient's name: ");
            string recipient = Console.ReadLine();

            if (choice == 1)
            {
                Console.WriteLine("Letter Details: ");
                Letter letter = new Letter(DateTime.Now, recipient);
                Console.WriteLine("Date: " + letter.Date.ToString());
                Console.WriteLine("Recipient: " + letter.Recipient.ToString());
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                Console.WriteLine("Letter Details: ");
                CertifiedLetter letter = new CertifiedLetter(new Random().Next(0,99999), DateTime.Now, recipient);
                Console.WriteLine("Date: " + letter.Date.ToString());
                Console.WriteLine("Recipient: " + letter.Recipient.ToString());
                Console.WriteLine("Tracking Number: " + letter.TrackingNumber.ToString());
                Console.WriteLine();
            }

            Console.WriteLine("Thank you have a nice day!");
        }

        public static void Cookies()
        {
            Console.WriteLine("Hello User! What shall I call you? ");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello " + userName + ". What's your favorite type of cookie?");
            string cookieType = Console.ReadLine();
            Console.WriteLine("How many cookies would you like? ");
            int quantityDesired = GetIntInput(Console.ReadLine(), 0, int.MaxValue);
            Console.WriteLine("Anything special we should know when making your cookies? If not simply press return without entering anything.");
            string specialRequests = Console.ReadLine();
            Console.WriteLine("Thank you for placing an order. Here is your invoice: ");

            if (specialRequests.Length < 1)
            {
                CookieOrder cookieOrder = new CookieOrder(userName, Convert.ToUInt32(new Random().Next(10000)), Convert.ToUInt32(quantityDesired), cookieType);
                Console.WriteLine(cookieOrder.ToString());
            }
            else
            {
                SpecialCookieOrder specialCookieOrder = new SpecialCookieOrder(userName, Convert.ToUInt32(new Random().Next(10000)), Convert.ToUInt32(quantityDesired), cookieType, specialRequests);
                Console.WriteLine(specialCookieOrder.ToString());
            }

            Console.ReadKey();






        }

        public static int GetIntInput(string userInput, int min = int.MinValue, int max = int.MaxValue)
        {
            int i;
            while (!int.TryParse(userInput, out i) && i < min && i > max)
            {
                Console.WriteLine("Please enter a valid number.");
                userInput = Console.ReadLine();
            }
            return i;
        }



    }
}

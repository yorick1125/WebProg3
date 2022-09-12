using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Assignment1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int choice = -1;
            do
            {
                WriteLine("Hello! Please select an option: ");
                WriteLine("[1] Employee Winners");
                WriteLine("[2] SendLetter");
                WriteLine("[3] CookieBakery");
                WriteLine("[4] Housing System");
                choice = Util.GetIntInput(ReadLine(), 1, 4);
                Clear();
                switch (choice) 
                {
                    case 1:
                        EmployeeWinners();
                        break;
                    case 2:
                        SendLetter();
                        break;
                    case 3:
                        Cookies();
                        break;
                    case 4:
                        Housing();
                        break;
                }
                WriteLine("Press any key to go back to the main menu...");
                ReadKey();
                Clear();

            } while (choice != 0);

            WriteLine("Exiting Program...");

        }

        public static void EmployeeWinners()
        {
            List<Employee> employees = Util.GenerateEmployees();

            WriteLine("Here is your list of employees: ");
            foreach(Employee employee in employees)
            {
                WriteLine(employee.FirstName + " " + employee.LastName);
            }

            WriteLine("Press enter to generate five winners and three winners. ");
            ReadLine();
            List<Employee> winners = Util.PickWinners(employees, 5);
            WriteLine("Here are five winners: ");
            WriteLine("Platinum: \n" + winners[0]);
            WriteLine("Gold: \n" + winners[1]);
            WriteLine("Silver: \n" + winners[2]);
            WriteLine("Bronze: \n" + winners[3]);
            WriteLine("Fifth: \n" + winners[4]);

            winners = Util.PickWinners(employees);
            WriteLine("Here are three winners: ");
            WriteLine("Gold: \n" + winners[0]);
            WriteLine("Silver: \n" + winners[1]);
            WriteLine("Bronze: \n" + winners[2]);

        }

        public static void SendLetter()
        {

            WriteLine("Welcome! Would you like to send a normal or certified letter? ");
            WriteLine("[1] Normal Letter");
            WriteLine("[2] Certified Letter");
            int choice = Util.GetIntInput(ReadLine(), 1, 2);
            WriteLine("Please enter the recipient's name: ");
            string recipient = ReadLine();

            if (choice == 1)
            {
                WriteLine("Your Letter has been sent successfully!");
                WriteLine("Letter Details: ");
                Letter letter = new Letter(DateTime.Now, recipient);
                WriteLine("Date: " + letter.Date.ToString());
                WriteLine("Recipient: " + letter.Recipient.ToString());
                WriteLine();
            }
            else if (choice == 2)
            {
                WriteLine("Letter Details: ");
                CertifiedLetter letter = new CertifiedLetter(new Random().Next(0,99999), DateTime.Now, recipient);
                WriteLine("Date: " + letter.Date.ToString());
                WriteLine("Recipient: " + letter.Recipient.ToString());
                WriteLine("Tracking Number: " + letter.TrackingNumber.ToString());
                WriteLine();
            }

            WriteLine("Thank you have a nice day!");
        }

        public static void Cookies()
        {
            WriteLine("Hello User! What shall I call you? ");
            string userName = ReadLine();
            WriteLine("Hello " + userName + ". What's your favorite type of cookie?");
            string cookieType = ReadLine();
            WriteLine("How many cookies would you like? ");
            int quantityDesired = Util.GetIntInput(ReadLine(), 1, int.MaxValue);
            WriteLine("Anything special we should know when making your cookies? If not simply press return without entering anything.");
            string specialRequests = ReadLine();
            WriteLine("Thank you for placing an order. Here is your invoice: ");

            if (specialRequests.Length < 1)
            {
                CookieOrder cookieOrder = new CookieOrder(userName, Convert.ToUInt32(new Random().Next(10000)), Convert.ToUInt32(quantityDesired), cookieType);
                WriteLine(cookieOrder.ToString());
            }
            else
            {
                SpecialCookieOrder specialCookieOrder = new SpecialCookieOrder(userName, Convert.ToUInt32(new Random().Next(10000)), Convert.ToUInt32(quantityDesired), cookieType, specialRequests);
                WriteLine(specialCookieOrder.ToString());
            }

        }

        public static void Housing()
        {
            WriteLine("Welcome! Would you like to find a Single Family housing or Multi Unit?? ");
            WriteLine("[1] Single Family");
            WriteLine("[2] Multi Units");
            int choice = Util.GetIntInput(ReadLine(), 1, 2);
            if(choice == 1)
            {
                SingleFamily singleFamily = new SingleFamily(2019, "8674 Victoria Lane", "Type 2", "MTL Maids", false, 3,1, 900.0m, 2500, 1, 3);
                WriteLine("Here is your Single Family House: ");
                WriteLine(singleFamily.ToString());
            }
            else if(choice == 2)
            {
                MultiUnits multiUnits = new MultiUnits(2019, "8674 Victoria Lane", "Type 2", "MTL Maids", false, 4, 900.0m);
                WriteLine("Here is your Multi Unit House: ");
                WriteLine(multiUnits.ToString());
            }
            else
            {
                WriteLine("Error Processing Housing Choice. Exiting...");
            }
        }





    }
}

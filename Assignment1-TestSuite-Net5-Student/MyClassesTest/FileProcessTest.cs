using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Assignment1;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {

        #region Cookie and Special Cookie Unit Tests
        uint orderNumber = 1000;        //starting order number

        [TestMethod]
        public void CookieOrderMoreThanTwoDozen()
        {
            try
            {
                uint quantity = 30;
                //public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
                CookieOrder order = new CookieOrder("Claudiu", ++orderNumber, quantity, "Nutella Cookies");
                decimal price = order.Quantity * (decimal)CookieOrder.WHOLESALEPRICE;

                Debug.WriteLine($"Order price {order.TotalPrice} Calculated price: {price}");

                Assert.IsTrue(order.TotalPrice == price);
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with Cookie generation");
            }
        }

        [TestMethod]
        public void CookieOrderLessThanTwoDozen()
        {
            try
            {
                uint quantity = 23;
                //public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
                CookieOrder order = new CookieOrder("Robert", ++orderNumber, quantity, "Nutella Cookies");
                decimal price = order.Quantity * (decimal)CookieOrder.REGULARPRICE;

                Debug.WriteLine($"Order price {order.TotalPrice} Calculated price: {price}");

                Assert.IsTrue(order.TotalPrice == price);
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with Cookie generation");
            }
        }

        [TestMethod]
        public void CookieOrderExactlyTwoDozen()
        {
            try
            {
                uint quantity = 24;
                //public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
                CookieOrder order = new CookieOrder("Philip", ++orderNumber, quantity, "Nutella Cookies");
                decimal price = order.Quantity * (decimal)CookieOrder.WHOLESALEPRICE;

                Debug.WriteLine($"Order price {order.TotalPrice} Calculated price: {price}");

                Assert.IsTrue(order.TotalPrice == price);
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with Cookie generation");
            }
        }

        [TestMethod]
        public void SpecialCookieOrderMoreThanTwoDozen()
        {
            try
            {
                uint quantity = 30;
                //public SpecialCookieOrder(string customerName, uint orderNumber, uint quantity, string cookieType, string description)
                SpecialCookieOrder SpecialOrder = new SpecialCookieOrder("George", ++orderNumber, quantity, "Ginger Bread Soldiers", "Extra hazelnuts");
                decimal price = SpecialOrder.Quantity * (decimal)CookieOrder.WHOLESALEPRICE + SpecialCookieOrder.HANDLINGFEE;

                Debug.WriteLine($"Order price {SpecialOrder.TotalPrice} Calculated price: {price}");

                Assert.IsTrue(SpecialOrder.TotalPrice == price);
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with SpecialCookie generation");
            }
        }

        [TestMethod]
        public void SpecialCookieOrderLessThanTwoDozen()
        {
            try
            {
                uint quantity = 23;
                //public SpecialCookieOrder(string customerName, uint orderNumber, uint quantity, string cookieType, string description)
                SpecialCookieOrder SpecialOrder = new SpecialCookieOrder("Anita", ++orderNumber, quantity, "Ginger Bread Soldiers", "Extra hazelnuts");
                decimal price = SpecialOrder.Quantity * (decimal)CookieOrder.REGULARPRICE + SpecialCookieOrder.HANDLINGFEE;

                Debug.WriteLine($"Order price {SpecialOrder.TotalPrice} Calculated price: {price}");

                Assert.IsTrue(SpecialOrder.TotalPrice == price);
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with SpecialCookie generation");
            }
        }

        [TestMethod]
        public void SpecialCookieOrderExactlyTwoDozen()
        {
            try
            {
                uint quantity = 24;
                //public SpecialCookieOrder(string customerName, uint orderNumber, uint quantity, string cookieType, string description)
                SpecialCookieOrder SpecialOrder = new SpecialCookieOrder("Mary", ++orderNumber, quantity, "Ginger Bread Soldiers", "Extra hazelnuts");
                decimal price = SpecialOrder.Quantity * (decimal)CookieOrder.WHOLESALEPRICE + SpecialCookieOrder.HANDLINGFEE;

                Debug.WriteLine($"Order price {SpecialOrder.TotalPrice} Calculated price: {price}");

                Assert.IsTrue(SpecialOrder.TotalPrice == price);
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with SpecialCookie generation");
            }
        }

        [TestMethod]
        public void SpecialCookieOrderInheritance()
        {
            try
            {
                uint quantity = 10;
                //public SpecialCookieOrder(string customerName, uint orderNumber, uint quantity, string cookieType, string description)
                CookieOrder SpecialOrder = new SpecialCookieOrder("Dany", ++orderNumber, quantity, "Ginger Bread Soldiers", "Extra hazelnuts");
                decimal price = SpecialOrder.Quantity * (decimal)CookieOrder.REGULARPRICE + SpecialCookieOrder.HANDLINGFEE;

                Debug.WriteLine($"Order price {SpecialOrder.TotalPrice} Calculated price: {price}");

                Assert.IsTrue(SpecialOrder.TotalPrice == price);
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with SpecialCookie generation");
            }
        }

        #endregion


        #region Employee Unit Tests

        [TestMethod]
        public void EmployeeEmptyConstructor()
        {
            try
            {
                //public Employee(string name_, uint idNumber_)
                Employee e = new Employee();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }


        [TestMethod]
        public void EmployeeCons2Param()
        {
            try
            {
                Employee e = new Employee("Mike C", 934024);
            }
            catch (Exception e)
            {
                Assert.Fail("Employee constructor with 2 parameters");
            }
        }

        [TestMethod]
        public void EmployeeCons4Param()
        {
            try
            {
                //public Employee(uint idNumber_, string firstName_, string lastName_, string departement_, string position_, decimal yearlySalary_)
                Employee e = new Employee(93402, "Mike", "Cooper", "IT", "Vice-President", 250000m);
            }
            catch (Exception e)
            {
                Assert.Fail("Employee constructor with 4 parameters");
            }
        }



        [TestMethod]
        public void EmployeePropIDGood()
        {
            try
            {
                Employee e = new Employee();

                e.Id = 11023;
            }
            catch (Exception e)
            {
                Assert.Fail("Employee Property ID not working");
            }
        }

        [TestMethod]
        public void EmployeePropName()
        {
            try
            {
                Employee e = new Employee("Mike", 12345);
                e.FirstName = "Mike C";
            }
            catch (Exception e)
            {
                Assert.Fail("Name Property");
            }
        }

        [TestMethod]
        public void EmployeePropDepartment()
        {
            try
            {
                Employee e = new Employee();
                e.Department = "Legal";
            }
            catch (Exception e)
            {
                Assert.Fail("Department Property" + e.Message);
            }
        }

        [TestMethod]
        public void EmployeePropPosition()
        {
            try
            {
                Employee e = new Employee();
                e.Position = "Engineering Director";
            }
            catch (Exception e)
            {
                Assert.Fail("Position Property");
            }
        }

        [TestMethod]
        public void EmployeeToString()
        {
            //public Employee(uint idNumber_, string firstName_, string lastName_, string departement_, string position_, decimal yearlySalary_)
            Employee e = new Employee(93402, "Mike", "Cooper", "IT", "Vice-President", 250000m);

            Assert.IsTrue(e.ToString().Contains("93402"));
        }

        [TestMethod]
        public void EmployeeGenerate25UniqueEmployee()
        {
            try
            {
                int employeeSize = 5;
                //returns 25 different employees
                List<Employee> employeeList = Util.GenerateEmployees();
                
                DisplayEmployee(employeeList, "Employee List");

                var uniqueList = new HashSet<Employee>(employeeSize);

                for (int i = 0; uniqueList.Count < employeeSize; i++)
                {
                    uniqueList.Add(employeeList[i]);        //will fail if there are not 25 employees in employeeList
                }

                DisplayEmployee(uniqueList, "HashSet Employee List");

                Assert.IsTrue(uniqueList.Count == employeeList.Count && uniqueList.Count == employeeSize);
            }
            catch (Exception e)
            {
                Assert.Fail("The Employee List generated does not contain unique employees." + e.Message);
            }
        }

        private void DisplayEmployee(IEnumerable<Employee> employeeList, string message = "")
        {
            Debug.WriteLine(message);
            foreach (Employee e in employeeList)
            {
                //output to the Test Detail Summary
                Debug.WriteLine(e);
            }
        }



        [TestMethod]
        public void Employee3DifferentWinner()
        {
            try
            {
                List<Employee> employeeList = Util.GenerateEmployees(); //returns 25 different employees

                List<Employee> winners = Util.PickWinners(employeeList, 3);

                DisplayEmployee(winners);

                //Check for different winners
                //If a winner matches another one, there is duplication and that's not allowed. 
                //Good scenario: false means there are no duplicates
                //Bad scenario: true means there are duplicates and throw and error. 
                Assert.IsFalse(winners[0].Equals(winners[1]) || winners[0].Equals(winners[2]) || winners[1].Equals(winners[2]));
            }
            catch (Exception e)
            {
                Assert.Fail($"Employee: the winners are not different or error in an Employee method. Error: {e.Message}");
            }
        }

        [TestMethod]
        public void Employee5DifferentWinner()
        {
            try
            {
                List<Employee> employeeList = Util.GenerateEmployees(); //returns 25 different employees

                List<Employee> winners = Util.PickWinners(employeeList, 5);

                DisplayEmployee(winners);

                //Read on HashSet to understand how it works. 
                
                HashSet<Employee> uniqueList = new();
                
                foreach(Employee e in winners)
                {
                    uniqueList.Add(e);
                }               

                Debug.WriteLine($"uniqueList count: {uniqueList.Count}");
                Debug.WriteLine($"winners count: {winners.Count}");

                //If the HashSet list is not the same size as the winners' list, then it means the winners list contains duplicates. 
                Assert.IsTrue(uniqueList.Count == winners.Count);
            }
            catch (Exception e)
            {
                Assert.Fail($"Employee: the winners are not different or error in an Employee method. Error: {e.Message}");
            }
        }

        [TestMethod]
        public void Employee3WinnersExistInList()
        {
            try
            {
                //returns 25 different employees
                List<Employee> employeeList = Util.GenerateEmployees();

                List<Employee> winners = Util.PickWinners(employeeList, 3);

                DisplayEmployee(winners);

                //Check for winners to exist in the original employee list. 

                foreach (Employee winner in winners)
                {
                    if (!employeeList.Contains(winner))
                    {
                        Assert.Fail("Winner not found in original Employee List");
                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with List generation");
            }
        }

        [TestMethod]
        public void EmployeeExactly3Winners()
        {
            try
            {
                //returns 25 different employees
                List<Employee> employeeList = Util.GenerateEmployees();

                List<Employee> winners = Util.PickWinners(employeeList, 3);

                DisplayEmployee(winners);


                Assert.IsTrue(winners.Count == 3);


            }
            catch (Exception e)
            {
                Assert.Fail("Problem with List generation");
            }
        }

        #endregion


        #region Houses Unit Tests

        const int MONTHSINYEAR = 12;
        List<SingleFamily> privateHome;
        List<MultiUnits> multi;

        [TestMethod]
        public void SingleFamilyCreateList()
        {
            try
            {
                privateHome = new List<SingleFamily>
                {
                    //new SingleFamily(string addr, int beds, int baths, decimal rent)
                    new SingleFamily("34 Winston Street", 3, 2, 900.00m),
                    new SingleFamily("5234 Carolina Ave", 2, 2, 850.00m),
                    new SingleFamily("54 Magnolia Court", 4, 2, 1150.00m),
                    new SingleFamily("6910 Reiley", 3, 2, 1000.00m),
                    new SingleFamily("76 St. Johns Ct.", 3, 2, 1000.00m)
                };
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SingleFamilyToString()
        {
            try
            {
                privateHome = new List<SingleFamily>
                {
                    //new SingleFamily(string addr, int beds, int baths, decimal rent)
                    new SingleFamily("34 Winston Street", 3, 2, 900.00m),

                };

                Assert.IsTrue(privateHome[0].ToString().Contains("$900"));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SingleFamilyYearlyRentAmount()
        {
            try
            {
                privateHome = new List<SingleFamily>
                {
                    //new SingleFamily(string addr, int beds, int baths, decimal rentAmount)
                    new SingleFamily("34 Winston Street", 3, 2, 1000.00m),

                };

                decimal rent = privateHome[0].RentAmount * MONTHSINYEAR;
                Assert.IsTrue(privateHome[0].ProjectedRentalAmt().Equals(rent));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void MultiUnitCreateList()
        {
            try
            {
                multi = new List<MultiUnits>
                {
                    //new MultiUnits(string addr, int numberUnits, decimal rentAmt)
                    new MultiUnits("8674 Victoria Lane", 2, 750.00m),
                    new MultiUnits("9724 Bridge Street", 2, 700.00m)
                };
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void MultiUnitYearlyRentAmount()
        {
            try
            {
                multi = new List<MultiUnits>
                {
                    //new MultiUnits(string addr, int numberUnits, decimal rentAmt)
                    new MultiUnits("8674 Victoria Lane", 2, 750.00m),
                    new MultiUnits("9724 Bridge Street", 2, 700.00m)
                };

                decimal rent = multi[0].RentAmountPerUnit * multi[0].NoOfUnits * MONTHSINYEAR;
                Assert.IsTrue(multi[0].ProjectedRentalAmt().Equals(rent));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion

        #region Letter and Certified Letter Unit Tests
        [TestMethod]
        public void CertifiedLetterCreate()
        {
            try
            {
                //public CertifiedLetter(long trackingNumber_, DateTime date_, string recipient_)
                CertifiedLetter CertLetter = new CertifiedLetter(92939939, DateTime.Now, "Claudiu S.");

                Assert.IsTrue(CertLetter.ToString().Contains("92939939"));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void LetterCreateInheritance()
        {
            try
            {
                //public CertifiedLetter(long trackingNumber_, DateTime date_, string recipient_)
                Letter CertLetter = new CertifiedLetter(123456, DateTime.Now, "Claudiu S.");

                Assert.IsTrue(CertLetter.ToString().Contains("Claudiu"));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void LetterCreate()
        {
            try
            {
                //public Letter(DateTime date_, string recipient_)
                Letter CertLetter = new Letter(DateTime.Now, "Claudiu S.");

                Assert.IsTrue(CertLetter.ToString().Contains("Claudiu"));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        #endregion

    }
}

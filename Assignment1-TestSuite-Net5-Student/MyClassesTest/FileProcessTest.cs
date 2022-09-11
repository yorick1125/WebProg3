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
        public void CookieOrderEqualsTrue()
        {
            try
            {
                uint quantity = 24;
                //public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
                CookieOrder order = new CookieOrder("Philip", ++orderNumber, quantity, "Nutella Cookies");
                CookieOrder order2 = new CookieOrder("Philip", orderNumber, quantity, "Nutella Cookies");

                Assert.IsTrue(order.Equals(order2));
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with checking equality in Cookie orders.");
            }
        }

        [TestMethod]
        public void CookieOrderEqualsFalse()
        {
            try
            {
                uint quantity = 24;
                //public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
                CookieOrder order = new CookieOrder("Philip", ++orderNumber, quantity, "Nutella Cookies");
                CookieOrder order2 = new CookieOrder("Php", ++orderNumber, 99999, "Nutella");

                Assert.IsFalse(order.Equals(order2));
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with checking equality in Cookie orders.");
            }
        }

        [TestMethod]
        public void CookieOrderToString()
        {
            try
            {
                uint quantity = 24;
                //public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
                CookieOrder order = new CookieOrder("Philip", ++orderNumber, quantity, "Nutella Cookies");
                Assert.IsTrue(order.ToString().Contains(order.OrderNumber.ToString()));
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with checking equality in Cookie orders.");
            }
        }

        [TestMethod]
        public void CookieOrderGetHashCode()
        {
            uint quantity = 24;
            CookieOrder c = new CookieOrder("Philip", ++orderNumber, quantity, "Nutella Cookies");
            CookieOrder c2 = new CookieOrder("Philip", orderNumber, quantity, "Nutella Cookies");
            HashSet<CookieOrder> orders = new HashSet<CookieOrder>();
            orders.Add(c);
            orders.Add(c2);

            Assert.IsTrue(c.GetHashCode() == c2.GetHashCode());
            Assert.IsTrue(orders.Count == 1);
        }

        [TestMethod]
        public void SpecialCookieOrderEqualsTrue()
        {
            try
            {
                uint quantity = 24;
                //public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
                SpecialCookieOrder order = new SpecialCookieOrder("Philip", ++orderNumber, quantity, "Nutella Cookies", "extra nutella");
                SpecialCookieOrder order2 = new SpecialCookieOrder("Philip", orderNumber, quantity, "Nutella Cookies", "extra nutella");

                Assert.IsTrue(order.Equals(order2));
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with checking equality in Cookie orders.");
            }
        }

        [TestMethod]
        public void SpecialCookieOrderEqualsFalse()
        {
            try
            {
                uint quantity = 24;
                //public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
                SpecialCookieOrder order = new SpecialCookieOrder("Philip", ++orderNumber, quantity, "Nutella Cookies", "extra nutella");
                SpecialCookieOrder order2 = new SpecialCookieOrder("George", ++orderNumber, 99999, "Nutella", "extra nutella");

                Assert.IsFalse(order.Equals(order2));
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with checking equality in Cookie orders.");
            }
        }

        [TestMethod]
        public void SpecialCookieOrderToString()
        {
            try
            {
                uint quantity = 24;
                //public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
                SpecialCookieOrder order = new SpecialCookieOrder("Philip", ++orderNumber, quantity, "Nutella Cookies", "extra nutella");
                Assert.IsTrue(order.ToString().Contains(order.Description.ToString()));
            }
            catch (Exception e)
            {
                Assert.Fail("Problem with checking equality in Cookie orders.");
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
                Employee e = new Employee("Mike", 934024);
            }
            catch (Exception e)
            {
                Assert.Fail("Employee constructor with 2 parameters");
            }
        }

        [TestMethod]
        public void EmployeeCons2Param2Names()
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
        public void EmployeeGetHashCode()
        {
            //public Employee(uint idNumber_, string firstName_, string lastName_, string departement_, string position_, decimal yearlySalary_)
            Employee e = new Employee(93402, "Mike", "Cooper", "IT", "Vice-President", 250000m);
            Employee e2 = new Employee(93402, "Mike", "Cooper", "IT", "Vice-President", 250000m);
            HashSet<Employee> employees = new HashSet<Employee>();
            employees.Add(e);
            employees.Add(e2);

            Assert.IsTrue(e.GetHashCode() == e2.GetHashCode());
            Assert.IsTrue(employees.Count == 1);
        }

        [TestMethod]
        public void EmployeeGenerate25UniqueEmployee()
        {
            try
            {
                int employeeSize = 25;
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
        public void SingleFamilyCreate()
        {
            try
            {
                SingleFamily singleFamily = new SingleFamily();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        [TestMethod]
        public void SingleFamilyGetNumBedrooms()
        {
            try
            {
                SingleFamily singleFamily = new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4);
                Assert.AreEqual(4, singleFamily.NumberBedrooms);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SingleFamilySetNumBedrooms()
        {
            try
            {
                SingleFamily singleFamily = new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4);
                singleFamily.NumberBedrooms = 5;
                Assert.AreEqual(5, singleFamily.NumberBedrooms);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SingleFamilyGetNumGarages()
        {
            try
            {
                SingleFamily singleFamily = new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4);
                Assert.AreEqual(1, singleFamily.NumberGarages);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SingleFamilySetNumGarages()
        {
            try
            {
                SingleFamily singleFamily = new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4);
                singleFamily.NumberGarages = 2;
                Assert.AreEqual(2, singleFamily.NumberGarages);

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SingleFamilyGetSize()
        {
            try
            {
                SingleFamily singleFamily = new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4);
                Assert.AreEqual(2500, singleFamily.Size);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SingleFamilySetSize()
        {
            try
            {
                SingleFamily singleFamily = new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4);
                singleFamily.Size = 8;
                Assert.AreEqual(8, singleFamily.Size);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

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
        public void SingleFamilyEqualsTrue()
        {
            try
            {
                privateHome = new List<SingleFamily>
                {
                    //new SingleFamily(string addr, int beds, int baths, decimal rent)
                    new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4),
                    new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4)

                };


                Assert.IsTrue(privateHome[0].Equals(privateHome[1]));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SingleFamilyEqualsFalse()
        {
            try
            {
                privateHome = new List<SingleFamily>
                {
                    //new SingleFamily(string addr, int beds, int baths, decimal rent)
                    new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4),
                    new SingleFamily("21 Winston Street", 3, 2, 900.00m, 2500, 1, 4)

                };


                Assert.IsFalse(privateHome[0].Equals(privateHome[1]));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SingleFamilyGetHashCode()
        {
            //public Employee(uint idNumber_, string firstName_, string lastName_, string departement_, string position_, decimal yearlySalary_)
            SingleFamily f = new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4);
            SingleFamily f2 = new SingleFamily("34 Winston Street", 3, 2, 900.00m, 2500, 1, 4);
            HashSet<SingleFamily> families = new HashSet<SingleFamily>();
            families.Add(f);
            families.Add(f2);

            Assert.IsTrue(f.GetHashCode() == f2.GetHashCode());
            Assert.IsTrue(families.Count == 1);
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
        public void MultiUnitCreate()
        {
            try
            {
                MultiUnits multiUnits = new MultiUnits();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void MultiUnitCons1Param()
        {
            try
            {
                MultiUnits multiUnits = new MultiUnits("8674 Victoria Lane");
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
                Assert.IsTrue(multi[0].ToString().Contains("8674 Victoria Lane"));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void MultiUnitGetAddress()
        {
            try
            {
                MultiUnits multiUnits = new MultiUnits("8674 Victoria Lane", 2, 750.00m);
                multiUnits.Address = "8674 Victoria Lane";
                Assert.AreEqual(multiUnits.Address, "8674 Victoria Lane");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void MultiUnitsGetHashCode()
        {
            //public Employee(uint idNumber_, string firstName_, string lastName_, string departement_, string position_, decimal yearlySalary_)
            MultiUnits mu = new MultiUnits("8674 Victoria Lane", 2, 750.00m);
            MultiUnits mu2 = new MultiUnits("8674 Victoria Lane", 2, 750.00m);
            HashSet<MultiUnits> families = new HashSet<MultiUnits>();
            families.Add(mu);
            families.Add(mu2);

            Assert.IsTrue(mu.GetHashCode() == mu2.GetHashCode());
            Assert.IsTrue(families.Count == 1);
        }



        [TestMethod]
        public void MultiUnitsYearlyRentAmount()
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

        [TestMethod]
        public void MultiUnitsEqualsFalse()
        {
            try
            {
                MultiUnits housing = new MultiUnits("9724 Bridge Street", 2, 700.00m);
                MultiUnits housing2 = new MultiUnits("9724 Bridge Street", 4, 700.00m);
                Assert.IsFalse(housing.Equals(housing2));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void MultiUnitsEqualsTrue()
        {
            try
            {
                MultiUnits housing = new MultiUnits("9724 Bridge Street", 2, 700.00m);
                MultiUnits housing2 = new MultiUnits("9724 Bridge Street", 2, 700.00m);
                Assert.IsTrue(housing.Equals(housing2));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingCreate()
        {
            try
            {
                Housing housing = new Housing();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingCons1Param()
        {
            try
            {
                Housing housing = new Housing(2019);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingCons5Param()
        {
            try
            {
                Housing housing = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true );
                Assert.IsTrue(housing.ToString().Contains("9724"));

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingPropYear()
        {
            try
            {
                Housing housing = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
                housing.Year = 2020;
                Assert.IsTrue(housing.Year == 2020);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingPropAddress()
        {
            try
            {
                Housing housing = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
                housing.Address = "4378 Maple Street";
                Assert.IsTrue(housing.Address == "4378 Maple Street");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingPropConstructionType()
        {
            try
            {
                Housing housing = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
                housing.ConstructionType = "Type 3";
                Assert.IsTrue(housing.ConstructionType == "Type 3");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingPropCleaningCrew()
        {
            try
            {
                Housing housing = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
                housing.CleaningCrew = "Montreal Cleaning Specialists";
                Assert.IsTrue(housing.CleaningCrew == "Montreal Cleaning Specialists");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingPropInsuranceClaimHistory()
        {
            try
            {
                Housing housing = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
                housing.InsuranceClaimHistory = false;
                Assert.IsTrue(housing.InsuranceClaimHistory == false);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingEqualsTrue()
        {
            try
            {
                Housing housing = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
                Housing housing2 = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
                Assert.IsTrue(housing.Equals(housing2));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingEqualsFalse()
        {
            try
            {
                Housing housing = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
                Housing housing2 = new Housing(2020, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
                Assert.IsFalse(housing.Equals(housing2));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void HousingGetHashCode()
        {
            //public Employee(uint idNumber_, string firstName_, string lastName_, string departement_, string position_, decimal yearlySalary_)
            Housing h = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
            Housing h2 = new Housing(2019, "9724 Bridge Street", "Type 2", "Maid Cleaning", true);
            HashSet<Housing> families = new HashSet<Housing>();
            families.Add(h);
            families.Add(h2);

            Assert.IsTrue(h.GetHashCode() == h2.GetHashCode());
            Assert.IsTrue(families.Count == 1);
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

        [TestMethod]
        public void LetterEqualsTrue()
        {
            try
            {
                //public Letter(DateTime date_, string recipient_)
                DateTime date = DateTime.Now;
                Letter Letter = new Letter(date, "Claudiu S.");
                Letter Letter2 = new Letter(date, "Claudiu S.");

                Assert.IsTrue(Letter.Equals(Letter2));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void LetterEqualsFalse()
        {
            try
            {
                //public Letter(DateTime date_, string recipient_)
                Letter Letter = new Letter(DateTime.Now, "Claudiu S.");
                Letter Letter2 = new Letter(DateTime.Now, "Larry");

                Assert.IsFalse(Letter.Equals(Letter2));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void LetterGetHashCode()
        {
            DateTime date = DateTime.Now;
            Letter l = new Letter(date, "Claudiu S.");
            Letter l2 = new Letter(date, "Claudiu S.");
            HashSet<Letter> letters = new HashSet<Letter>();
            letters.Add(l);
            letters.Add(l2);

            Assert.IsTrue(l.GetHashCode() == l2.GetHashCode());
            Assert.IsTrue(letters.Count == 1);
        }

        [TestMethod]
        public void CertifiedLetterEqualsTrue()
        {
            try
            {
                //public Letter(DateTime date_, string recipient_)
                DateTime date = DateTime.Now;
                CertifiedLetter Letter = new CertifiedLetter(18271, date, "Claudiu S.");
                CertifiedLetter Letter2 = new CertifiedLetter(18271, date, "Claudiu S.");

                Assert.IsTrue(Letter.Equals(Letter2));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void CertifiedLetterEqualsFalse()
        {
            try
            {
                //public CertifiedLetter(DateTime date_, string recipient_)
                CertifiedLetter Letter = new CertifiedLetter(18271, DateTime.Now, "Claudiu S.");
                CertifiedLetter Letter2 = new CertifiedLetter(18271, DateTime.Now, "Larry");

                Assert.IsFalse(Letter.Equals(Letter2));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void CertifiedLetterGetHashCode()
        {
            DateTime date = DateTime.Now;
            CertifiedLetter l = new CertifiedLetter(18271, date, "Claudiu S.");
            CertifiedLetter l2 = new CertifiedLetter(18271, date, "Claudiu S.");
            HashSet<CertifiedLetter> letters = new HashSet<CertifiedLetter>();
            letters.Add(l);
            letters.Add(l2);

            Assert.IsTrue(l.GetHashCode() == l2.GetHashCode());
            Assert.IsTrue(letters.Count == 1);
        }

        #endregion

    }
}

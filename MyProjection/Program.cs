using MyProjection.folder;
using System;
using System.Data.SqlClient;

namespace MyProjection
{
    class Program
    {
        static bool isWorking = true;
        static void Main(string[] args)
        {
            while (isWorking)
            {

                switch (ShowMainMenu())
                {
                    case "1": 
                        {
                            ShowCustomerMenu();
                        }break;
                    case "2":
                        {

                        }
                        break;
                    case "3":
                        {

                        }
                        break;
                    case "4": isWorking = false;
                        {

                        }
                        break;
                }
                bool isWorking2 = true;
                while (isWorking2)
                {
                    switch (ShowCustomerMenu())
                    {
                        case "1":
                            {

                                Customer.ShowCustomers();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadLine();

                            }
                            break;
                        case "2":
                            {
                                Console.Clear();
                                var customerModel = CreateCustomerModel();
                                var result = customerModel.CreateCustomer();
                                if (result > 0)
                                {
                                    Console.WriteLine("Customer is added successfully");
                                }
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadLine();
                            }
                            break;
                        case "3":
                            {

                            }
                            break;
                        case "4":
                            isWorking = false;
                            {

                            }
                            break;
                    }
                }
                

            }
            
        }

       

        static string ShowMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{new string('-', 5)}Main Menu{new string('-', 5)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("1. Customers\n" +
                              "2. Accounts\n" + 
                              "3. Transactions\n" + 
                              "4. EXIT\n" + 
                              "4. Choice:");
            return Console.ReadLine();
        }

        static string ShowCustomerMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{new string('-', 5)}Customers Menu{new string('-', 5)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("1. Show Customers\n" +
                              "2. Create Customer\n" +
                              "3. Find Customers\n" +
                              "4. Back \n" +
                              "4. Choice:");
            return Console.ReadLine();
        }
        static Customer CreateCustomerModel()
        {
            Console.WriteLine("Where * is Required");
            try
            {
                return new Customer
                {
                    FirstName = ConsoleWriteWithResult("FirstName *:"),
                    LastName = ConsoleWriteWithResult("LastName *:"),
                    MiddleName = ConsoleWriteWithResult("MiddleName *:"),
                    DateOfBirth = DateTime.Parse(ConsoleWriteWithResult("DateOfBirth yyyy-mm-dd *:")),
                    DocumentNumber = ConsoleWriteWithResult("DocumentNumber *:"),
                };
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Creating customer ERROR {ex.Message}");
            }
            return null;
        }
       
        static string ConsoleWriteWithResult(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
    }
}

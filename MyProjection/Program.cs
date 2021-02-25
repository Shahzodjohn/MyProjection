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
                        }
                        break;
                    case "2":
                        {

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
                //bool isWorking2 = true;
                //while (isWorking2)
                {
                    switch (ShowCustomerMenu())
                    {
                        case "1":
                            {

                                //Customer.ShowCustomers();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadLine();

                            }
                            break;
                        case "2":
                            {
                                Console.Clear();
                                int run;
                                Console.Write("(1) Войти как админ \n(2) Войти как клиент \nChoice = ");
                                run = int.Parse(Console.ReadLine());
                                if (run == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Вход в базу администрации...");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    string log = "alifbank";
                                    Console.Write("Введите Логин = ");
                                    log = Console.ReadLine();
                                    string pas;
                                    Console.Write("Введите Пароль = ");
                                    pas = Console.ReadLine();
                                    if (log == "alifbank" && pas == "2014")
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"{new string('-', 5)}Admin Menu{new string('-', 5)}");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("1. Insert Client\n" +
                                                          "2. Select Client\n" +
                                                          "3. Update Client\n" +
                                                          "4. Delete Client\n" +
                                                          "4. Choice:");
                                        int num = int.Parse(Console.ReadLine());

                                        if (num == 1)
                                        {
                                            var customerModel = CreateCustomerClient();
                                            var result = customerModel.CreateCustomer();
                                            if (result > 0)
                                            {
                                                Console.WriteLine("Customer is added successfully");
                                            }
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Ошибка! Введите правильный пароль...");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("Press any key to return into the main menu...");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.ReadKey();
                                    }
                                }
                                if (run == 2)
                                {
                                    var customerModel = CreateCustomerClient();
                                    var result = customerModel.CreateCustomer();
                                    if (result > 0)
                                    {
                                        Console.WriteLine("Customer is added successfully");
                                    }
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadLine();
                                }

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
        static Customer CreateCustomerClient()
        {
            Console.WriteLine("Client Registering (Where * is required)");
            try
            {
                return new Customer
                {
                    FirstName = ConsoleWriteWithResult("FirstName *:"),
                    LastName = ConsoleWriteWithResult("LastName :"),
                    MiddleName = ConsoleWriteWithResult("MiddleName :"),
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

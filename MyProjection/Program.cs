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
                                        int run;
                                        Console.Write("(1) Войти как админ \n(2) Зарегистрироваться \n(3)Войти как клиент\nChoice = ");
                                        run = int.Parse(Console.ReadLine());
                                        if (run == 1)
                                        {
                                            Console.Clear();
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
                                                                  "2. Select all Clients\n" +
                                                                  "3. Select by Id \n" +
                                                                  "4. Update Client\n" +
                                                                  "5. Delete Client\n" +
                                                                  "5. Choice:");
                                                int num = int.Parse(Console.ReadLine());

                                                if (num == 1)
                                                {
                                                    Console.Clear();
                                                    var customerModel = CreateCustomerClient();
                                                    var result = customerModel.CreateCustomer();
                                                    if (result > 0)
                                                    {
                                                        Console.WriteLine("Customer is added successfully");
                                                    }
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadLine();
                                                }
                                                if (num == 2)
                                                {
                                                    Customer.ShowCustomers();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadLine();
                                                }
                                                if (num == 3)
                                                {
                                                    Customer.ShowCutromerIdmethod();
                                                    Console.WriteLine("Press any key to continue...");
                                                    Console.ReadKey();
                                                }
                                                if (num == 4)
                                                {
                                                    try
                                                    {
                                                        Customer cust = new Customer();
                                                        Console.WriteLine("Enter Customer Id:");
                                                        cust.Id = int.Parse(Console.ReadLine());
                                                        Console.WriteLine("Enter new Fist Name for Customer:");
                                                        cust.FirstName = Convert.ToString(Console.ReadLine());
                                                        Console.WriteLine("Enter new Last Name:");
                                                        cust.LastName = Convert.ToString(Console.ReadLine());
                                                        Console.WriteLine("Enter new Middle Name:");
                                                        cust.MiddleName = Convert.ToString(Console.ReadLine());
                                                        Console.WriteLine("Enter new Login:");
                                                        cust.Login = Convert.ToString(Console.ReadLine());
                                                        Console.WriteLine("Enter new Password:");
                                                        cust.Password = Convert.ToString(Console.ReadLine());
                                                        Console.WriteLine("Enter new Documment Number:");
                                                        cust.DocumentNumber = Convert.ToString(Console.ReadLine());
                                                        Console.WriteLine("Enter new Date Of Birth:");
                                                        cust.DateOfBirth = DateTime.Parse(Console.ReadLine());
                                                        cust.UpdateCustomer();

                                                        Console.WriteLine("The Customer is successfully added!");
                                                        Console.ReadKey();
                                                    }
                                                    catch (Exception ex)
                                                    {

                                                        Console.WriteLine("ERROR While Updating Customer" + ex.Message);
                                                    }

                                                    

                                                }
                                                if (num == 5)
                                                {
                                                    //Customer customer = new Customer();
                                                    
                                                    Customer.DeleteCustomer();

                                                }
                                                
                                            }
                                            else
                                            {
                                                Console.Clear();
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
                                        if (run == 3)
                                        {
                                            Customer cust = new Customer();
                                            bool x = true;
                                            SqlConnection connection = SqlClientModel.GetNewSqlConnection();
                                            connection.Open();
                                            while (x)
                                            {

                                                Console.WriteLine("Login:");
                                                cust.Login = Console.ReadLine();
                                                Console.WriteLine("Password:");
                                                cust.Password = Console.ReadLine();
                                                string cmdText = "select * from Customers where Login = @Login and Password = @Password";
                                                SqlCommand command = new SqlCommand(cmdText, connection);
                                                command.Parameters.AddWithValue("Login", cust.Login);
                                                command.Parameters.AddWithValue("Password", cust.Password);
                                                SqlDataReader reader = command.ExecuteReader();
                                                while (reader.Read())
                                                {
                                                    x = false;
                                                    break;
                                                }
                                                reader.Close();
                                                if (!x)
                                                {
                                                    Console.WriteLine("Login or password was incorrect!");
                                                }
                                                Console.Clear();

                                            }
                                            connection.Close();
                                            CustomerMenu();
                                        }
                                        if(run == 3)
                                        {
                                           


                                        }
                                    }
                                    break;
                                case "3":
                                    {

                                    }
                                    break;
                                case "4":
                                    {
                                        ShowCustomerMenu();

                                    }
                                    break;
                            }
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
            }

        }



        static string ShowMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{new string('-', 5)}Main Menu{new string('-', 5)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("1. Customers\n" +
                              "2. Transactions\n" +
                              "3. EXIT\n" +
                              "-. Choice:");
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
                              "4. EXIT \n" +
                              "4. Choice:");
            return Console.ReadLine();
        }

        static string CustomerMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{new string('-', 5)}Customers Menu{new string('-', 5)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("1. Check Transactions\n" +
                              "2. Register a new account\n" +
                              "3. Credits\n" +
                              "4. EXIT \n" +
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
                    Login = ConsoleWriteWithResult("Login *:"),
                    Password = ConsoleWriteWithResult("Password *:"),
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

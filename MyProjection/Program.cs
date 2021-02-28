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
                switch (ShowCustomerMenu())
                {
                    case "0":
                        {
                            #region
                            //Customer.ShowCustomers();
                            //Console.WriteLine("Press any key to continue...");
                            //Console.ReadLine();
                            #endregion



                        }
                        break;
                    case "1":
                        {
                            Console.Clear();
                            int run;
                            Console.Write("(1) Войти как админ \n(2) Зарегистрироваться \n(3) Войти как клиент \nChoice = ");
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

                                    Console.Clear();
                                    Console.WriteLine("Login:");
                                    cust.Login = Console.ReadLine();
                                    Console.WriteLine("Password:");
                                    cust.Password = Console.ReadLine();
                                    string cmdText = "select * from Customers where Login = @Login and Password = @Password";
                                    SqlCommand command = new SqlCommand(cmdText, connection);
                                    command.Parameters.AddWithValue("Login", cust.Login);
                                    command.Parameters.AddWithValue("Password", cust.Password);
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {

                                        if (reader.Read())
                                        {
                                            //connection.Open();
                                            x = false;

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Successfully Enterder to your account");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Press any key to continue..");
                                            Console.ReadKey();
                                            if (connection.State == System.Data.ConnectionState.Open)
                                            {
                                                connection.Close();
                                            }
                                            switch (CustomerMenu())
                                            {
                                                case "1":
                                                    {
                                                        Credits.CreateCredit();
                                                    }
                                                    break;
                                            }
                                        }
                                        else
                                        {

                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Login or password was incorrect!");
                                            Console.WriteLine("Press any key to get back to the main menu...");
                                            Console.ReadKey();
                                            //connection.Close();
                                            ShowCustomerMenu();

                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        Console.Clear();


                                    }

                                }
                                connection.Close();
                            }
                        }
                        break;

                    case "3":
                        {
                            ShowCustomerMenu();

                        }
                        break;
                }

            }
            switch (CustomerMenu())
            {
                case "1":
                    {
                        Credits credits = Credits.CreateCredit();
                        credits.CreateCreditModel();
                    }
                    break;
            }

        }

        static string ShowCustomerMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{new string('-', 5)}Customers Menu{new string('-', 5)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("1. Logging or Registering a new account \n" +
                              "2. EXIT \n" +
                              "3. Choice:");
            return Console.ReadLine();
        }

        static string CustomerMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{new string('-', 5)}Customers Menu{new string('-', 5)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("1. Apply for a new loan\n" +
                              "2. My information\n" +
                              "3. My loans\n" +
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
                    Gender = ConsoleWriteWithResult("Gender :"),
                    Citizenship = ConsoleWriteWithResult("Citizenship :"),
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

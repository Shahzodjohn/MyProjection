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
                                                        /* вызов метода CreateCredit()
                                                         */
                                                        Console.Clear();
                                                        var CreditModel = CreateCredit();
                                                        var result = CreditModel.CreateCreditModel();
                                                        if (result > 0)
                                                        {
                                                            Console.WriteLine("Application is sucessfully accepted!");
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("Press any key to continue ... ");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.ReadKey();
                                                        }
                                                        Console.WriteLine("Press any key to continue...");
                                                        Console.ReadLine();
                                                    }
                                                    break;
                                                case "2":
                                                    {
                                                        Credits.ShowCodeId();
                                                        Console.WriteLine("Press any key to continue...");
                                                        Console.ReadKey();
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

                    //case "3":
                    //    {
                    //        ShowCustomerMenu();

                    //    }
                    //    break;
                }

            }
            switch (CustomerMenu())
            {
                case "1":
                    {
                        CreateCredit();
                        
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
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


        public static Customer CreateCustomerClient()
        {

            Console.WriteLine("Client Registering (Where * is required)");
            try
            {
                
                return new Customer
                {
                    
                    FirstName = ConsoleWriteWithResult("FirstName *: "),
                    LastName = ConsoleWriteWithResult("LastName : "),
                    MiddleName = ConsoleWriteWithResult("MiddleName : "),
                    Gender = ConsoleWriteWithResult("Gender : "), 
                    Citizenship = ConsoleWriteWithResult("Citizenship : "),
                    DateOfBirth = DateTime.Parse(ConsoleWriteWithResult("DateOfBirth yyyy-mm-dd *: ")),
                    DocumentNumber = ConsoleWriteWithResult("DocumentNumber *: "),
                    MaritalStatus = ConsoleWriteWithResult("MaritalStatus *: "),
                    Login = ConsoleWriteWithResult("Login *: "),
                    Password = ConsoleWriteWithResult("Password *: "),
                };
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Creating customer ERROR {ex.Message}");
            }
            return null ;
        }

        static string ConsoleWriteWithResult(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

        static Credits CreateCredit()
        {
            try
            {
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Please Fill an application once more fully...");
                Console.ForegroundColor = ConsoleColor.White;

                Credits rep = new Credits()
                {
                    Gender = ConsoleWriteLineWithResult("Gender = "),
                    MaritalStatus = ConsoleWriteLineWithResult("Marital Status = "),
                    Age = Convert.ToInt32(ConsoleWriteLineWithResult("Age = ")),
                    Citizenship = ConsoleWriteLineWithResult("Citizenship = "),
                    TheSumOfWholeIncomes = Convert.ToDouble(ConsoleWriteLineWithResult("The Credit Summ Of Whole Incomes = ")),
                    ExpiryOfCreditHistory = Convert.ToInt32(ConsoleWriteLineWithResult("Expiry of Credit History = ")),
                    CreditHistory = Convert.ToInt32(ConsoleWriteLineWithResult("Credit History = ")),
                    CreditGoal = Convert.ToInt32(ConsoleWriteLineWithResult("Your CreditGoal = \n1 - Бытовая техника \n2 - Ремонт \n3 - Телефон \n4 - Прочее \nChoice = ")),
                    CreditDeadLine = Convert.ToInt32(ConsoleWriteLineWithResult("Credit DeadLine = "))
                };
                int point = 1;

                if (rep.Gender == "Male") { point = point + 1; }

                if (rep.Gender == "Female") { point = point + 2; }


                if (rep.MaritalStatus == "Single") { point = point + 1; }

                if (rep.MaritalStatus == "Married") { point = point + 2; }

                if (rep.MaritalStatus == "Diversed") { point = point + 1; }
                //Вдовец
                if (rep.MaritalStatus == "Widow") { point = point + 2; }


                if (rep.Age <= 25) { point = point + 0; }

                if (rep.Age >= 26 && rep.Age <= 35) { point = point + 1; }

                if (rep.Age >= 36 && rep.Age <= 62) { point = point + 2; }

                if (rep.Age > 63) { point = point + 1; }


                if (rep.Citizenship == "Tajik") { point = point + 1; }

                if (rep.Citizenship == "Tajikistan") { point = point + 1; }

                else point = point + 0;


                Console.WriteLine("Your income sum = ");
                int income = int.Parse(Console.ReadLine());

                if (rep.TheSumOfWholeIncomes * 100 / income <= 80) { point = point + 4; }
                if (rep.TheSumOfWholeIncomes * 100 / income >= 80 && income <= 150) { point = point + 3; }
                if (rep.TheSumOfWholeIncomes * 100 / income >= 150 && income <= 250) { point = point + 2; }
                if (rep.TheSumOfWholeIncomes * 100 / income > 250) { point = point + 1; }



                if (rep.CreditHistory >= 3) { point = point + 2; }
                if (rep.CreditHistory >= 1 && rep.CreditHistory <= 3) { point = point + 1; }


                if (rep.CreditGoal == 1) { point = point + 2; }
                
                if (rep.CreditGoal == 2) { point = point + 1; }
                if (rep.CreditGoal == 3) { point = point + 0; }
                if (rep.CreditGoal == 4) { point = point + (-1); }

                
                if (rep.ExpiryOfCreditHistory > 7) { point = point + (-3); }
                if (rep.ExpiryOfCreditHistory == 5 && rep.ExpiryOfCreditHistory == 6 && rep.ExpiryOfCreditHistory == 7) { point = point + (-2); }
                if (rep.ExpiryOfCreditHistory == 4) { point = point + (-1); }
                if (rep.ExpiryOfCreditHistory >= 1 && rep.ExpiryOfCreditHistory <= 3) { point = point + 0; }



                
                rep.CreditDeadLine = Convert.ToInt32(rep.CreditDeadLine);
                if (rep.CreditDeadLine > 12) { point = point + 1; }
                if (rep.CreditDeadLine < 12) { point = point + 1; }


                Credits credits = new Credits();
                Console.WriteLine("Result = " + point);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (point >= 11) {Console.WriteLine("Поздравляем! Ваш кредит одобрен!"); }
                Console.ForegroundColor = ConsoleColor.Red;
                if (point <= 10) { Console.WriteLine("К сожалению, в данный момент мы не можем вам кредит!"); }
                Console.ForegroundColor = ConsoleColor.White;
                return rep;
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"Occured an error while creating an application {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();

            };
            return new Credits();
            
            

        }
        static string ConsoleWriteLineWithResult(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
    }
}

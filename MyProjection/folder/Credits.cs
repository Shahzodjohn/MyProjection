using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyProjection.folder
{
    class Credits
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int Age { get; set; }
        public string Citizenship { get; set; }
        public double TheSumOfWholeIncomes { get; set; }
        public int ExpiryOfCreditHistory { get; set; }
        public int CreditHistory { get; set; }
        public string CreditGoal { get; set; }
        public int CreditDeadLine { get; set; }

        public int CreateCreditModel()
        {
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("Insert into Credits(Gender, MaritalStatus, Age, Citizenship, TheSumOfWholeIncomes, ExpiryOfCreditHistory, CreditHistory, CreditGoal, CreditDeadLine)" +
                " Values(@Gender, @MaritalStatus, @Age, @Citizenship, @TheSumOfWholeIncomes, @ExpiryOfCreditHistory, @CreditHistory , @CreditGoal, @CreditDeadLine)", connection))

            {
                try
                {
                    command.Parameters.AddWithValue("Gender", this.Gender);
                    command.Parameters.AddWithValue("MaritalStatus", this.MaritalStatus);
                    command.Parameters.AddWithValue("Age", this.Age);
                    command.Parameters.AddWithValue("Citizenship", this.Citizenship);
                    command.Parameters.AddWithValue("TheSumOfWholeIncomes", this.TheSumOfWholeIncomes);
                    command.Parameters.AddWithValue("ExpiryOfCreditHistory", this.ExpiryOfCreditHistory);
                    command.Parameters.AddWithValue("CreditHistory", this.CreditHistory);
                    command.Parameters.AddWithValue("CreditGoal", this.CreditGoal);
                    command.Parameters.AddWithValue("CreditDeadLine", this.CreditDeadLine);




                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR  {ex.Message}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();

                }
                finally
                {
                    connection.Close();
                }
            }
            return 0;
        }
        public static int CodeId(int Login)
        {
           
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand($"select * from Customers c " +
                                                $"join " +
                                                $"Credits cr " +
                                                $"on " +
                                                $"c.Id = cr.ClientId " +
                                                $"where " +
                                                $"c.Login = {Login}", connection))
            {
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]},\n" +
                                      $"First Name: {reader["FirstName"]} \n" +
                                      $"Last Name: {reader["LastName"]}, \n" +
                                      $"Middle Name: {reader["MiddleName"]}, \n" + 
                                      $"Gender: {reader["Gender"]}, \n" +
                                      $"Document Number: {reader["DocumentNumber"]},\n" + 
                                      $"Marital Status: {reader["MaritalStatus"]}, \n" +
                                      $"Age: {reader["Age"]}, \n" +
                                      $"Citizenship: {reader["Citizenship"]},  \n" +
                                      $"The Sum Of Whole Incomes: {reader["TheSumOfWholeIncomes"]},  \n" +
                                      $"Expiry Of Credit History: {reader["ExpiryOfCreditHistory"]}, \n" +
                                      $"Credit History: {reader["CreditHistory"]}, \n" +
                                      $"Credit Goal: {reader["CreditGoal"]}, \n" +
                                      $"Credit DeadLine: {reader["CreditDeadLine"]} \n"); 


                }
            }
            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
            return 0;
        }
        public static int ShowCodeId()
        {
            Console.Clear();
            int Login;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Please enter your login once more = ");
            Console.ForegroundColor = ConsoleColor.White;
            Login = int.Parse(Console.ReadLine());
            return CodeId(Login);
        }
        public static int MyloanLogin(int Login)
        {
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand($"select * from Customers c " +
                                                $"join " +
                                                $"Credits cr " +
                                                $"on " +
                                                $"c.Id = cr.ClientId " +
                                                $"where " +
                                                $"c.Login = {Login}", connection))
            {
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"First Name: {reader["FirstName"]} \n" +
                                      $"Last Name: {reader["LastName"]}, \n" +
                                      $"Middle Name: {reader["MiddleName"]}, \n" +
                                      $"Document Number: {reader["DocumentNumber"]},\n" +
                                      $"Marital Status: {reader["MaritalStatus"]}, \n" +
                                      $"Age: {reader["Age"]}, \n" +
                                      $"The Sum Of Whole Incomes: {reader["TheSumOfWholeIncomes"]},  \n" +
                                      $"Expiry Of Credit History: {reader["ExpiryOfCreditHistory"]}, \n" +
                                      $"Credit History: {reader["CreditHistory"]}, \n" +
                                      $"Credit Goal: {reader["CreditGoal"]}, \n" +
                                      $"CreditDeadLine: {reader["CreditDeadLine"]} \n");


                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return 0;
        }
            public static int MyLoanLoginShow()
            {

                int Login;
                Console.Write("Login = ");
                Login = int.Parse(Console.ReadLine());
                return MyloanLogin(Login);
            }

    }
}


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
        public int CreditGoal { get; set; }
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
            using (var command = new SqlCommand($"select * from Customers c left join Credits cr on c.Id = cr.ClientId where c.Login = {Login}", connection))
            {
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]},\n" +
                                      $"FirstName: {reader["FirstName"]} \n" +
                                      $"LastName: {reader["LastName"]}," +
                                      $"MiddleName: {reader["MiddleName"]}, \n" + 
                                      $"MaritalStatus: {reader["MaritalStatus"]},\n" +
                                      $"Gender: {reader["Gender"]}, \n" +
                                      $"DocumentNumber{reader["DocumentNumber"]},\n" + 
                                      $"MaritalStatus: {reader["MaritalStatus"]}, \n" +
                                      $"Age: {reader["Age"]}, \n" +
                                      $"Citizenship: {reader["Citizenship"]},  \n" +
                                      $"TheSumOfWholeIncomes{reader["TheSumOfWholeIncomes"]},  \n" +
                                      $"ExpiryOfCreditHistory: {reader["ExpiryOfCreditHistory"]}, \n" +
                                      $"CreditHistory: {reader["CreditHistory"]}, \n" +
                                      $"CreditGoal: {reader["CreditGoal"]}, \n" +
                                      $"CreditDeadLine{reader["CreditDeadLine"]}"); 


                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return 0;
        }
        public static int ShowCodeId()
        {

            int Login;
            Console.Write("Please enter your login once more = ");
            Login = int.Parse(Console.ReadLine());
            return CodeId(Login);
        }

    }
}


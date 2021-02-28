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
        public string CreditGoal { get; set; }
        public DateTime CreditDeadLine { get; set; }

        public int CreateCreditModel()
        {
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("Insert into Credits(Gender, MaritalStatus, Age, Citizenship, TheSumOfWholeIncomes, ExpiryOfCreditHistory, CreditGoal, CreditDeadLine)" +
                " Values(@Gender, @MaritalStatus, @Age, @Citizenship, @TheSumOfWholeIncomes, @ExpiryOfCreditHistory, @CreditGoal, @CreditDeadLine)", connection))

            {
                try
                {
                    command.Parameters.AddWithValue("Gender", this.Gender);
                    command.Parameters.AddWithValue("MaritalStatus", this.MaritalStatus);
                    command.Parameters.AddWithValue("Age", this.Age);
                    command.Parameters.AddWithValue("Citizenship", this.Citizenship);
                    command.Parameters.AddWithValue("TheSumOfWholeIncomes", this.TheSumOfWholeIncomes);
                    command.Parameters.AddWithValue("ExpiryOfCreditHistory", this.ExpiryOfCreditHistory);
                    command.Parameters.AddWithValue("CreditGoal", this.CreditGoal);
                    command.Parameters.AddWithValue("CreditDeadLine", this.CreditDeadLine);


                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR  {ex.Message}");

                }
                finally
                {
                    connection.Close();
                }



            }
            return 0;

            
        }
        public static Credits CreateCredit()
        {
            try
            {
                return new Credits
                {
                    Gender = ConsoleWriteWithResult("Gender = "),
                    MaritalStatus = ConsoleWriteWithResult("Marital Status = "),
                    Age = Convert.ToInt32(ConsoleWriteWithResult("Age = ")),
                    Citizenship = ConsoleWriteWithResult("Citizenship = "),
                    TheSumOfWholeIncomes = Convert.ToDouble(ConsoleWriteWithResult("The Summ Of Whole Incomes = ")),
                    ExpiryOfCreditHistory = Convert.ToInt32(ConsoleWriteWithResult("Expiry of Credit History = ")),
                    CreditGoal = ConsoleWriteWithResult("Credit Goal"),
                    CreditDeadLine = Convert.ToDateTime(ConsoleWriteWithResult("Credit DeadLine"))
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Occured an error while creating an application {ex.Message}");

            };
            return null;

            static string ConsoleWriteWithResult(string text)
            {
                Console.Write(text);
                return Console.ReadLine();
            }
        }
    }
}


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
        public string CreditHistory { get; set; }
        public string CreditGoal { get; set; }
        public DateTime CreditDeadLine { get; set; }

        public int CreateCreditModel()
        {
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("Insert into Credits(Gender, MaritalStatus, Age, Citizenship, TheSumOfWholeIncomes, ExpiryOfCreditHistory, CreditHistory,CreditGoal, CreditDeadLine)" +
                " Values(@Gender, @MaritalStatus, @Age, @Citizenship, @TheSumOfWholeIncomes, @ExpiryOfCreditHistory,@CreditHistory , @CreditGoal, @CreditDeadLine)", connection))

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
        
    }
}


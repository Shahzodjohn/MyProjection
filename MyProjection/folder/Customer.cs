using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyProjection.folder
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DocumentNumber { get; set; }

        public int CreateCustomer()
        {
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("Insert into Customers(FirstName, LastName, MiddleName, DateOfBirth, DocumentNumber)" +
                " Values(@FirstName, @LastName, @MiddleName, @DateOfBirth, @DocumentNumber)", connection))

            {
                try
                {
                    command.Parameters.AddWithValue("FirstName", this.FirstName);
                    command.Parameters.AddWithValue("LastName", this.LastName);
                    command.Parameters.AddWithValue("MiddleName", this.MiddleName);
                    command.Parameters.AddWithValue("DateOfBirth", this.DateOfBirth);
                    command.Parameters.AddWithValue("DocumentNumber", this.DocumentNumber);
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


        

    }
}

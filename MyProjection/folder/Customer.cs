using System;
using System.Data.SqlClient;

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
        public string Login { get; set; }
        public string Password { get; set; }

        public int CreateCustomer()
        {
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("Insert into Customers(FirstName, LastName, MiddleName, DateOfBirth, DocumentNumber, Login, Password)" +
                " Values(@FirstName, @LastName, @MiddleName, @DateOfBirth, @DocumentNumber, @Login, @Password)", connection))

            {
                try
                {
                    command.Parameters.AddWithValue("FirstName", this.FirstName);
                    command.Parameters.AddWithValue("LastName", this.LastName);
                    command.Parameters.AddWithValue("MiddleName", this.MiddleName);
                    command.Parameters.AddWithValue("DateOfBirth", this.DateOfBirth);
                    command.Parameters.AddWithValue("DocumentNumber", this.DocumentNumber);
                    command.Parameters.AddWithValue("Login", this.Login);
                    command.Parameters.AddWithValue("Password", this.Password);
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

            //
        }
        public static int ShowCustomers()
        {

            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("Select * from Customers", connection))

            {
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]},\n" +
                              $"FirstName: {reader["FirstName"]} " +
                              $"LastName: {reader["LastName"]}," +
                             $"MiddleName: {reader["MiddleName"]}," +
                               $"DateOfBirth{reader["DateOfBirth"]}," +
                            $"DocumentNumber{reader["DocumentNumber"]}");
                }
                return 0;




            }

        }
        public static int ShowCustomersId(int Id)
        {
            
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand($"Select * from Customer where Id = {Id}" + Id, connection))

            {
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]},\n" +
                              $"FirstName: {reader["FirstName"]} " +
                              $"LastName: {reader["LastName"]}," +
                             $"MiddleName: {reader["MiddleName"]}," +
                               $"DateOfBirth{reader["DateOfBirth"]}," +
                            $"DocumentNumber{reader["DocumentNumber"]}");
                    
                    
                }
                return 0;
                

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public static int ShowCutromerIdmethod()
        {

            int Id;
            Console.Write("Id = ");
            Id = int.Parse(Console.ReadLine());

            return ShowCustomersId(Id);




        }
    }
}

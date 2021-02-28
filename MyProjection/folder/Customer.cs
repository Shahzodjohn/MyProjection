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
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Citizenship { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DocumentNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int CreateCustomer()
        {
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("Insert into Customers(FirstName, LastName, MiddleName, Gender, MaritalStatus, Citizenship, DateOfBirth, DocumentNumber, Login, Password)" +
                " Values(@FirstName, @LastName, @MiddleName, @Gender, @MaritalStatus, @Citizenship, @DateOfBirth, @DocumentNumber, @Login, @Password)", connection))

            {
                try
                {
                    command.Parameters.AddWithValue("FirstName", this.FirstName);
                    command.Parameters.AddWithValue("LastName", this.LastName);
                    command.Parameters.AddWithValue("MiddleName", this.MiddleName);
                    command.Parameters.AddWithValue("Gender", this.Gender);
                    command.Parameters.AddWithValue("MaritalStatus", this.MaritalStatus);
                    command.Parameters.AddWithValue("Citizenship", this.Citizenship);
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
                             $"Gender: {reader["Gender"]}," +
                             $"MaritalStatus: {reader["MaritalStatus"]}," +
                             $"Citizenship: {reader["Citizenship"]}," +
                               $"DateOfBirth{reader["DateOfBirth"]}," +
                            $"DocumentNumber{reader["DocumentNumber"]}");
                }
                return 0;
            }

        }
        public static int ShowCustomersId(int Id)
        {
            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand($"Select * from Customers where Id = {Id}", connection))
            {
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine($"Id: {reader["Id"]}, \n" +
                              $"FirstName: {reader["FirstName"]},  " +
                              $"LastName: {reader["LastName"]},  " +
                             $"MiddleName: {reader["MiddleName"]},  " +
                               $"DateOfBirth{reader["DateOfBirth"]},  " +
                               $"Gender: {reader["Gender"]}," +
                               $"MaritalStatus: {reader["MaritalStatus"]}," +
                             $"Citizenship: {reader["Citizenship"]}," +
                            $"DocumentNumber{reader["DocumentNumber"]}  ");


                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return 0;
        }

        public static int ShowCutromerIdmethod()
        {

            int Id;
            Console.Write("Id = ");
            Id = int.Parse(Console.ReadLine());
            return ShowCustomersId(Id);
        }
        public int UpdateCustomer()
        {

            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("Update Customers set FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, Gender = @Gender, MaritalStatus = @MaritalStatus, Citizenship = @Citizenship, DateOfBirth = @DateOfBirth, DocumentNumber = @DocumentNumber, Login = @Login, Password = @Password " +
                "where Id = @Id", connection))

            {
                try
                {

                    command.Parameters.AddWithValue("FirstName", this.FirstName);
                    command.Parameters.AddWithValue("LastName", this.LastName);
                    command.Parameters.AddWithValue("MiddleName", this.MiddleName);
                    command.Parameters.AddWithValue("Gender", this.Gender);
                    command.Parameters.AddWithValue("MaritalStatus", this.MaritalStatus);
                    command.Parameters.AddWithValue("Citizenship", this.Citizenship);
                    command.Parameters.AddWithValue("DateOfBirth", this.DateOfBirth);
                    command.Parameters.AddWithValue("DocumentNumber", this.DocumentNumber);
                    command.Parameters.AddWithValue("Login", this.Login);
                    command.Parameters.AddWithValue("Password", this.Password);
                    command.Parameters.AddWithValue("Id", this.Id);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    return result;


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR  {ex.Message}");
                    Console.ReadLine();
                }
                finally
                {
                    connection.Close();
                }



            }
            return 0;

        }



        public static void DeleteCustomer()
        {

            using (var connection = SqlClientModel.GetNewSqlConnection())
            using (var command = new SqlCommand("Delete Customers where Id = @Id ", connection))

            {
                try
                {

                    Console.Write("Введите ID пользователя которого хотите удалить = ");
                    int Id = int.Parse(Console.ReadLine());
                    command.Parameters.AddWithValue("Id", Id);
                    connection.Open();
                    var result = command.ExecuteNonQuery(); 
                    if (result > 0)
                    {
                        Console.WriteLine("This User is successfully deleted");
                    }
                    if (result <= 0)
                    {
                        Console.WriteLine("Error while deleting a User");
                    }
                    

                    


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR  {ex.Message}");
                    Console.ReadLine();
                }
                finally
                {
                    connection.Close();

                }
                Console.ReadKey();



            };

        }
    }
}

             


        
                    
           

                    



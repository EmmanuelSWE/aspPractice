using Microsoft.Data.SqlClient; 


namespace testServer.Models.DataAccess
{
    public static class DB
    {
        private static readonly string _connectionString = "Server=localhost,1433;Database=aspTest;User Id=sa;" +
        "Password=CookAzureDBAshimwe@B0x;Encrypt=True;TrustServerCertificate=True;";

        public static SqlConnection Open()
        {
            var connection = new SqlConnection(_connectionString);
           try
            {
                connection.Open();
                Console.WriteLine("Database connection opened successfully.");
            }
            catch (SqlException ex)
            {
                // Handle the exception as needed, e.g., log it or rethrow
                Console.WriteLine($"SQL Exception: {ex.Message}");
                throw; // Rethrow the exception after logging
            }
            return connection;
        }

    }
}
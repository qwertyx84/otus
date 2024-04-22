using Npgsql;

class Program
{
    static async Task Main()
    {
        try
        {
            var con = new NpgsqlConnection(connectionString: "Server=localhost;Port=54329;UserName=postgres;Password=postgres123;Database=ebay_db;");
            con.Open();

            NpgsqlDataReader reader = await new NpgsqlCommand
            {
                Connection = con,
                CommandText = "select * from users"
            }.ExecuteReaderAsync();
            Console.WriteLine("Users:");
            while (await reader.ReadAsync())
            {
                Console.WriteLine($"User ID: {reader.GetInt32(0)}, Username: {reader.GetString(1)}, Email: {reader.GetString(2)}");
            }
            reader.Close();

            reader = await new NpgsqlCommand
            {
                Connection = con,
                CommandText = "select * from products"
            }.ExecuteReaderAsync();
            Console.WriteLine("\nProducts:");
            while (await reader.ReadAsync())
            {
                Console.WriteLine($"Product ID: {reader.GetInt32(0)}, Product Name: {reader.GetString(1)}, Price: {reader.GetFloat(2)}");
            }
            reader.Close();

            reader = await new NpgsqlCommand
            {
                Connection = con,
                CommandText = "select * from orders"
            }.ExecuteReaderAsync();
            Console.WriteLine("\nOrders:");
            while (await reader.ReadAsync())
            {
                Console.WriteLine($"Order ID: {reader.GetInt32(0)}, User ID: {reader.GetInt32(1)}, Product ID: {reader.GetInt32(2)}, Order Date: {reader.GetDate(3)}");
            }
            reader.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}

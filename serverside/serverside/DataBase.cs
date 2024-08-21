using System.Data.SqlClient;
using System.Data;


namespace DataBase
{
    internal class DataClass
    {
        public SqlConnection connect = new SqlConnection(locate);
        public SqlCommand cmd = new SqlCommand();
        public static string locate = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#\\serverside\\serverside\\Database1.mdf;Integrated Security=True";
        public void DatabaseInsert(string username, string password)
        {
            DataClass obj = new DataClass();
            //obj.connect.ConnectionString = obj.locate;
            obj.connect.Open();
            int j=UserPassSearch(username, password);
            if (j == 0)
            {
                string interuser = "INSERT INTO [Table] (username,password) VALUES(@username,@password)";
                obj.cmd.Connection = obj.connect;
                obj.cmd.CommandText = interuser;
                obj.cmd.Parameters.AddWithValue("@username", username);
                obj.cmd.Parameters.AddWithValue("@password", password);
                obj.cmd.ExecuteNonQuery();
            }
            else
            {
                Console.WriteLine("account already created");
            }
            obj.connect.Close();
        }

        public int AccountSearch(string username, string password)
        {
            DataClass obj = new DataClass();
            //obj.connect.ConnectionString = obj.locate;
            obj.connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM [Table] WHERE username='" + username + "' AND password='" + password + "' ", obj.connect);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            obj.connect.Close();
            return int.Parse(dt.Rows[0][0].ToString());
        }

        public int UserPassSearch(string username, string password)
        {
            DataClass obj = new DataClass();
            //obj.connect.ConnectionString = obj.locate;
            obj.connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM [Table] WHERE username='" + username + "' OR password='" + password + "' ", obj.connect);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            obj.connect.Close();
            return int.Parse(dt.Rows[0][0].ToString());
        }

        public void CreateTable(string username)
        {
            DataClass obj = new DataClass();
            Console.WriteLine("Testing 1 ...");
            string createTableQuery = @"
                    CREATE TABLE Client" +username+ @"Table(
                        Ping Float,
                        DownloadSpeed Float,
                        UploadSpeed Float
                    );";
            //obj.connect.ConnectionString = obj.locate;
            obj.connect.Open();
            SqlCommand command = new SqlCommand(createTableQuery, obj.connect);
            command.ExecuteNonQuery();
            Console.WriteLine("Table created successfully.");
            obj.connect.Close();
        }

        public void DeleteTable(string username)
        {
            DataClass obj = new DataClass();
            Console.WriteLine("Client" + username + "Table");
            string createTableQuery = @"
                    DROP TABLE Client" + username + @"Table";
            //obj.connect.ConnectionString = obj.locate;
            obj.connect.Open();
            SqlCommand command = new SqlCommand(createTableQuery, obj.connect);
            command.ExecuteNonQuery();
            Console.WriteLine("Table deleted successfully.");
            obj.connect.Close();
        }

        public int SearchTable(string username)
        {
            DataClass obj = new DataClass();
            //obj.connect.ConnectionString = obj.locate;
            connect.Open();
            string tableName = "Client" + username + "Table";
            Console.WriteLine("testing if database exist");
            string searchTableQuery = @"
                    SELECT CASE 
                        WHEN EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName AND TABLE_TYPE = 'BASE TABLE') 
                        THEN 1 
                        ELSE 0 
                    END";

            SqlCommand command = new SqlCommand(searchTableQuery, connect);
            command.Parameters.AddWithValue("@TableName", tableName);

            object result = command.ExecuteScalar();
            connect.Close();

            if (result != null && (int)result == 1)
            {
                Console.WriteLine("table exist");
                return 1;
            }
            else
            {
                Console.WriteLine("table does not exist");
                return 0;
            }
        }

        public void TestsInsert(string name, string data)
        {
            DataClass obj = new DataClass();
            string[] substring = data.Split('*');
            //obj.connect.ConnectionString = obj.locate;
            obj.connect.Open();
            string tablename = "Client" + name + "Table";
            string interuser = "INSERT INTO [" + tablename + "] (Ping,DownloadSpeed,UploadSpeed) VALUES(@Ping,@DownloadSpeed,@UploadSpeed)";
            obj.cmd.Connection = obj.connect;
            obj.cmd.CommandText = interuser;
            obj.cmd.Parameters.AddWithValue("@Ping", Math.Round(float.Parse(substring[4]),2));
            obj.cmd.Parameters.AddWithValue("@DownloadSpeed", Math.Round(float.Parse(substring[2]),2));
            obj.cmd.Parameters.AddWithValue("@UploadSpeed", Math.Round(float.Parse(substring[3]),2));
            obj.cmd.ExecuteNonQuery();
            obj.connect.Close();
        }

        public double PingAverage(string name)
        {
            //DataClass obj = new DataClass();
            connect.Open();
            string tablename = "Client" + name + "Table";
            SqlCommand command = new SqlCommand($"SELECT AVG(Ping) FROM {tablename}", connect);
            object result = command.ExecuteScalar();
            connect.Close();
            if (result != DBNull.Value)
            {
                double average = Convert.ToDouble(result);
                return Math.Round(average,2);
            }
            else
            {
                return 0;
            }
        }

        public double PingVariance(string name)
        {
            //DataClass obj = new DataClass();
            connect.Open();
            string tablename = "Client" + name + "Table";
            SqlCommand command = new SqlCommand($"SELECT VAR(Ping) FROM {tablename};", connect);
            object result = command.ExecuteScalar();
            connect.Close();
            if (result != DBNull.Value)
            {
                double average = Convert.ToDouble(result);
                return Math.Round(Math.Sqrt(average), 2);
            }
            else
            {
                return 0;
            }
        }

        public double DownloadSpeedAverage(string name)
        {
            //DataClass obj = new DataClass();
            connect.Open();
            string tablename = "Client" + name + "Table";
            SqlCommand command = new SqlCommand($"SELECT AVG(DownloadSpeed) FROM {tablename}", connect);
            object result = command.ExecuteScalar();
            connect.Close();
            if (result != DBNull.Value)
            {
                double average = Convert.ToDouble(result);
                return Math.Round(average,2);
            }
            else
            {
                return 0;
            }
        }

        public double UploadSpeedAverage(string name)
        {
            //DataClass obj = new DataClass();
            connect.Open();
            string tablename = "Client" + name + "Table";
            SqlCommand command = new SqlCommand($"SELECT AVG(UploadSpeed) FROM {tablename}", connect);
            object result = command.ExecuteScalar();
            connect.Close();
            if (result != DBNull.Value)
            {
                double average = Convert.ToDouble(result);
                return Math.Round(average, 2);
            }
            else
            {
                return 0;
            }
        }
    }
}

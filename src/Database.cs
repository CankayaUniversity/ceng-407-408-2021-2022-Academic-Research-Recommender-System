using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CENG408
{
    public class Database
    {
        public Server server;
        private string sql;
        public NpgsqlDataReader data;
        public Database(string sql, IConfiguration server)
        {
            this.sql = sql;
            this.server = new Server(server);
            NpgsqlCommand query = new NpgsqlCommand(sql, this.server.conn);
            data = query.ExecuteReader();
        }
    }

    public class Server
    {
        public NpgsqlConnection conn;
        public Server(IConfiguration server)
        {
            string connstring = "User ID=postgres;Password=1998;Server=localhost;Port=5432;Database=hypercorrect;";
            //string connstring = "User ID=postgres;Password=mysecretpassword;Server=127.0.0.1;Port=5432;Database=postgres;";

                            //user = "postgres",
                            //password = "mysecretpassword",
                            //host = "127.0.0.1",
                            //port = "5432",
                            //database = "postgres"

            //string.Format(
            //server.GetSection("ConnectionString").GetSection("MyServer").Value
            //);
            conn = new NpgsqlConnection(connstring);
            conn.Open();
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hypercorrect
{
	public class Database
	{
		public Server server;
		private string sql;
		public NpgsqlDataReader Select(string sql, IConfiguration server)
		{
			this.sql = sql;
			this.server = new Server(server);
			NpgsqlCommand query = new NpgsqlCommand(sql, this.server.conn);
			//var reader = query.ExecuteReader();
			return query.ExecuteReader();
			//return reader;
		}
		public int Insert(string sql, IConfiguration server, Dictionary<string, string> args)
		{
			this.sql = sql;
			this.server = new Server(server);

			NpgsqlCommand query = new NpgsqlCommand(sql, this.server.conn);

			foreach (var arg in args)
			{
				query.Parameters.Add(new(arg.Key, arg.Value));
			}
			return query.ExecuteNonQuery();
		}
	}

	public class Server
	{
		public NpgsqlConnection conn;
		public Server(IConfiguration server)
		{
			string connstring = "User ID=postgres;Password=1998;Server=localhost;Port=5432;Database=hyperdb;";
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


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
	public class DBHelperBarcode
	{
		private SqlConnection conn;

		public DBHelperBarcode()
		{
			// 데이터베이스 연결 문자열 초기화
			string dataSource = "909MA";//KB-PC
			string db = "MYDB";
			string security = "SSPI";
			string connectionString = $"Data Source={dataSource}; Initial Catalog={db};" +
				$"Integrated Security={security}; Timeout=30";
			conn = new SqlConnection(connectionString); // SqlConnection 객체를 생성하여 연결 문자열을 할당
		}

		public void OpenConnection()
		{
			if (conn.State == System.Data.ConnectionState.Closed)
			{
				conn.Open();
			}
		}

		public void CloseConnection()
		{
			if (conn.State == System.Data.ConnectionState.Open)
			{
				conn.Close();
			}
		}

		public SqlDataReader ExecuteReader(string query)
		{
			SqlCommand command = new SqlCommand(query, conn);
			return command.ExecuteReader();
		}

		public int ExecuteNonQuery(string query)
		{
			SqlCommand command = new SqlCommand(query, conn);
			return command.ExecuteNonQuery();
		}
	}
}


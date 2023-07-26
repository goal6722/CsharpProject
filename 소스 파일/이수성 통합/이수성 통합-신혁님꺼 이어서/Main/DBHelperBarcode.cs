using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Main
{
	public class DBHelperBarcode
	{
		private SqlConnection conn;

		public DBHelperBarcode()
		{
			// 데이터베이스 연결 문자열 초기화
			string dataSource = "KB-PC";//KB-PC
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

		// GetInventoryData 메서드를 public으로 선언
		public void GetInventoryData(string searchValue)
		{
			try
			{
				// 이미 데이터베이스에 연결되어 있는지 확인
				if (conn.State == System.Data.ConnectionState.Closed)
				{   // 데이터베이스에 연결되어 있지 않다면 연결 열기
					conn.Open();
				}

				// 데이터를 받아올 쿼리 작성 (검색 값으로 조건 추가)
				string query = $"SELECT [count], [img_prod_nm], [sale] FROM [MYDB].[dbo].[Mylnventory] WHERE [column_name] = '{searchValue}'";

				// 쿼리 실행을 위한 SqlCommand 객체 생성
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					// 데이터를 가져올 수 있는 SqlDataReader 객체 생성
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							// 가져온 데이터를 원하는 방식으로 처리
							int count = reader.GetInt32(0); 
							string img_prod_nm = reader.GetString(1); 
							double sale = reader.GetDouble(2); 							  
						}
						else
						{  
							//MessageBox.Show("검색 결과가 없습니다.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				//MessageBox.Show($"데이터를 가져오는 중 오류가 발생했습니다: {ex.Message}");
			}
			finally
			{
				// 데이터베이스 연결을 닫지 않고 유지
				
			}
		}


	}
}


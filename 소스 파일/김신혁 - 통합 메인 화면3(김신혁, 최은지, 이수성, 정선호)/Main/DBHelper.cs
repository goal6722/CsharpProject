using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class DBHelper
{
	private static SqlConnection conn = new SqlConnection();

	private static void ConnectDB()
	{
		string dataSource = "KB-PC";//KB-PC
		string db = "MYDB";
		string security = "SSPI";
		conn = new SqlConnection();
		conn.ConnectionString =
			$"Data Source={dataSource}; Initial Catalog={db};" +
			$"Integrated Security={security}; Timeout=30";
		conn.Open();
	}


	public static Dictionary<string, int> GetDivLCounts()
	{
		Dictionary<string, int> divLCounts = new Dictionary<string, int>();
		NewMethod(divLCounts);

		return divLCounts;
	}

	private static void NewMethod(Dictionary<string, int> divLCounts)
	{
		try
		{
			ConnectDB();

			string query = "SELECT div_l, COUNT(*) AS count FROM MyProduct GROUP BY div_l";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string divLValue = reader["div_l"].ToString();
						int count = Convert.ToInt32(reader["count"]);
						divLCounts.Add(divLValue, count);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
		finally
		{
			conn.Close();
		}
	}

	public static List<string> DivListL(string targetDiv)//콤보박스에 분류 종류 받아옴
	{
		List<string> divList = new List<string>();

		try
		{
			ConnectDB();

			string query = $"SELECT DISTINCT {targetDiv} FROM MyProduct";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string divLValue = reader[targetDiv].ToString();
						divList.Add(divLValue);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
		finally
		{
			conn.Close();
		}
		return divList;
	}

	public static List<string> DivListMnS(string targetDiv, string targetDivUp, string constName)//콤보박스에 분류 종류 받아옴
	{
		List<string> divList = new List<string>();

		try
		{
			ConnectDB();

			string query = $"SELECT DISTINCT {targetDiv} FROM MyProduct WHERE {targetDivUp} = {constName}";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string divLValue = reader[targetDiv].ToString();
						divList.Add(divLValue);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
		finally
		{
			conn.Close();
		}
		return divList;
	}
	public static Dictionary<string, int> GetFilteredData(string columnName, string divUp, string divDown)
	{
		Dictionary<string, int> filteredData = new Dictionary<string, int>();

		try
		{
			ConnectDB();

			string query = $"SELECT {divDown}, COUNT(*) AS count FROM MyProduct WHERE {divUp} = {columnName} GROUP BY {divDown}";

			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						string divValue = reader[divDown].ToString();
						int count = Convert.ToInt32(reader["count"]);
						filteredData.Add(divValue, count);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
		finally
		{
			conn.Close();
		}

		return filteredData;
	}

	public static string CountDB()
	{
		string countNum = "NULL";
		try
		{
			ConnectDB();
			string query = "SELECT COUNT(*) AS count FROM MyProduct";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				countNum = cmd.ExecuteScalar().ToString();
			}


		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
		finally
		{
			conn.Close();
		}
		return countNum;
	}
	public static string Item_no_2_Product_name(string item_no)
	{
		string Product_name = null;
		try
		{
			ConnectDB();
			string query = $"SELECT img_prod_nm FROM MyProduct WHERE item_no = '{item_no}'";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				var result = cmd.ExecuteScalar();
				Product_name = result.ToString();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
		finally
		{
			conn.Close();
		}
		return Product_name;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace csharpMyCProject
{
	public partial class Form1 : Form
	{
		private SqlConnection conn;
		private DataTable dataTable = new DataTable(); // Form1 클래스의 멤버 변수로 선언
		private List<ShoppingCart> cartList = new List<ShoppingCart> ();

		public Form1()
		{
			InitializeComponent();

			
			// 데이터베이스 연결 문자열 초기화
			string dataSource = "KB-PC";
			string db = "MYDB";
			string security = "SSPI";
			string connectionString = $"Data Source={dataSource}; Initial Catalog={db};" +
				$"Integrated Security={security}; Timeout=3";

			conn = new SqlConnection(connectionString); // SqlConnection 객체를 생성하여 연결 문자열을 할당

		}


		private void GetInventoryData(string searchValue)
		{
			try
			{
				// 이미 데이터베이스에 연결되어 있는지 확인
				if (conn.State == System.Data.ConnectionState.Closed)
				{
					// 데이터베이스에 연결되어 있지 않다면 연결 열기
					conn.Open();
				}

				// 데이터를 받아올 쿼리 작성 (검색 값으로 조건 추가)
				string query = $"SELECT [count], [img_prod_nm], [sale] FROM [MYDB].[dbo].[Mylnventory] WHERE [column_name] = '{searchValue}'"; // column_name은 실제 테이블의 검색에 사용할 열 이름입니다.

				// 쿼리 실행을 위한 SqlCommand 객체 생성
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					// 데이터를 가져올 수 있는 SqlDataReader 객체 생성
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							// 가져온 데이터를 원하는 방식으로 처리
							int count = reader.GetInt32(0); // 첫 번째 열 "count"의 값 가져옴
							string img_prod_nm = reader.GetString(1); // 두 번째 열 "img_prod_nm"의 값 가져옴
							double sale = reader.GetDouble(2); // 세 번째 열 "sale"의 값 가져옴

							// 여기서 가져온 데이터를 원하는 방식으로 처리
							// 예를 들면, 라벨에 표시하거나 변수에 저장하는 등의 작업을 수행
						}
						else
						{
							// 검색 결과가 없는 경우, 처리할 로직 (예: 메시지 출력 )
						}
					}
				}
			}
			catch (Exception ex)
			{
				// 에러 처리
				// ex.Message를 이용하여 에러 메시지를 출력하거나 로그에 기록할 수 있음
			}
			finally
			{
				// 데이터베이스 연결을 닫지 않고 유지
				// 필요에 따라서 메서드가 끝날 때나 애플리케이션이 종료될 때 데이터베이스 연결을 닫아주어야 함
			}
		}


		private void search_Click(object sender, EventArgs e)
		{
			string searchValue = barcd.Text.Trim(); // "barcd" 텍스트 상자에 입력한 값을 가져옴

			if (string.IsNullOrEmpty(searchValue))
			{
				// 검색 값이 비어있는 경우, 처리할 로직 (예: 에러 메시지 출력 )
				// 여기서는 간단하게 아무 작업도 하지 않도록 하기
				return;
			}

			// 데이터베이스 연결
			using (SqlConnection conn = new SqlConnection())
			{
				string dataSource = "KB-PC";
				string db = "MYDB";
				string security = "SSPI";
				conn.ConnectionString =
					$"Data Source={dataSource}; Initial Catalog={db};" +
					$"Integrated Security={security}; Timeout=3";

				conn.Open();

				// 데이터를 받아올 쿼리 작성 (검색 값으로 조건 추가)
				string query = $"SELECT count, img_prod_nm, sale FROM MyInventory WHERE barcd = '{searchValue}'";
				// 쿼리 실행을 위한 SqlCommand 객체 생성
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					// 데이터를 가져올 수 있는 SqlDataReader 객체 생성
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							// 조회된 데이터를 라벨에 표시
							string item = reader["img_prod_nm"].ToString(); // "img_prod_nm"의 값 가져옴
							int count = Convert.ToInt32(reader["count"]); //  "count"의 값 가져옴
							decimal pay = Convert.ToInt32(reader["sale"]);// "sale"의 값 가져옴

							// 라벨에 데이터를 표시하는 예시                                                                                                             
							item_label.Text = $"Item: {item}";
							count_label.Text = $"Count: {count}";
							pay_label.Text = $"Pay: {pay}";
						}
						else
						{
							// 검색 결과가 없는 경우, 처리할 로직 (예: 메시지 출력 등)
							// 여기서는 간단하게 아무 작업도 하지 않도록 하기
						}
					}
				}
			}
		}

		private void add_Click(object sender, EventArgs e)
		{
			string barcdValue = barcd.Text.Trim(); // 텍스트 입력창에서 바코드 값을 가져옴

			// 바코드 값이 비어있는 경우 처리
			if (string.IsNullOrEmpty(barcdValue))
			{
				MessageBox.Show("바코드 값을 입력하세요.");
				return;
			}

			try
			{
				// 데이터베이스 연결 상태 확인
				if (conn.State == ConnectionState.Closed)
				{
					conn.Open(); // 데이터베이스 연결 열기
				}
				ShoppingCart cart = new ShoppingCart();
				// 데이터를 받아올 쿼리 작성 (검색 값으로 조건 추가)
				string query = $"SELECT count, img_prod_nm, sale FROM MyInventory WHERE barcd = '{barcdValue}'";
				// 쿼리 실행을 위한 SqlCommand 객체 생성
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					// 데이터를 가져올 수 있는 SqlDataReader 객체 생성
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							// 조회된 데이터를 라벨에 표시
							string item = reader["img_prod_nm"].ToString(); // "img_prod_nm"의 값 가져옴
							int count = Convert.ToInt32(reader["count"]);	// "count"의 값 가져옴
							decimal pay = Convert.ToInt32(reader["sale"]);  // "sale"의 값 가져옴
							
							cart = new ShoppingCart();
							cart.item = item;
							cart.barcode = barcdValue;
							cart.pay = Convert.ToInt32(pay);
							// 라벨에 데이터를 표시하는 예시                                                                                                             
							//item_label.Text = $"Item: {item}";
							//count_label.Text = $"Count: {count}";
							//pay_label.Text = $"Pay: {pay}";
						}
						else
						{
							MessageBox.Show("해당하는 상품이 없습니다.");
							return;
						}
					}
				}
				string updateQuery = "UPDATE [dbo].[MyInventory] SET [count] = [count] - 1 WHERE barcd = @Barcd";
				using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
				{
					updateCommand.Parameters.AddWithValue("@Barcd", barcdValue);
					updateCommand.ExecuteNonQuery();
				}
				try
				{
					//해당 항목의 count를 늘린다.
					ShoppingCart item = cartList.Single(x => x.barcode.Equals(barcdValue));
					item.count++;
					item.pay += item.pay;
				}
				catch (Exception)
				{
					//신규 추가
					cart.count = 1;
					cartList.Add(cart);
					

				}

				dataGridView1.DataSource = null;
				dataGridView1.DataSource = cartList;

				//int count = 0;
				// 해당 바코드와 일치하는 데이터가 있는지 검색
				//string searchQuery = "SELECT * FROM [dbo].[MyInventory] WHERE barcd = @Barcd";
				//using (SqlCommand searchCommand = new SqlCommand(searchQuery, conn))
				//{
				//	searchCommand.Parameters.AddWithValue("@Barcd", barcdValue);
				//	//count = (int)searchCommand.ExecuteScalar();

				//}

				//if (count > 0)
				//{
				//	// 해당 바코드와 일치하는 데이터가 있으면 개수를 1개 차감
				//	string updateQuery = "UPDATE [dbo].[MyInventory] SET [count] = [count] - 1 WHERE barcd = @Barcd";
				//	using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
				//	{
				//		updateCommand.Parameters.AddWithValue("@Barcd", barcdValue);
				//		updateCommand.ExecuteNonQuery();
				//	}
				//	try
				//	{
				//		ShoppingCart item = cartList.Single(x => x.barcode.Equals(barcdValue));
				//	}
				//	catch (Exception)
				//	{

				//		throw;
				//	}
				//	// 데이터 그리드 뷰 업데이트
				//	//UpdateDataGridView();
				//}
				//else
				//{
				//	MessageBox.Show("해당하는 상품이 없습니다.");
				//}
			}
			catch (Exception ex)
			{
				MessageBox.Show("오류가 발생했습니다: " + ex.Message);
			}
		}
		private void UpdateDataGridView()
		{
			try
			{
				// 데이터를 받아올 쿼리 작성
				string query = "SELECT [count], [img_prod_nm], [sale] FROM [MYDB].[dbo].[MyInventory]";

				// 쿼리 실행을 위한 SqlCommand 객체 생성
				using (SqlCommand command = new SqlCommand(query, conn))
				{
					// 데이터를 가져올 수 있는 SqlDataReader 객체 생성
					using (SqlDataReader reader = command.ExecuteReader())
					{
						//DataTable dataTable = new DataTable();
						dataTable.Clear(); // 이전 데이터를 지우고 새로운 데이터로 업데이트
						dataTable.Load(reader);

						// DataGridView에 데이터 바인딩
						dataGridView1.DataSource = dataTable;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("오류가 발생했습니다: " + ex.Message);
			}
		}
	}
}
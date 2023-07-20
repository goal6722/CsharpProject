using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReProject
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            DataGridView1.CellClick += DataGridView1_CellContentClick;

            ConnectDB();
            LoadDataToDataGridView();

        }
        // 전역 변수로 SqlConnection 객체 생성
        private SqlConnection conn = new SqlConnection();
        // 전역 변수로 product 데이터를 저장할 List
        private List<product> productList = new List<product>();


        private void ConnectDB()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                string dataSource = "KB-PC";
                string db = "MYDB";
                string security = "SSPI";
                conn.ConnectionString =
                    $"Data Source={dataSource}; Initial Catalog={db};" +
                    $"Integrated Security={security}; Timeout=3";

                conn.Open();
                
            }
        }
        private void LoadDataToDataGridView()
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    ConnectDB(); // 연결을 여기서 열기

                    // SQL 쿼리문 작성 (MyProduct 테이블을 사용하도록 수정)
                    string query = "SELECT [position], [count], [item_cd], [item_no], [div_l], [div_m], [div_s], [div_n], [comp_nm], [img_prod_nm], [volume], [barcd], [purchase], [sale], [nutrition_info] FROM [MYDB].[dbo].[Mylnventory]";

                    // SQL 쿼리를 실행하기 위한 커맨드 생성
                    command.Connection = conn;
                    command.CommandText = query;

                    // 쿼리 실행 후 결과 가져오기
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<product> newProductList = new List<product>();

                        while (reader.Read())
                        {
                            product newItem = new product
                            {
                                item_cd = reader["item_cd"].ToString(),
                                item_no = reader["item_no"].ToString(),
                                div_l = reader["div_l"].ToString(),
                                div_m = reader["div_m"].ToString(),
                                div_s = reader["div_s"].ToString(),
                                div_n = reader["div_n"].ToString(),
                                comp_nm = reader["comp_nm"].ToString(),
                                img_prod_nm = reader["img_prod_nm"].ToString(),
                                volume = reader["volume"].ToString(),
                                barcd = reader["barcd"].ToString(),
                                nutrition_info = reader["nutrition_info"].ToString(),
                                position = reader["position"].ToString(),
                                count = Convert.ToInt32(reader["count"]),
                                purchase = Convert.ToDecimal(reader["purchase"]),
                                sale = Convert.ToDecimal(reader["sale"])
                            };
                            newProductList.Add(newItem);
                        }

                        productList = newProductList;
                    }

                    // 연결을 닫지 않고 유지합니다.
                    //conn.Close();
                }

                // DataGridView 갱신
                UpdateDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다: " + ex.Message);
            }
        }
        private void SaveDataToDB(List<product> productList)
        {
            ConnectDB();

            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                try
                {
                    foreach (var productItem in productList)
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = System.Data.CommandType.Text;

                            // 이미 해당 위치와 바코드로 기존에 저장된 상품이 있는지 확인
                            cmd.CommandText = $"SELECT COUNT(*) FROM Mylnventory WHERE position = @position AND barcd = @barcd";
                            cmd.Parameters.AddWithValue("@position", productItem.position);
                            cmd.Parameters.AddWithValue("@barcd", productItem.barcd);
                            int existingCount = (int)cmd.ExecuteScalar();

                            if (existingCount > 0)
                            {
                                // 이미 해당 위치와 바코드로 기존에 저장된 상품이 있다면 UPDATE 수행
                                cmd.CommandText = $"UPDATE Mylnventory SET count = @count, purchase = @purchase, sale = @sale WHERE position = @position AND barcd = @barcd";
                            }
                            else
                            {
                                // 해당 위치와 바코드로 기존에 저장된 상품이 없다면 INSERT 수행
                                cmd.CommandText = $"INSERT INTO Mylnventory (item_cd, item_no, div_l, div_m, div_s, div_n, comp_nm, img_prod_nm, volume, barcd, nutrition_info, position, count, purchase, sale) " +
                                                  "VALUES (@item_cd, @item_no, @div_l, @div_m, @div_s, @div_n, @comp_nm, @img_prod_nm, @volume, @barcd, @nutrition_info, @position, @count, @purchase, @sale)";
                            }

                            // 기존에 추가된 매개 변수를 모두 제거
                            cmd.Parameters.Clear();

                            // 매개 변수 다시 추가
                            cmd.Parameters.AddWithValue("@item_cd", productItem.item_cd);
                            cmd.Parameters.AddWithValue("@item_no", productItem.item_no);
                            cmd.Parameters.AddWithValue("@div_l", productItem.div_l);
                            cmd.Parameters.AddWithValue("@div_m", productItem.div_m);
                            cmd.Parameters.AddWithValue("@div_s", productItem.div_s);
                            cmd.Parameters.AddWithValue("@div_n", productItem.div_n);
                            cmd.Parameters.AddWithValue("@comp_nm", productItem.comp_nm);
                            cmd.Parameters.AddWithValue("@img_prod_nm", productItem.img_prod_nm);
                            cmd.Parameters.AddWithValue("@volume", productItem.volume);
                            cmd.Parameters.AddWithValue("@barcd", productItem.barcd);
                            cmd.Parameters.AddWithValue("@nutrition_info", productItem.nutrition_info);
                            cmd.Parameters.AddWithValue("@position", productItem.position);
                            cmd.Parameters.AddWithValue("@count", productItem.count);
                            cmd.Parameters.AddWithValue("@purchase", productItem.purchase);
                            cmd.Parameters.AddWithValue("@sale", productItem.sale);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("데이터가 저장되었습니다.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("오류가 발생했습니다: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void Barcd_F_T_TextChanged(object sender, EventArgs e)
        {
            // Barcd_F_T 텍스트 상자에서 바코드 값을 가져옴
            string barcode = Barcd_F_T.Text;

            if (string.IsNullOrWhiteSpace(barcode))
            {
                ClearLabels();


            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
            // Barcd_F_T 텍스트 상자에서 바코드 값을 가져옴
            string barcode = Barcd_F_T.Text;
            ClearLabels();
            // 바코드가 비어있을 경우 라벨을 초기화하고 바로 리턴
            if (string.IsNullOrWhiteSpace(barcode))
            {
                ClearLabels();


                // 빈 바코드로 조회를 하지 않도록 리턴
                return;
            }

            // 데이터베이스 연결 확인 및 연결
            ConnectDB();

            // SQL 쿼리문 작성 (MyProduct 테이블을 사용하도록 수정)
            string query = "SELECT [item_cd], [item_no], [div_l], [div_m], [div_s], [div_n], [comp_nm], [img_prod_nm], [volume], [barcd], [nutrition_info] FROM [MYDB].[dbo].[MyProduct] WHERE [barcd] = @barcode";

            // SQL 쿼리를 실행하기 위한 커맨드 생성
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // 바코드 매개변수 추가
                command.Parameters.AddWithValue("@barcode", barcode);

                try
                {
                    // 쿼리 실행 후 결과 가져오기
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            item_cd_Label.Text = reader["item_cd"].ToString();
                            item_no_Label.Text = reader["item_no"].ToString();
                            div_l_Label.Text = reader["div_l"].ToString();
                            div_m_Label.Text = reader["div_m"].ToString();
                            div_s_Label.Text = reader["div_s"].ToString();
                            div_n_Label.Text = reader["div_n"].ToString();
                            comp_nm_Label.Text = reader["comp_nm"].ToString();
                            img_prod_nm_Label.Text = reader["img_prod_nm"].ToString();
                            volume_Label.Text = reader["volume"].ToString();
                            barcd_Label.Text = reader["barcd"].ToString();
                            nutrition_info_Label.Text = reader["nutrition_info"].ToString();
                            position_T.Text = "";
                            count_T.Text = "";
                            purchase_T.Text = "";
                            sale_T.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("해당 바코드의 정보를 찾을 수 없습니다.");


                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류가 발생했습니다: " + ex.Message);
                }
            }
            // 쿼리 실행 후에는 연결을 닫아줍니다.
            conn.Close();
        }

        private void UpdateDataGridView()
        {
            DataGridView1.DataSource = null;
            DataGridView1.DataSource = productList;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string barcode = barcd_Label.Text;
            string position = position_T.Text;
            string countText = count_T.Text;
            string purchaseText = purchase_T.Text;
            string saleText = sale_T.Text;

            if (!string.IsNullOrWhiteSpace(barcode) && int.TryParse(countText, out int count) && count > 0)
            {
                ConnectDB();
                // 바코드를 조회한 후 추가하는 경우
                if (!string.IsNullOrWhiteSpace(position))
                {
                    product existingItem = productList.FirstOrDefault(item => item.barcd == barcode && item.position == position);

                    if (existingItem != null)
                    {

                        existingItem.count += count; // 이미 존재하는 상품이면 count를 증가시킴

                        if (decimal.TryParse(purchaseText, out decimal purchasePrice) && purchasePrice > 0)
                        {
                            existingItem.purchase = purchasePrice;
                        }

                        if (decimal.TryParse(saleText, out decimal salePrice) && salePrice >= 0)
                        {
                            existingItem.sale = salePrice;
                        }
                       
                    }
                    else
                    {
                        product newItem = new product
                        {
                            item_cd = item_cd_Label.Text,
                            item_no = item_no_Label.Text,
                            div_l = div_l_Label.Text,
                            div_m = div_m_Label.Text,
                            div_s = div_s_Label.Text,
                            div_n = div_n_Label.Text,
                            comp_nm = comp_nm_Label.Text,
                            img_prod_nm = img_prod_nm_Label.Text,
                            volume = volume_Label.Text,
                            barcd = barcd_Label.Text,
                            nutrition_info = nutrition_info_Label.Text,
                            position = position,
                            count = count
                        };

                        if (decimal.TryParse(purchaseText, out decimal purchasePrice) && purchasePrice > 0)
                        {
                            newItem.purchase = purchasePrice;
                        }
                        else
                        {
                            newItem.purchase = 0;
                        }
                        if (decimal.TryParse(saleText, out decimal salePrice) && salePrice >= 0)
                        {
                            newItem.sale = salePrice;
                        }
                        else
                        {
                            newItem.sale = 0;
                        }
                        
                        productList.Add(newItem);
                    }
                }
                else // DataGridView에서 데이터 목록을 클릭한 경우임
                {
                    int selectedIndex = DataGridView1.SelectedCells[0].RowIndex;

                    if (selectedIndex >= 0 && selectedIndex < productList.Count)
                    {
                        product selectedProduct = productList[selectedIndex];
                        position = selectedProduct.position;

                        selectedProduct.count += count; // 선택한 상품의 count를 증가시킴

                        if (decimal.TryParse(purchaseText, out decimal purchasePrice) && purchasePrice > 0)
                        {
                            selectedProduct.purchase = purchasePrice;
                        }

                        if (decimal.TryParse(saleText, out decimal salePrice) && salePrice >= 0)
                        {
                            selectedProduct.sale = salePrice;
                        } 
                    }
                }

                // 로그 항목 저장
                string logEntry = $"[{DateTime.Now:yyyy년 MM월 dd일 HH시 mm분 ss초}]  위치: '{position}' '바코드 {barcd_Label.Text}' '{img_prod_nm_Label.Text}' 상품을 {count_T.Text}개를 추가하였습니다.";

                Log.Items.Add(logEntry);

                MessageBox.Show("상품이 저장되었습니다.");

                // 데이터를 추가한 후에 position 텍스트 상자를 비웁니다.
                position_T.Text = string.Empty;
                Barcd_F_T.Text = string.Empty;
                count_T.Text = string.Empty;
                purchase_T.Text = string.Empty;
                sale_T.Text = string.Empty;

                // 데이터를 추가한 후에 라벨 초기화
                ClearLabels();

                // 추가한 상품을 DB에 저장
                SaveDataToDB(productList);

                UpdateDataGridView();
                LoadDataToDataGridView();
            }
            else
            {

                MessageBox.Show("바코드와 위치 정보와 개수를 모두 입력하세요.");
            }   
        }

        private void Out_Click(object sender, EventArgs e)
        {
            int selectedIndex = DataGridView1.SelectedCells[0].RowIndex;

            if (selectedIndex >= 0 && selectedIndex < productList.Count)
            {
                if (int.TryParse(count_T.Text, out int countToDelete) && countToDelete > 0)
                {
                    product selectedProduct = productList[selectedIndex];
                    string deletedItem = selectedProduct.img_prod_nm;
                    string deletedBarcode = selectedProduct.barcd;
                    string deletedPosition = selectedProduct.position;
                    int remainingCount = selectedProduct.count;

                    if (countToDelete <= remainingCount)
                    {
                        remainingCount -= countToDelete;
                        selectedProduct.count = remainingCount;

                        // 차감 로그를 저장
                        string logEntry = $"[{DateTime.Now:yyyy년 MM월 dd일 HH시 mm분 ss초}] 위치: '{deletedPosition}' 바코드: '{deletedBarcode}' 상품명: '{deletedItem}' {countToDelete}개를 차감하였습니다.";
                        Log.Items.Add(logEntry);

                        MessageBox.Show($"{countToDelete}개의 상품을 차감하였습니다.");

                        count_T.Text = string.Empty;

                        // 상품이 삭제되었으므로 라벨 초기화
                        ClearLabels();

                        // 차감한 상품을 DB에 저장
                        SaveDataToDB(productList);
                        UpdateDataGridView();
                    }
                    else
                    {
                        MessageBox.Show($"삭제하려는 개수({countToDelete}개)가 현재 상품 개수({remainingCount}개)를 초과합니다.");
                    }
                }
                else
                {
                    MessageBox.Show("유효한 개수를 입력하세요.");
                }
            }
            else
            {
                MessageBox.Show("삭제할 상품을 선택하세요.");
            }
        }


        private void ClearLabels()
        {
            // 라벨들 초기화
            item_cd_Label.Text = "";
            item_no_Label.Text = "";
            div_l_Label.Text = "";
            div_m_Label.Text = "";
            div_s_Label.Text = "";
            div_n_Label.Text = "";
            comp_nm_Label.Text = "";
            img_prod_nm_Label.Text = "";
            volume_Label.Text = "";
            barcd_Label.Text = "";
            nutrition_info_Label.Text = "";
            count_Label.Text = "";
            purchase_Label.Text = "";
            sale_Label.Text = "";
            position_Label.Text = "";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer.Text =
            DateTime.Now.ToString
            ("yyyy년 MM월 dd일 HH시 mm분 ss초");
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < productList.Count)
            {
                product selectedProduct = productList[e.RowIndex];

                item_cd_Label.Text = selectedProduct.item_cd;
                item_no_Label.Text = selectedProduct.item_no;
                div_l_Label.Text = selectedProduct.div_l;
                div_m_Label.Text = selectedProduct.div_m;
                div_s_Label.Text = selectedProduct.div_s;
                div_n_Label.Text = selectedProduct.div_n;
                comp_nm_Label.Text = selectedProduct.comp_nm;
                img_prod_nm_Label.Text = selectedProduct.img_prod_nm;
                volume_Label.Text = selectedProduct.volume;
                barcd_Label.Text = selectedProduct.barcd;
                nutrition_info_Label.Text = selectedProduct.nutrition_info;
                count_Label.Text = selectedProduct.count.ToString();
                purchase_Label.Text = selectedProduct.purchase.ToString();
                sale_Label.Text = selectedProduct.sale.ToString();
                position_Label.Text = selectedProduct.position.ToString();
            }      
        }
    }
}
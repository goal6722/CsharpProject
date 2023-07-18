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

        private void Barcd_F_T_TextChanged(object sender, EventArgs e)
        {
            // Barcd_F_T 텍스트 상자에서 바코드 값을 가져옴
            string barcode = Barcd_F_T.Text;

            if (string.IsNullOrWhiteSpace(barcode))
            {
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
                


            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
            // Barcd_F_T 텍스트 상자에서 바코드 값을 가져옴
            string barcode = Barcd_F_T.Text;

            // 바코드가 비어있을 경우 라벨을 초기화하고 바로 리턴
            if (string.IsNullOrWhiteSpace(barcode))
            {
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


        private void Add_Click(object sender, EventArgs e)
        {
            string barcode = barcd_Label.Text;
            string position = position_T.Text;
            string countText = count_T.Text;
            string purchaseText = purchase_T.Text;
            string saleText = sale_T.Text;

            if (!string.IsNullOrWhiteSpace(barcode) && !string.IsNullOrWhiteSpace(position) && int.TryParse(countText, out int count) && count > 0)
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

                // DataGridView에 바인딩된 productList를 다시 설정하여 데이터를 업데이트
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = productList;

                // 로그 항목 저장
                string logEntry = $"[{DateTime.Now:yyyy년 MM월 dd일 HH시 mm분 ss초}]  위치: '{position}' '바코드 {barcd_Label.Text}' '{img_prod_nm_Label.Text}' 상품을 추가하였습니다.";

                Log.Items.Add(logEntry);

                MessageBox.Show("상품이 저장되었습니다.");

                // 데이터를 추가한 후에 position 텍스트 상자를 비웁니다.
                position_T.Text = string.Empty;
                Barcd_F_T.Text = string.Empty;
                count_T.Text = string.Empty;
                purchase_T.Text = string.Empty;
                sale_T.Text = string.Empty;
            }

            else
            {

                MessageBox.Show("바코드와 위치 정보와 개수를 모두 입력하세요.");
            }
        }

        private void Out_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;

            if (selectedIndex >= 0 && selectedIndex < productList.Count)
            {

                string deletedItem = productList[selectedIndex].img_prod_nm;
                string deletedBarcode = productList[selectedIndex].barcd;

                productList.RemoveAt(selectedIndex);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = productList;

                // 삭제 로그를 저장
                string logEntry = $"[{DateTime.Now:yyyy년 MM월 dd일 HH시 mm분 ss초}] '바코드 {deletedBarcode}' '{deletedItem}' 상품을 삭제하였습니다.'";

                Log.Items.Add(logEntry);

                MessageBox.Show("상품이 삭제되었습니다.");
            }

            else
            {

                MessageBox.Show("삭제할 상품을 선택하세요.");
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer.Text =
            DateTime.Now.ToString
            ("yyyy년 MM월 dd일 HH시 mm분 ss초");
        }
    }
}
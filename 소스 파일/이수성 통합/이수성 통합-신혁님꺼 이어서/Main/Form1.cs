using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Printing;
using QRCoder;
using System.Text;
using ZXing;
using System.Media;
using System.Linq;

namespace Main
{

    public partial class Form1 : Form
    {
		private DBHelperBarcode dbHelper = new DBHelperBarcode(); // DBHelperBarcode 클래스의 인스턴스 생성

		SoundPlayer player;
        private DataTable data_table = null;
        private DataTable data_table2 = null;
        public Form1()
        {
            InitializeComponent();

            //<------------------------------------------------------------------------------------------------>
            // 데이터베이스 연결 문자열 초기화
            string dataSource = "DESKTOP-8GHEHCV";
            string db = "MYDB";
            string security = "SSPI";
            string connectionString = $"Data Source={dataSource}; Initial Catalog={db};" +
                $"Integrated Security={security}; Timeout=3";
            conn = new SqlConnection(connectionString); // SqlConnection 객체를 생성하여 연결 문자열을 할당
            //<------------------------------------------------------------------------------------------------>


            CreateComboBoxListL();
            CountMyProductNum.Text = DBHelper.CountDB();
            Dictionary<string, int> divLCounts = DBHelper.GetDivLCounts();

            chart1MyProduct.ChartAreas[0].AxisX.Interval = 1;
            chart1MyProduct.Series[0].Name = "시장품목";

            foreach (var kvp in divLCounts)
            {
                string divLValue = kvp.Key;
                int count = kvp.Value;
                chart1MyProduct.Series[0].Points.AddXY(divLValue, count);
            }

            // Form1.cs
            try
            {
                //lock (DBHelperQRcode.DBConn)
                {
                    if (!DBHelperQRcode.ConnectToDB()) // Modify this line
                    {
                        MessageBox.Show("DataBase 연결을 확인하세요");
                        return;
                    }
                    else
                    {
                        //DB연결되고 난후
                        SqlDataAdapter adapter = new SqlDataAdapter("Select * From ProductInfo", DBHelperQRcode.DBConn);
                        data_table = new DataTable();

                        try
                        {
                            adapter.Fill(data_table);
                            dataGridView1.DataSource = data_table;

                            //DataGridView 사이즈에 맞게 자동 조정
                            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DataGridView_Load Error");
                        }
                        DBHelperQRcode.Close();
                    }
                }
            }
            catch (ArgumentNullException ane)
            {
                //MessageBox.Show(ane.Message, "DataGridView_Load Error");
                Console.WriteLine(ane.Message, "DataGridView_Load Error");
            }
            player = new SoundPlayer();
            try
            {
                //lock (DBHelperQRcode.DBConn)
                {
                    if (!DBHelperQRcode.ConnectToDB()) // Modify this line
                    {
                        MessageBox.Show("DataBase 연결을 확인하세요");
                        return;
                    }
                    else
                    {
                        //DB연결되고 난후
                        SqlDataAdapter adapter = new SqlDataAdapter("Select * From MyProduct", DBHelperQRcode.DBConn);
                        data_table = new DataTable();

                        try
                        {
                            adapter.Fill(data_table);
                            dataGridView2.DataSource = data_table;

                            //DataGridView 사이즈에 맞게 자동 조정
                            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DataGridView_Load Error");
                        }
                        DBHelperQRcode.Close();
                    }
                }
            }
            catch (ArgumentNullException ane)
            {
                //MessageBox.Show(ane.Message, "DataGridView_Load Error");
                Console.WriteLine(ane.Message, "DataGridView_Load Error");
            }
        }

        public async void SearchProductButton1_Click(object sender, EventArgs e)// 상품검색(오류를 제때 잡지 않고 만들어서 코드가 좋지 못합니다...)
        {
            string jsonFilePath = @"log.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<ImageData> imageDataList = JsonConvert.DeserializeObject<List<ImageData>>(jsonContent);
            string userInput = textBox1SearchProduct.Text;
            string matchedFileName = imageDataList.Find(x => x.Id == userInput)?.FileName;
            if (matchedFileName != null)
            {
                string imagePath = @"Resource\" + matchedFileName;
                string imageFilePath = System.IO.Path.Combine(Application.StartupPath, imagePath);
                pictureBox1ProductImage.Image = Image.FromFile(imageFilePath);
                string ProductName = DBHelper.Item_no_2_Product_name(userInput);
                label1ProductName.Text = ProductName;
                List<string> priceShowList = await ShowPrices(ProductName);
                string joinedPrices = string.Join(", ", priceShowList);
                await Console.Out.WriteLineAsync(joinedPrices);
                label7ShowProductPriceNaver.Text = priceShowList[0];
            }
            else
            {
                label1ProductName.Text = "일치하는 파일을 찾을 수 없습니다.";
                string imagePath = @"Resource\null.jpg";
                string imageFilePath = System.IO.Path.Combine(Application.StartupPath, imagePath);
                pictureBox1ProductImage.Image = Image.FromFile(imageFilePath);
            }
        }


        private void CreateComboBoxListL()
        {
            comboBoxLarge.Items.Add("--대분류--");
            List<string> divName = DBHelper.DivListL("div_l");
            foreach (var div in divName)
            {
                string comboName = div;
                comboBoxLarge.Items.Add(comboName);
            }
            comboBoxLarge.SelectedIndex = 0;
        }

        private void CreateComboBoxListM(string constName)
        {
            comboBoxMIddle.Items.Clear();
            comboBoxMIddle.Items.Add("--중분류--");
            List<string> divName = DBHelper.DivListMnS("div_m", "div_l", constName);
            foreach (var div in divName)
            {
                string comboName = div;
                comboBoxMIddle.Items.Add(comboName);
            }
            comboBoxMIddle.SelectedIndex = 0;
        }
        private void CreateComboBoxListS(string constName)
        {
            comboBoxSmall.Items.Clear();
            comboBoxSmall.Items.Add("--소분류--");
            List<string> divName = DBHelper.DivListMnS("div_s", "div_m", constName);
            foreach (var div in divName)
            {
                string comboName = div;
                comboBoxSmall.Items.Add(comboName);
            }
            comboBoxSmall.SelectedIndex = 0;
        }

        private void buttonLarge_Click(object sender, EventArgs e)
        {
            string selectedDiv = comboBoxLarge.SelectedItem.ToString();
            string columnName = '\'' + comboBoxLarge.Text + '\'';
            Dictionary<string, int> filteredData = DBHelper.GetFilteredData(columnName, "div_l", "div_m");
            UpdateChart(filteredData);
            CreateComboBoxListM(columnName);
        }

        private void UpdateChart(Dictionary<string, int> data)
        {
            chart1MyProduct.Series[0].Points.Clear();
            foreach (var kvp in data)
            {
                string divValue = kvp.Key;
                int count = kvp.Value;
                chart1MyProduct.Series[0].Points.AddXY(divValue, count);
            }
        }

        private void buttonMiddle_Click(object sender, EventArgs e)
        {
            string selectedDiv = comboBoxMIddle.SelectedItem.ToString();
            string columnName = '\'' + comboBoxMIddle.Text + '\'';
            Dictionary<string, int> filteredData = DBHelper.GetFilteredData(columnName, "div_m", "div_s");
            UpdateChart(filteredData);
            CreateComboBoxListS(columnName);
        }

        private void buttonSmall_Click(object sender, EventArgs e)
        {
            string selectedDiv = comboBoxSmall.SelectedItem.ToString();
            string columnName = '\'' + comboBoxSmall.Text + '\'';
            Dictionary<string, int> filteredData = DBHelper.GetFilteredData(columnName, "div_s", "img_prod_nm");
            UpdateChart(filteredData);
        }


        private async Task<List<string>> ShowPrices(string ProductName)
        {
            List<string> abcdID = ReadApiID.readID();
            string clientId = abcdID[0];
            string clientSecret = abcdID[1];
            string query = ProductName;
            int display = 1;
            int start = 1;
            string sort = "sim";

            Dictionary<string, string> priceData = await SearchAsync(clientId, clientSecret, query, display, start, sort);

            List<string> pricesToShow = new List<string>();
            foreach (var item in priceData)
            {
                string title = item.Key;
                string lprice = item.Value;
                pricesToShow.Add($"상품명: {title}, 네이버 최저가: {lprice}원");
            }
            return pricesToShow;
        }


        private async Task<Dictionary<string, string>> SearchAsync(string clientId, string clientSecret, string query, int display, int start, string sort)
        {
            Dictionary<string, string> priceData = new Dictionary<string, string>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Naver-Client-Id", clientId);
                client.DefaultRequestHeaders.Add("X-Naver-Client-Secret", clientSecret);

                string url = $"https://openapi.naver.com/v1/search/shop.xml?query={query}&display={display}&start={start}&sort={sort}";

                HttpResponseMessage response = await client.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseBody);

                XmlNodeList titleNodes = xmlDoc.SelectNodes("rss/channel/item/title");
                XmlNodeList lpriceNodes = xmlDoc.SelectNodes("rss/channel/item/lprice");

                for (int i = 0; i < titleNodes.Count; i++)
                {
                    string title = RemoveHtmlTags(titleNodes[i].InnerText); // 태그 제거
                    string lprice = lpriceNodes[i].InnerText;

                    priceData.Add(title, lprice);
                }

                return priceData;
            }
        }

        private string RemoveHtmlTags(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty); // 태그 제거
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string productName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string productDivL = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string Location = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string byCompany = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string price = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string bcd = textBox6.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string productName = textBox1.Text;
            string divDetail = textBox2.Text;
            string Location = textBox3.Text;
            string byCompany = textBox4.Text;
            string price = textBox5.Text;
            string bcd = textBox6.Text;

            GenerateQRCode(bcd, productName, divDetail, Location, byCompany, price);

        }
        //QR코드 이미지 생성기
        private void GenerateQRCode(string bcd, string productName, string divDetail, string Location, string byCompany, string price)
        {
            // 텍스트들을 결합하여 QR 코드 데이터 생성
            string qrCodeDataString =
                "바코드 : " + bcd + "\r\n" +
                "상품이름 : " + productName + "\r\n" +
                "상품 분류 : " + divDetail + "\r\n" +
                "상품 위치 : " + Location + "\r\n" +
                "제조회사 : " + byCompany + "\r\n" +
                "가격 : " + price;


            // QR 코드 생성
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeDataString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);


            // 하나 이상의 텍스트 상자에 값이 비어 있는지 확인
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(divDetail) ||
                string.IsNullOrEmpty(Location) || string.IsNullOrEmpty(byCompany) ||
                string.IsNullOrEmpty(price) || string.IsNullOrEmpty(bcd))
            {
                MessageBox.Show("모든 텍스트 상자에 값을 입력하세요.");
                return;
            }

            // QR 코드 이미지 생성 
            Bitmap qrCodeImage = qrCode.GetGraphic(2);
            pictureBox1.Image = qrCodeImage;


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "다른이름으로 저장";
            dlg.DefaultExt = "jpg";
            dlg.Filter = "JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
            dlg.FilterIndex = 0;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(dlg.FileName);
            }
            GridInputData();
            ViewGridData();
        }

        private void GridInputData()
        {
            string productName = textBox1.Text;
            string divDetail = textBox2.Text;
            string location = textBox3.Text;
            string byCompany = textBox4.Text;
            string price = textBox5.Text;
            string bcd = textBox6.Text;

            using (SqlConnection connection = new SqlConnection(DBHelperQRcode.DBConnString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO ProductInfo (bcd, productName, divDetail, Location, byCompany, price) " +
                                     "VALUES (@bcd, @productName, @divDetail, @location, @byCompany, @price)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@bcd", bcd);
                    command.Parameters.AddWithValue("@productName", productName);
                    command.Parameters.AddWithValue("@divDetail", divDetail);
                    command.Parameters.AddWithValue("@location", location);
                    command.Parameters.AddWithValue("@byCompany", byCompany);
                    command.Parameters.AddWithValue("@price", price);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("데이터가 성공적으로 저장되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("데이터 저장에 실패했습니다.");
                    }
                }
            }
        }

        private void ViewGridData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBHelperQRcode.DBConnString))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM ProductInfo";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // DataGridView에 데이터 바인딩
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 로드 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image file(*.png, *.jpeg,*.jpg)|*.png; *.jpeg;*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(dialog.FileName);
            }
        }
        public string decoded;
        private void button6_Click(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBox2.Image);

            if (result != null)
            {
                // 스캔 결과를 정렬된 형태로 표시하기 위해 StringBuilder를 사용합니다.
                StringBuilder decodedText = new StringBuilder();

                // 상품 정보와 타입 정보를 따로 처리하여 정렬된 형태로 추가합니다.
                decodedText.AppendLine("상품 정보:");
                decodedText.AppendLine(result.ToString());

                decodedText.AppendLine("\r\n타입 정보:");
                decodedText.AppendLine(result.BarcodeFormat.ToString());
                // TextBox에 결과를 설정합니다.
                textBox7.Text = decodedText.ToString();
            }
            else
            {
                // 스캔 결과가 없을 때 오류 메시지를 보여줍니다.
                MessageBox.Show("QR 코드를 스캔할 수 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //검색기능
        private void button7_Click(object sender, EventArgs e)
        {
            {
                if (data_table == null)
                    return;

                string searchText = textBox8.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    // 검색어가 비어있으면 원래 데이터를 모두 표시합니다.
                    dataGridView2.DataSource = data_table;
                }
                else
                {
                    // DataView를 이용하여 검색어를 포함하는 행들을 필터링합니다.
                    DataView dv = data_table.DefaultView;
                    dv.RowFilter = $"img_prod_nm LIKE '%{searchText}%' OR item_cd LIKE '%{searchText}%'";
                    dataGridView2.DataSource = dv.ToTable();
                }
            }

        }
        //<------------------------------------------------------------------------------------------------>
        private SqlConnection conn;
        private DataTable dataTable = new DataTable(); // Form1 클래스의 멤버 변수로 선언
        private List<ShoppingCart> cartList = new List<ShoppingCart>();

        private void search_Click(object sender, EventArgs e)
        {
            string searchValue = barcd.Text.Trim(); // "barcd" 텍스트 상자에 입력한 값을 가져옴

            if (string.IsNullOrEmpty(searchValue))
            {   // 검색 값이 비어있는 경우, 처리할 로직 (예: 에러 메시지 출력 )
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
                {   // 데이터를 가져올 수 있는 SqlDataReader 객체 생성
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {   // 조회된 데이터를 라벨에 표시
                            string item = reader["img_prod_nm"].ToString(); // "img_prod_nm"의 값 가져옴
                            int count = Convert.ToInt32(reader["count"]); //  "count"의 값 가져옴
                            decimal pay = Convert.ToInt32(reader["sale"]);// "sale"의 값 가져옴
                                                                          // 라벨에 데이터를 표시하는 예시                                                                                                             
                            item_label.Text = $"Item: {item}";
                            count_label.Text = $"Count: {count}";
                            pay_label.Text = $"Pay: {pay}";
                        }
                        else
                        {   // 검색 결과가 없는 경우, 처리할 로직 (예: 메시지 출력 등)
                            // 여기서는 간단하게 아무 작업도 하지 않도록 하기
                        }
                    }
                }
            }
        }
        private void SaveReceiptToFile(List<ShoppingCart> cartItems)
        {
            // 원하는 파일 저장 경로 설정
            string mainFolder = @".\장바구니\영수증";
            Directory.CreateDirectory(mainFolder); // 폴더가 없는 경우 폴더를 생성
            string filePath = Path.Combine(mainFolder, "영수증.txt");
            StringBuilder receiptBuilder = new StringBuilder();
            receiptBuilder.AppendLine("************** 영수증 **************");
            receiptBuilder.AppendLine("상품명\t\t수량\t\t가격");
            receiptBuilder.AppendLine("------------------------------------");
            foreach (var item in cartItems)
            {
                receiptBuilder.AppendLine($"{item.item}\t\t{item.count}\t\t{item.pay}");
            }
            receiptBuilder.AppendLine("------------------------------------");
            int totalPay = cartItems.Sum(item => item.pay);
            receiptBuilder.AppendLine($"총 결제 금액:\t\t\t{totalPay}");
            receiptBuilder.AppendLine("************************************");
            // 현재 날짜와 시간을 가져와서 영수증에 추가
            string currentDateTime = DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분 ss초");
            receiptBuilder.AppendLine($"영수증 발급일시:\t\t{currentDateTime}");
            receiptBuilder.AppendLine("************************************");
            // 기존 파일 내용과 합쳐서 저장
            if (File.Exists(filePath))
            {
                string existingContent = File.ReadAllText(filePath);
                receiptBuilder.Insert(0, existingContent);
            }
            // 텍스트 파일로 저장 (기존 파일이 있을 경우 덮어씌움)
            File.WriteAllText(filePath, receiptBuilder.ToString());
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
                if (conn.State == ConnectionState.Closed) // 데이터베이스 연결 상태 확인
                {
                    conn.Open(); // 데이터베이스 연결 열기
                }
                ShoppingCart cart = new ShoppingCart();
                // 데이터를 받아올 쿼리 작성 (검색 값으로 조건 추가)
                string query = $"SELECT count, img_prod_nm, sale FROM MyInventory WHERE barcd = '{barcdValue}'";
                int pay = 0;
                // 쿼리 실행을 위한 SqlCommand 객체 생성
                using (SqlCommand command = new SqlCommand(query, conn))
                {   // 데이터를 가져올 수 있는 SqlDataReader 객체 생성
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {   // 조회된 데이터를 라벨에 표시
                            string item = reader["img_prod_nm"].ToString(); // "img_prod_nm"의 값 가져옴
                            int count = Convert.ToInt32(reader["count"]);   // "count"의 값 가져옴
                            pay = Convert.ToInt32(reader["sale"]);  // "sale"의 값 가져옴
                                                                    // 재고가 0 이하인 경우, 오류 메시지 출력하고 함수 종료
                            if (count <= 0)
                            {
                                MessageBox.Show("해당 상품의 재고가 없습니다.");
                                return;
                            }
                            cart = new ShoppingCart();
                            cart.item = item;
                            cart.barcode = barcdValue;
                            cart.pay = Convert.ToInt32(pay);
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
                {   //해당 항목의 count를 늘린다.
                    ShoppingCart item = cartList.Single(x => x.barcode.Equals(barcdValue));
                    item.count++;
                    item.pay += pay;
                }
                catch (Exception)
                {
                    cart.count = 1;//신규 추가
                    cartList.Add(cart);
                }
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = cartList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다: " + ex.Message);
            }
            // 영수증 저장 메서드 호출
            SaveReceiptToFile(cartList);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            
            string barcdValue = barcd.Text.Trim(); // 텍스트 입력창에서 바코드 값을 가져옴
                                                    //// 바코드 값이 비어있는 경우 처리
            if (string.IsNullOrEmpty(barcdValue))
            {
                MessageBox.Show("바코드 값을 입력하세요.");
                return;
            }
            if (conn.State == ConnectionState.Closed)// 데이터베이스 연결 상태 확인
            {
                conn.Open(); // 데이터베이스 연결 열기
            }
            string updateQuery = "UPDATE [dbo].[MyInventory] SET [count] = [count] + 1 WHERE barcd = @Barcd";
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
            {
                updateCommand.Parameters.AddWithValue("@Barcd", barcdValue);
                updateCommand.ExecuteNonQuery();
            }
            ShoppingCart cart = new ShoppingCart();
            try
            {   //해당 항목의 count를 늘린다.
                ShoppingCart item = cartList.Single(x => x.barcode.Equals(barcdValue));
                int pay = item.pay / item.count;
                item.count--;
                item.pay -= pay;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = cartList;

            // 영수증 저장 메서드 호출
            SaveReceiptToFile(cartList);
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShoppingCart select = dataGridView3.CurrentRow.DataBoundItem as ShoppingCart;
            barcd.Text = select.barcode;
        }
    }
}


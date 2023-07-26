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
        // 전역 변수로 product 데이터를 저장할 List
        private List<product> productList = new List<product>();

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
            ConnectDB();

            dataGridView4.DataSource = null;
            dataGridView4.DataSource = productList;
            //<------------------------------------------------------------------------------------------------>
            dataGridView4.CellClick += dataGridView4_CellContentClick;
            dataGridView4.CellFormatting += DataGridView1_CellFormatting; // 이 줄을 추가.
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
                            dataGridView4.DataSource = data_table;

                            //DataGridView 사이즈에 맞게 자동 조정
                            //dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                            //dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                            dataGridView4.DataSource = dataTable;
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
        private SqlConnection conn = new SqlConnection();
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
                            item_label.Text = $"{item}";
                            count_label.Text = $"{count}개";
                            pay_label.Text = $"{pay}원";
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
        //<------------------------------------------------------------------------------------------------>

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
                    string query = "SELECT [position], [count], [item_cd], [item_no], [div_l], [div_m], [div_s], [div_n], [comp_nm], [img_prod_nm], [volume], [barcd], [purchase], [sale], [nutrition_info] FROM [MYDB].[dbo].[MyInventory]";

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
                            cmd.CommandText = $"SELECT COUNT(*) FROM MyInventory WHERE position = @position AND barcd = @barcd";
                            cmd.Parameters.AddWithValue("@position", productItem.position);
                            cmd.Parameters.AddWithValue("@barcd", productItem.barcd);
                            int existingCount = (int)cmd.ExecuteScalar();

                            if (existingCount > 0)
                            {
                                // 이미 해당 위치와 바코드로 기존에 저장된 상품이 있다면 UPDATE 수행
                                cmd.CommandText = $"UPDATE MyInventory SET count = @count, purchase = @purchase, sale = @sale WHERE position = @position AND barcd = @barcd";
                            }
                            else
                            {
                                // 해당 위치와 바코드로 기존에 저장된 상품이 없다면 INSERT 수행
                                cmd.CommandText = $"INSERT INTO MyInventory (item_cd, item_no, div_l, div_m, div_s, div_n, comp_nm, img_prod_nm, volume, barcd, nutrition_info, position, count, purchase, sale) " +
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

            // SQL 쿼리문 작성 (MyProduct 및 MyInventory 테이블을 조인하여 정보를 가져옴)
            string query = "SELECT p.[item_cd], p.[item_no], p.[div_l], p.[div_m], p.[div_s], p.[div_n], p.[comp_nm], p.[img_prod_nm], p.[volume], p.[barcd], p.[nutrition_info], i.[position], i.[count], i.[sale], i.[purchase] " +
                   "FROM [MYDB].[dbo].[MyProduct] p " +
                   "LEFT JOIN [MYDB].[dbo].[MyInventory] i ON p.[barcd] = i.[barcd] " +
                   "WHERE p.[barcd] = @barcode";


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
                            position_Label.Text = reader["position"].ToString();
                            label9.Text = reader["count"].ToString();
                            sale_Label.Text = reader["sale"].ToString();
                            purchase_Label.Text = reader["purchase"].ToString();

                            // 해당 바코드에 해당하는 행을 선택 상태로 변경
                            foreach (DataGridViewRow row in dataGridView4.Rows)
                            {
                                if (row.Cells["barcdDV"].Value.ToString() == barcode)
                                {
                                    row.Selected = true;
                                    row.DefaultCellStyle.BackColor = Color.Blue;
                                    row.DefaultCellStyle.ForeColor = Color.White;

                                    // 선택된 행이 보이도록 스크롤 조정
                                    dataGridView4.FirstDisplayedScrollingRowIndex = row.Index;
                                }
                                else
                                {
                                    row.Selected = false;
                                    row.DefaultCellStyle.BackColor = Color.White;
                                    row.DefaultCellStyle.ForeColor = Color.Black;
                                }
                            }
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
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = productList;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string barcode = barcd_Label.Text;
            string position = position_T.Text;
            string countText = count_T.Text;
            string purchaseText = purchase_T.Text;
            string saleText = sale_T.Text;

            if (!string.IsNullOrWhiteSpace(barcode) && int.TryParse(countText, out int count))
            {
                ConnectDB();

                if (count < 0)
                {
                    MessageBox.Show("유효한 개수를 입력하세요.");
                    return;
                }

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
                    int selectedIndex = dataGridView4.SelectedCells[0].RowIndex;

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

                // 파일에 로그를 추가하는 방법
                string logFilePath = @"Log(입고_및_출고).txt";
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);


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
            int selectedIndex = dataGridView4.SelectedCells[0].RowIndex;

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
            label9.Text = "";
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

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < productList.Count)
            {
                // 이전에 선택된 모든 행의 색상을 기본 스타일로 변경
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

                // 선택된 행의 색상을 파란색으로 변경
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView4.Rows.Count)
                {
                    DataGridViewRow selectedRow = dataGridView4.Rows[e.RowIndex];
                    selectedRow.DefaultCellStyle.BackColor = Color.Blue;
                    selectedRow.DefaultCellStyle.ForeColor = Color.White;
                    selectedRow.Selected = true;
                }

                product selectedProduct = productList[e.RowIndex];
                Barcd_F_T.Text = selectedProduct.barcd;

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
                label9.Text = selectedProduct.count.ToString();
                purchase_Label.Text = selectedProduct.purchase.ToString();
                sale_Label.Text = selectedProduct.sale.ToString();
                position_Label.Text = selectedProduct.position.ToString();
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < productList.Count)
            {
                // 해당 행의 'count' 값
                int countValue = productList[e.RowIndex].count;

                // 'count' 값에 따라 셀의 글꼴 색상을 변경.
                if (countValue < 10)
                {
                    e.CellStyle.ForeColor = Color.Red; // 'count' 값이 10 미만이면 글꼴 색상을 빨간색으로 변경
                }
                else if (countValue < 50)
                {
                    e.CellStyle.ForeColor = Color.Orange; // 'count' 값이 50 미만이면 글꼴 색상을 주황색으로 변경
                }
                // 다른 범위에 따른 글꼴 색상 변경을 원한다면 더 많은 조건을 추가
            }
        }
    }
}


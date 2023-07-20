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
using IronBarCode;
using iTextSharp.text.pdf.qrcode;
using QRCoder;
using ZXing.QrCode.Internal;
using Mode = ZXing.QrCode.Internal.Mode;
using QRCode = QRCoder.QRCode;

namespace QRcode
{
    public partial class Form1 : Form
    {
        private DataTable data_table = null;
        public Form1()
        {
            InitializeComponent();

            try
            {
                lock(DBHelper.DBConn)
                {               
                        if(!DBHelper.IsDBConnected)
                        {
                            MessageBox.Show("DataBase 연결을 확인하세요");
                            return;
                        }
                        else
                        {
                            //DB연결되고 난후
                            SqlDataAdapter adapter = new SqlDataAdapter("Select * From ProductInfo", DBHelper.DBConn);
                            data_table = new DataTable();
                            
                            try
                            {
                            adapter.Fill(data_table);
                            dataGridView1.DataSource = data_table;

                            //DataGridView 사이즈에 맞게 자동 조정
                            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            }catch (Exception ex)
                            {

                            MessageBox.Show(ex.Message, "DataGridView_Load Error");
                             }
                            DBHelper.Close();

                        }
                    
                }
            }
            catch (ArgumentNullException ane)
            {

                MessageBox.Show(ane.Message, "DataGridView_Load Error");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        //private void textBox6_TextChanged(object sender, EventArgs e)
        //{
        //    string expirationDay = textBox6.Text;
        //}
        //QR코드 생성기
        private void GenerateQRCode(string productCode ,string productName, string divDetail, string Location, string byCompany, string price)
        {
            // 텍스트들을 결합하여 QR 코드 데이터 생성
            string qrCodeDataString =
                "상품코드 : " + productCode + "\n" +
                "상품이름 : " + productName + "\n" +
                "상품 분류 : " + divDetail + "\n" +
                "상품 위치 : " + Location + "\n" +
                "제조회사 : " + byCompany + "\n" +
                "가격 : " + price;
                

            // QR 코드 생성
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeDataString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            
            
            // 하나 이상의 텍스트 상자에 값이 비어 있는지 확인
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(divDetail) ||
                string.IsNullOrEmpty(Location) || string.IsNullOrEmpty(byCompany) ||
                string.IsNullOrEmpty(price) || string.IsNullOrEmpty(productCode))
            {
                MessageBox.Show("모든 텍스트 상자에 값을 입력하세요.");
                return;
            }

           // QR 코드 이미지 생성 
            Bitmap qrCodeImage = qrCode.GetGraphic(5);
           pictureBox1.Image = qrCodeImage;
            
         
        }

        //버튼 1 누르면 QR코드가 생성 됩니다.
        private void button1_Click(object sender, EventArgs e)
        {
            string productName = textBox1.Text;
            string divDetail = textBox2.Text;
            string Location = textBox3.Text;
            string byCompany = textBox4.Text;
            string price = textBox5.Text;
            string productCode = textBox6.Text;

            GenerateQRCode(productCode ,productName, divDetail, Location, byCompany, price);

        }
        //다른이름으로 저장
        private void button2_Click(object sender, EventArgs e)
        {
            //QR 코드 저장
            //string saveRoute = @"C:\testQR";
            //if (!System.IO.Directory.Exists(saveRoute))
            //    System.IO.Directory.CreateDirectory(saveRoute);
            //pictureBox1.Image.Save(saveRoute + "\\image.png", System.Drawing.Imaging.ImageFormat.Png);

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "다른이름으로 저장";
            dlg.DefaultExt = "jpg";
            dlg.Filter = "JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif";
            dlg.FilterIndex = 0;

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(dlg.FileName);
            }
            GridInputData();
            ViewGridData();

        }

        //productCode ,productName, divDetail, Location, byCompany, price
        private void GridInputData()
        {
            string productName = textBox1.Text;
            string divDetail = textBox2.Text;
            string location = textBox3.Text;
            string byCompany = textBox4.Text;
            string price = textBox5.Text;
            string productCode = textBox6.Text;

            using (SqlConnection connection = new SqlConnection(DBHelper.DBConnString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO ProductInfo (productCode, productName, divDetail, Location, byCompany, price) " +
                                     "VALUES (@productCode, @productName, @divDetail, @location, @byCompany, @price)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@productCode", productCode);
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
                using (SqlConnection connection = new SqlConnection(DBHelper.DBConnString))
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string productCode = textBox6.Text;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

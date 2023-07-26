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
using QRCoder;
using ZXing.QrCode.Internal;
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
                            SqlDataAdapter adapter = new SqlDataAdapter("Select * From MyProduct", DBHelper.DBConn);
                            data_table = new DataTable();
                            
                            try
                            {
                            adapter.Fill(data_table);
                            dataGridView1.DataSource = data_table;

                            //DataGridView 사이즈에 맞게 자동 조정
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string productNum = textBox1.Text;
          

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string productDivL = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string productDivS = textBox3.Text;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string productName = textBox4.Text;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string bycompany = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string expirationDay = textBox6.Text;
        }
        //QR코드 생성기
        private void GenerateQRCode(string productNumber, string productDivisionL, string productDivisionS, string productName, string byCompany, string expirationDay)
        {
            // 텍스트들을 결합하여 QR 코드 데이터 생성
            string qrCodeDataString = productNumber + "|" + productDivisionL + "|" + productDivisionS + "|" + productName + "|" + byCompany + "|" + expirationDay;

            // QR 코드 생성
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeDataString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            // QR 코드 이미지 생성 
            Bitmap qrCodeImage = qrCode.GetGraphic(5);
            pictureBox1.Image = qrCodeImage;
        }

        //버튼 1 누르면 QR코드가 생성 됩니다.
        private void button1_Click(object sender, EventArgs e)
        {
            string productNumber = textBox1.Text;
            string productDivisionL = textBox2.Text;
            string productDivisionS = textBox3.Text;
            string productName = textBox4.Text;
            string byCompany = textBox5.Text;
            string expirationDay = textBox6.Text;

            GenerateQRCode(productNumber, productDivisionL, productDivisionS, productName, byCompany, expirationDay);

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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

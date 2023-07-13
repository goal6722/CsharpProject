using System;
using System.Drawing;
using System.Windows.Forms;

namespace Searching_Image_from_Barcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 이미지 파일 상대 경로
            string imagePath = @"Resource\10093_60_m_1.jpg"; // 이미지 파일이 있는 폴더 경로와 파일 이름

            // 이미지 로드
            string imageFilePath = System.IO.Path.Combine(Application.StartupPath, imagePath);
            pictureBox1.Image = Image.FromFile(imageFilePath);
        }


    }
}

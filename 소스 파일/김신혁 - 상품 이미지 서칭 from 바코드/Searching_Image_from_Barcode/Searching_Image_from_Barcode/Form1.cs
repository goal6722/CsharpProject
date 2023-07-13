using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

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
            // JSON 파일의 경로
            string jsonFilePath = @"log.json";

            // JSON 파일의 내용을 문자열로 읽기
            string jsonContent = File.ReadAllText(jsonFilePath);

            // JSON 문자열을 List<ImageData>로 변환
            List<ImageData> imageDataList = JsonConvert.DeserializeObject<List<ImageData>>(jsonContent);

            // textBox에서 입력된 값을 가져온다고 가정
            string userInput = textBox1.Text;

            // 사용자 입력 값과 일치하는 이미지 파일 이름 찾기
            string matchedFileName = imageDataList.Find(x => x.Id == userInput)?.FileName;

            if (matchedFileName != null)
            {
                label1.Text = matchedFileName;
                // 이미지 파일 상대 경로
                string imagePath = @"Resource\" + matchedFileName;

                // 이미지 로드
                string imageFilePath = System.IO.Path.Combine(Application.StartupPath, imagePath);
                pictureBox1.Image = Image.FromFile(imageFilePath);
            }
            else
            {
                label1.Text = "일치하는 파일을 찾을 수 없습니다.";

                // 이미지 파일 상대 경로
                string imagePath = @"Resource\null.jpg";

                // 이미지 로드
                string imageFilePath = System.IO.Path.Combine(Application.StartupPath, imagePath);
                pictureBox1.Image = Image.FromFile(imageFilePath);
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace SearchProduct
{
    public partial class QRcodeScanner : Form
    {
        SoundPlayer player;
        public QRcodeScanner()
        {
            InitializeComponent();

            player = new SoundPlayer();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image file(*.png, *.jpeg,*.jpg)|*.png; *.jpeg;*.jpg";
            if(dialog.ShowDialog() == DialogResult.OK )                        
            {
                pictureBox1.Image  = Image.FromFile(dialog.FileName); 
            }

        }

        public string decoded;

        private void button1_Click(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBox1.Image);

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
                textBox1.Text = decodedText.ToString();

                // 소리 재생
                player.Play();
            }
            else
            {
                // 스캔 결과가 없을 때 오류 메시지를 보여줍니다.
                MessageBox.Show("QR 코드를 스캔할 수 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

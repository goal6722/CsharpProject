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
            if (result != null )
            {
                decoded = "상품 정보  " + "\r\n"+ result.ToString() + 
                    "\r\n"
                    +"\r\n Type: " + result.BarcodeFormat.ToString();
                if (decoded != "")
                {
                    player.Play();
                    textBox1.Text = decoded;
                }
                else
                    MessageBox.Show("잘못 입력함", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                player.Stop();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            CreateComboBoxListL();
            label5.Text = DBHelper.CountDB();
            Dictionary<string, int> divLCounts = DBHelper.GetDivLCounts();

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.Series[0].Name = "시장품목";

            foreach (var kvp in divLCounts)
            {
                string divLValue = kvp.Key;
                int count = kvp.Value;
                chart1.Series[0].Points.AddXY(divLValue, count);
            }
        }

        public void SearchProductButton1_Click(object sender, EventArgs e)//상품검색
        {
            string jsonFilePath = @"log.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<ImageData> imageDataList = JsonConvert.DeserializeObject<List<ImageData>>(jsonContent);
            string userInput = textBox1.Text;
            string matchedFileName = imageDataList.Find(x => x.Id == userInput)?.FileName;

            if (matchedFileName != null)
            {
                label1.Text = matchedFileName;
                string imagePath = @"Resource\" + matchedFileName;
                string imageFilePath = System.IO.Path.Combine(Application.StartupPath, imagePath);
                pictureBox1.Image = Image.FromFile(imageFilePath);
            }
            else
            {
                label1.Text = "일치하는 파일을 찾을 수 없습니다.";
                string imagePath = @"Resource\null.jpg";
                string imageFilePath = System.IO.Path.Combine(Application.StartupPath, imagePath);
                pictureBox1.Image = Image.FromFile(imageFilePath);
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
            comboBox1.Items.Clear();
            comboBox1.Items.Add("--중분류--");
            List<string> divName = DBHelper.DivListMnS("div_m", "div_l", constName);
            foreach (var div in divName)
            {
                string comboName = div;
                comboBox1.Items.Add(comboName);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void CreateComboBoxListS(string constName)
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add("--소분류--");
            List<string> divName = DBHelper.DivListMnS("div_s", "div_m", constName);
            foreach (var div in divName)
            {
                string comboName = div;
                comboBox3.Items.Add(comboName);
            }
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string selectedDiv = comboBoxLarge.SelectedItem.ToString();
            string columnName = '\'' + comboBoxLarge.Text + '\'';
            Dictionary<string, int> filteredData = DBHelper.GetFilteredData(columnName, "div_l", "div_m");
            UpdateChart(filteredData);
            CreateComboBoxListM(columnName);
        }

        private void UpdateChart(Dictionary<string, int> data)
        {
            chart1.Series[0].Points.Clear();
            foreach (var kvp in data)
            {
                string divValue = kvp.Key;
                int count = kvp.Value;
                chart1.Series[0].Points.AddXY(divValue, count);
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            string selectedDiv = comboBox1.SelectedItem.ToString();
            string columnName = '\'' + comboBox1.Text + '\'';
            Dictionary<string, int> filteredData = DBHelper.GetFilteredData(columnName, "div_m", "div_s");
            UpdateChart(filteredData);
            CreateComboBoxListS(columnName);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            string selectedDiv = comboBox3.SelectedItem.ToString();
            string columnName = '\'' + comboBox3.Text + '\'';
            Dictionary<string, int> filteredData = DBHelper.GetFilteredData(columnName, "div_s", "img_prod_nm");
            UpdateChart(filteredData);
        }
    }
}

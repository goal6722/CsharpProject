using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        public async void SearchProductButton1_Click(object sender, EventArgs e)// 상품검색(오류를 제때 잡지 않고 만들어서 코드가 좋지 못합니다...)
        {
            string jsonFilePath = @"log.json";
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<ImageData> imageDataList = JsonConvert.DeserializeObject<List<ImageData>>(jsonContent);
            string userInput = textBox1.Text;
            string matchedFileName = imageDataList.Find(x => x.Id == userInput)?.FileName;
            if (matchedFileName != null)
            {
                string imagePath = @"Resource\" + matchedFileName;
                string imageFilePath = System.IO.Path.Combine(Application.StartupPath, imagePath);
                pictureBox1.Image = Image.FromFile(imageFilePath);
                string ProductName = DBHelper.Item_no_2_Product_name(userInput);
                label1.Text = ProductName;
                List<string> priceShowList = await ShowPrices(ProductName);
                string joinedPrices = string.Join(", ", priceShowList);
                await Console.Out.WriteLineAsync(joinedPrices);
                label7.Text = priceShowList[0];
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
    }
}

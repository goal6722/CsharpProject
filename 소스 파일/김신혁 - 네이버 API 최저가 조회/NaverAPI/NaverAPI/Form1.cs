using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks; // async와 Task를 사용하기 위해 추가
using System.Windows.Forms;
using System.Xml;

namespace NaverAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            showPrice("롯데핑크퐁포도사과235ML");
        }

        private async void showPrice(string ProductName)
        {
            List<string> abcdID = ReadApiID.readID();
            string clientId = abcdID[0];
            string clientSecret = abcdID[1];
            string query = ProductName;
            int display = 1;
            int start = 1;
            string sort = "sim";

            Dictionary<string, string> priceData = await SearchAsync(clientId, clientSecret, query, display, start, sort);

            foreach (var item in priceData)
            {
                string title = item.Key;
                string lprice = item.Value;
                // 여기서 title과 lprice를 가공하여 원하는 형태로 사용할 수 있습니다.
                Console.WriteLine($"상품명: {title}, 최저가: {lprice}원");
            }
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

                // XmlDocument를 사용하여 XML 데이터 파싱
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseBody);

                // "rss/channel/item/title"과 "rss/channel/item/lprice" 정보 추출
                XmlNodeList titleNodes = xmlDoc.SelectNodes("rss/channel/item/title");
                XmlNodeList lpriceNodes = xmlDoc.SelectNodes("rss/channel/item/lprice");

                // 결과를 Dictionary에 저장
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
            return Regex.Replace(input, "<.*?>", string.Empty); // 정규식을 이용하여 태그 제거
        }
    }
}

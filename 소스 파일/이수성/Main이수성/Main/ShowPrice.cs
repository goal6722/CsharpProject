using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

public class ShowPrice
{
    public static async Task<List<string>> ShowPriceAsync(string productName)
    {
        List<string> abcdID = ReadApiID.readID();
        string clientId = abcdID[0];
        string clientSecret = abcdID[1];
        string query = productName;
        int display = 1;
        int start = 1;
        string sort = "sim";

        return await SearchAsync(clientId, clientSecret, query, display, start, sort); // 비동기 메서드 호출
    }

    private static async Task<List<string>> SearchAsync(string clientId, string clientSecret, string query, int display, int start, string sort)
    {
        List<string> NAMEnProduct = new List<string>();
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

            // 결과 출력 (HTML 태그 제거)
            for (int i = 0; i < titleNodes.Count; i++)
            {
                string title = RemoveHtmlTags(titleNodes[i].InnerText); // HTML 태그 제거
                string lprice = lpriceNodes[i].InnerText;

                NAMEnProduct.Add(title);
                NAMEnProduct.Add(lprice);
            }

            return NAMEnProduct;
        }
    }

    private static string RemoveHtmlTags(string input)
    {
        return Regex.Replace(input, "<.*?>", string.Empty); // 정규식을 이용하여 HTML 태그 제거
    }
}
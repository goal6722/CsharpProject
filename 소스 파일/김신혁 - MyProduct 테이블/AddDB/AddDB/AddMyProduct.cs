using System;
using System.Data.SqlClient;
using System.Xml;

public class XmlToDbHelper
{
    private static SqlConnection conn = new SqlConnection();

    private static void ConnectDB()
    {
        string dataSource = "909MA";//KB-PC
        string db = "MYDB";
        string security = "SSPI";
        conn.ConnectionString =
            $"Data Source={dataSource}; Initial Catalog={db};" +
            $"Integrated Security={security}; Timeout=3";

        conn.Open();
    }

    public static void InsertXmlDataToDb(string xmlFilePath)
    {
        try
        {
            ConnectDB();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("div_cd");

            foreach (XmlNode node in nodeList)
            {
                string item_cd = node.SelectSingleNode("item_cd")?.InnerText;
                string item_no = node.SelectSingleNode("item_no")?.InnerText;
                string div_l = node.SelectSingleNode("div_l")?.InnerText;
                string div_m = node.SelectSingleNode("div_m")?.InnerText;
                string div_s = node.SelectSingleNode("div_s")?.InnerText;
                string div_n = node.SelectSingleNode("div_n")?.InnerText;
                string comp_nm = node.SelectSingleNode("comp_nm")?.InnerText;
                string img_prod_nm = node.SelectSingleNode("img_prod_nm")?.InnerText;
                string volume = node.SelectSingleNode("volume")?.InnerText;
                string barcd = node.SelectSingleNode("barcd")?.InnerText;
                string nutrition_info = node.SelectSingleNode("nutrition_info")?.InnerText;

                string query = $"INSERT INTO MyProduct (item_cd, item_no, div_l, div_m, div_s, div_n, comp_nm, img_prod_nm, volume, barcd, nutrition_info) " +
                               $"VALUES ('{item_cd}', '{item_no}', '{div_l}', '{div_m}', '{div_s}', '{div_n}', '{comp_nm}', '{img_prod_nm}', '{volume}', '{barcd}', '{nutrition_info}')";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("DB 삽입 오류");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        finally
        {
            conn.Close();
        }
    }
}

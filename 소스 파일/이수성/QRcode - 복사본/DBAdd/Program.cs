using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QRcode
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            string basePath = "C:\\xml파일\\"; // xml 파일 경로
            string fileExtension = ".xml";

            for (int i = 1; i <= 9886; i++)
            {
                string fileName = i.ToString("D5") + fileExtension;
                string xmlFilePath = basePath + fileName;

                XmlToDbHelper.InsertXmlDataToDb(xmlFilePath);

                Console.WriteLine(i);
            }
        }
    }
}

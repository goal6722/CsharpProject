using System;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            string basePath = "C:\\Users\\sin00\\OneDrive\\문서\\GitHub\\c++++Project\\xml파일\\"; // xml 파일 경로
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

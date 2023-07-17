using IronBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode/docs/", BarcodeEncoding.Code128);
            barcode.SaveAsPng("barcode.png");
        }
    }
}

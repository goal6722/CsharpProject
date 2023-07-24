IronBarcode is a library developed and maintained by Iron Software that helps C# Software Engineers to read & write Barcodes and QR Codes in .NET applications & websites. Reading or writing barcodes only requires a single line of code with IronBarcode.

Visit our website for a quick-start guide at  https://ironsoftware.com/csharp/barcode/

C# Code Example
========================
using IronBarCode;

// Creating a barcode is as simple as:
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// Reading a barcode is easy with IronBarcode:
var resultFromFile = BarcodeReader.Read(@"file/barcode.png"); // From a file
var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf"); // From PDF use ReadPdf

// After creating a barcode, we may choose to resize and save which is easily done with:
myBarcode.ResizeTo(400, 100);
myBarcode.SaveAsImage("myBarcodeResized.jpeg");

Documentation Links
========================
Code Examples : https://ironsoftware.com/csharp/barcode/examples/barcode-quickstart/
API Reference : https://ironsoftware.com/csharp/barcode/object-reference/api/
Tutorials : https://ironsoftware.com/csharp/barcode/tutorials/reading-barcodes/
Licensing : https://ironsoftware.com/csharp/barcode/licensing/
Support : developers@ironsoftware.com

Compatibility
========================
* C#, F#, and VB.NET
* .NET 6, .NET 5, Core 2x & 3x, Standard 2, and Framework 4x
* Console, Web, and Desktop Apps
* Windows, macOs, Linux (Debian, CentOS, Ubuntu), Docker, Azure, and AWS
* Microsoft Visual Studio or Jetbrains ReSharper & Rider

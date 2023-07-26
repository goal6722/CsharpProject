IronBarCode  - The BarCode and QR Library for .Net 
=============================================================
Quickstart:  https://ironsoftware.com/csharp/barcode/
	


Installation
=============================================================
- Include all files from the netstandard2.0 folder into your project
- Add a Nuget Package Reference to System.Drawing.Common version 6.0.0


Compatibility
=============================================================
Supports applications and websites developed in 
- .Net FrameWork 4.6.2 (and above) for Windows and Azure
- .Net Core 2, 3 (and above) for Windows, Linux, MacOs and Azure
- .Net 5 for Windows, Linux, MacOs and Azure
- .Net 6 for Windows, Linux, MacOs and Azure
- .Net 7 for Windows, Linux, MacOs and Azure


C# Code Example
=============================================================
```
using IronBarCode;
    
// Create A Barcode in 1 Line of Code
BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.QRCode).SaveAsJpeg("QuickStart.jpg");

// Read A Barcode in 1 Line of Code.  
BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode("QuickStart.jpg");
```


Documentation
=============================================================

- Code Samples				:	https://ironsoftware.com/csharp/barcode/examples/barcode-quickstart/
- MSDN Class Reference		:	https://ironsoftware.com/csharp/barcode/object-reference/
- Tutorials					:	https://ironsoftware.com/csharp/barcode/tutorials/reading-barcodes/
- Support					:	developers@ironsoftware.com

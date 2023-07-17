![Nuget](https://img.shields.io/nuget/v/BarCode?color=informational&label=latest)  ![Installs](https://img.shields.io/nuget/dt/BarCode?color=informational&label=installs&logo=nuget)  ![Passed](https://img.shields.io/badge/build-%20%E2%9C%93%20413%20tests%20passed%20(0%20failed)%20-107C10?logo=visualstudio)  [![windows](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=windows)](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![macOS](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=apple)](https://ironsoftware.com/csharp/barcode/docs/questions/macos/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![linux](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=linux&logoColor=white)](https://ironsoftware.com/csharp/barcode/docs/questions/linux/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![docker](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=docker&logoColor=white)](https://ironsoftware.com/csharp/barcode/docs/questions/docker-linux/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) ![aws](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=amazonaws) [![microsoftazure](https://img.shields.io/badge/%E2%80%8E%20-%20%E2%9C%93-107C10?logo=microsoftazure)](https://ironsoftware.com/csharp/barcode/docs/questions/azure-support/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield) [![livechat](https://img.shields.io/badge/Live%20Chat-8%20Engineers%20Active%20Today-purple?logo=googlechat&logoColor=white)](https://ironsoftware.com/csharp/barcode/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topshield#helpscout-support)

# IronBarcode - The C# Barcode & QR Code Library


[![IronBarcode NuGet Trial Banner Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronBarcode-readme/nuget-trial-banner.png)](https://ironsoftware.com/csharp/barcode/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=topbanner#trial-license)

[Get Started](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Features](https://ironsoftware.com/csharp/barcode/features/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Code Examples](https://ironsoftware.com/csharp/barcode/examples/barcode-quickstart/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Licensing](https://ironsoftware.com/csharp/barcode/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation) | [Free Trial](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=navigation#trial-license)

IronBarcode is a library developed and maintained by Iron Software that helps C# Software Engineers to read & write Barcodes and QR Codes in .NET applications & websites. Reading or writing barcodes only requires a single line of code with IronBarcode.
 
### IronBarcode excels at:
- Read single or multiple Barcodes and QR Codes from images or PDFs.
- Image correction for skewing, orientation, noise, low resolution, contrast etc.
- Create barcodes and apply to images or PDF documents.
- Embed barcodes into HTML documents.
- Style Barcodes and add annotation text.
- QR Code Writing allows adding of logos, colors, and advanced QR alignment.

### IronBarcode has cross platform support compatibility with:
- **.NET 6** and .NET 5, Core 2x & 3x, Standard 2, and Framework 4x
- Windows, macOS, Linux, Docker, Azure, and AWS

[![IronBarcode Cross Platform Compatibility Support Image](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronBarcode-readme/cross-platform-compatibility.png)](https://ironsoftware.com/csharp/barcode/docs/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=crossplatformbanner)


Additionally, our [API reference](https://ironsoftware.com/csharp/barcode/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs) and [full licensing information](https://ironsoftware.com/csharp/barcode/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#trial-license) can easily be found on our website.

## Using IronBarcode

Installing the IronBarcode NuGet package is quick and easy, please install the package like this:
```
PM> Install-Package BarCode
```
Once installed, you can get started by adding `using IronBarCode` to the top of your C# code. Here is is sample Barcode Generating, Reading, and Saving example to get started:
```csharp
using IronBarCode;

// Creating a barcode is as simple as:
var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

// Reading a barcode is easy with IronBarcode:
var resultFromFile = BarcodeReader.Read(@"file/barcode.png"); // From a file
var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf"); // From PDF use ReadPdf

// After creating a barcode, we may choose to resize and save which is easily done with:
myBarcode.ResizeTo(400, 100);
myBarcode.SaveAsImage("myBarcodeResized.jpeg");
```
## Features Table
[![IronBarcode Features](https://raw.githubusercontent.com/iron-software/iron-nuget-assets/main/IronBarcode-readme/features-table.png)](https://ironsoftware.com/csharp/barcode/features/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=featuresbanner)

The .NET IronBarcode Library reads and writes most Barcode and QR standards. These include code 39/93/128, UPC A/E, EAN 8/13, ITF, RSS 14 / Expanded, Databar, CodaBar, Aztec, Data Matrix, MaxiCode, PDF417, MSI, Plessey, USPS, and QR. The barcode result data includes type, text, binary data, page, and image file.

The barcode reading engine includes automatic image correction and barcode detection technology to take the pain out of locating and reading from imperfect scans. Multithreading, cropping, and batch scanning provides fast and accurate scanning of multi page documents.

Barcode writing API checks and verifies format, length, number, checksum to automatically avoid encoding errors. Barcode writer allows for styling, resizing, margins, borders, recoloring, and adding text annotations. Write to image, PDF or HTML file.
#### Supported Barcode Formats:
- QR & 2D Matrix: QR (+ Styled QR), Aztec, Data Matrix, MaxiCode (Read Only) USPS IM Barcode (Read Only)
- Modern Linear Barcodes: Code 39, Code 128, PDF417, Rss14 (Read Only), RSS Expanded (Read Only)
- Older Linear Barcodes: UPC-A, UPC-E, EAN-8, EAN-13, Codabar, ITF, MSI, Plessey (Write Only)

#### Reading Barcodes:
- Read from many image formats: Images (JPG, PNG, GIF, TIFF, SVG, BMP), Multipage GIF & TIFF, System.Drawing Objects, Streams, PDF, and more
- Image Filters to improve image reading: Brightness, Contrast, Invert, Sharpen, and many more!
- Set Accuracy & Performance: Single / Multi Barcode Reading, Specify Crop Regions, Set Output Format, Multithreading Support
- Output to many data formats: Text Data, Numerical Data, Binary Data, Barcode Image
#### Writing Barcodes:
- Write To Document Types: Image (jpg, png, gif, tiff, bmp), System.Drawing Objects, Streams, HTML (DataURI, file, or img), PDF (File, Stream, or Binary), Existing PDF (Stamp position)
- Encoding Barcode Data: Text, urls, IDs, numbers, & binary data
- Checking Fault Tolerance: Null Check, Checksums, Format Aware, Detailed Error messages, Custom QR Error Correction
- Styling Barcodes: Resizing, Margins & Borders, Recoloring, Add text annotations, Add logos to QR

## Licensing & Support available
For code examples, tutorials and documentation visit https://ironsoftware.com/csharp/barcode/

For support please email us at developers@ironsoftware.com 

## Documentation Links

-   Code Examples : [(https://ironsoftware.com/csharp/barcode/examples/barcode-quickstart/](https://ironsoftware.com/csharp/barcode/examples/barcode-quickstart/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
-   API Reference : [https://ironsoftware.com/csharp/barcode/object-reference/api/](https://ironsoftware.com/csharp/barcode/object-reference/api/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
-   Tutorials : [https://ironsoftware.com/csharp/barcode/tutorials/csharp-barcode-image-generator/](https://ironsoftware.com/csharp/barcode/tutorials/csharp-barcode-image-generator/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
-   Licensing : [https://ironsoftware.com/csharp/barcode/licensing/](https://ironsoftware.com/csharp/barcode/licensing/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs)
- Live Chat Support : [https://ironsoftware.com/csharp/barcode/#helpscout-support](https://ironsoftware.com/csharp/barcode/?utm_source=nuget&utm_medium=organic&utm_campaign=readme&utm_content=supportanddocs#helpscout-support)

You can email us at developers@ironsoftware.com for support directly from our code team. We offer licensing and extensive support for commercial deployment projects.

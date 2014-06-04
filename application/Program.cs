using System;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using netSimpleHostConnection;

namespace application
{
	class Program
	{
		static void Main(string[] args)
		{
			var parsedArgs = new Arguments();

			if (args.Length == 0)
			{
				Console.WriteLine(Parser.ArgumentsUsage(typeof(Arguments)));
				return;
			}

			if (!Parser.ParseArgumentsWithUsage(args, parsedArgs))
			{
				Console.WriteLine("Can't parse arguments");
				return;
			}

			var writer = new BarcodeWriter
				{
					Format = BarcodeFormat.QR_CODE,
					Options = new EncodingOptions
						{
							Height = parsedArgs.Size,
							Width = parsedArgs.Size,
							PureBarcode = true,
							Margin = 0
						},
					Renderer = (IBarcodeRenderer<Bitmap>) Activator.CreateInstance(typeof (BitmapRenderer))
				};

			var bitmap = writer.Write(parsedArgs.Content);
			bitmap.SetResolution(parsedArgs.DPI, parsedArgs.DPI);
			bitmap.Save(parsedArgs.Output);
		}
	}
}

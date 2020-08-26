using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using ZXing;


namespace BarcodeScanner.Services
{
    public class BarcodeScannerService
    {
        public async Task<string> StreamToBase64StringAsync(MemoryStream stream)
        {
            stream.Seek(0, 0);
            var base64 = Convert.ToBase64String(stream.ToArray());
            return base64;
        }

        public async Task<string> GetBarcodeFromFileAsync(MemoryStream stream)
        {
            try
            {
                var coreCompatReader = new BarcodeReader();
                stream.Seek(0, 0);
                var coreCompatImage = (Bitmap) Image.FromStream(stream);

                var coreCompatResult = coreCompatReader.Decode(coreCompatImage);
                return coreCompatResult != null ? coreCompatResult.Text : "empty";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }

        }
    }
}
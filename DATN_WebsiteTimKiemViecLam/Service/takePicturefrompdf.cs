using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Ghostscript.NET;
using System.Drawing.Imaging;
using Ghostscript.NET.Rasterizer;

namespace DATN_WebsiteTimKiemViecLam.Service
{
    public class TakePictureFromPdf
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TakePictureFromPdf(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> DisplayFirstPage(string linkDriver)
        {
           

            // Chuyển đổi trang đầu tiên của tệp PDF thành hình ảnh và mã hóa nó thành Base64
            string base64Image = await ConvertPdfToBase64(linkDriver);

            // Trả về chuỗi Base64
            return base64Image;
        }
        private async Task<string> ConvertPdfToBase64(string googleDrivePdfLink)
        {
            var httpClient = _httpClientFactory.CreateClient();

            // Tải tệp PDF từ Google Drive
            HttpResponseMessage response = await httpClient.GetAsync(googleDrivePdfLink);

            if (response.IsSuccessStatusCode)
            {
                byte[] pdfBytes = await response.Content.ReadAsByteArrayAsync();

                using (MemoryStream ms = new MemoryStream(pdfBytes))
                {
                    // Sử dụng Ghostscript.NET để chuyển đổi PDF thành hình ảnh
                    using (var rasterizer = new GhostscriptRasterizer())
                    {
                        rasterizer.Open(ms);

                        // Chọn định dạng hình ảnh và độ phân giải ở đây
                        ImageFormat format = ImageFormat.Png;
                        int dpiX = 96;
                        int dpiY = 96;

                        // Render trang đầu tiên của PDF vào hình ảnh
                        using (var image = rasterizer.GetPage(1, dpiX, dpiY))
                        {
                            // Chuyển đổi hình ảnh thành mã Base64
                            using (MemoryStream msImage = new MemoryStream())
                            {
                                image.Save(msImage, format);
                                return Convert.ToBase64String(msImage.ToArray());
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}

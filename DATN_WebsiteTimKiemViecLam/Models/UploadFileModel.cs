using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using static NuGet.Packaging.PackagingConstants;

namespace DATN_WebsiteTimKiemViecLam.Models
{
    public class UploadFileModel 
    {
        public String OnPostAsync(IFormFile file, string txtGioithieu)
        {
            string credentialsPath = "C:\\Users\\admin\\Desktop\\Thực Tập\\DATN_WebsiteTimKiemViecLam\\DATN_WebsiteTimKiemViecLam\\smiling-stock-419405-5e97ff207bf9.json";

            using (var stream = new MemoryStream())
            {
                 file.CopyToAsync(stream);
                stream.Position = 0;

                string mimeType = file.ContentType;
                DriveServiceHelper serviceHelper = new DriveServiceHelper(credentialsPath);
                string fileLink = serviceHelper.UploadStream(stream, file.FileName, mimeType, "1RsB5i8g0jjKWPe7eSQHhgAmixiwj2fmF");
              
                return fileLink;
            }
        }
    }
    public class DriveServiceHelper
    {
        private DriveService _driveService;

        public DriveServiceHelper(string credentialsPath)
        {
            var credential = GoogleCredential.FromFile(credentialsPath)
                .CreateScoped(new[] { DriveService.Scope.Drive });
            _driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
        }

        public string UploadStream(Stream stream, string fileName, string mimeType, string folderID)
        {
            var body = new Google.Apis.Drive.v3.Data.File
            {
                Name = fileName,
                Parents = new List<string> { folderID }
            };

            FilesResource.CreateMediaUpload request = _driveService.Files.Create(body, stream, mimeType);
            request.Fields = "id";
            request.Upload();

            var uploadedFile = request.ResponseBody;
            return $"https://drive.google.com/file/d/{uploadedFile.Id}/view";
        }
    }
}


using System.IO;
using System.Threading.Tasks;

namespace FileDownloadBot.Services
{
    public static class FileServices
    {
        public static async Task SaveFileAsync(Stream content, string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                await content.CopyToAsync(fileStream);
            }
        }

        public static string GetDownloadPath(string basePath, string folderName)
        {
            string fullPath = Path.Combine(basePath, folderName);
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            return fullPath;
        }
    }
}

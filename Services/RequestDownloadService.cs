using System.Net.Http;
using FileDownloadBot.Models;
using FileDownloadBot.Services;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FileDownloadBot.Services
{
    public class RequestDownloadService
    {
        private readonly HttpClient _httpClient = new();

        public async Task DownloadByRequestAsync(List<DownloadFile> files, string basePath)
        {
            foreach (var file in files)
            {
                var response = await _httpClient.GetAsync(file.Url);
                var path = Path.Combine(FileServices.GetDownloadPath(basePath, file.SizeLabel), file.FileName);

                using var content = await response.Content.ReadAsStreamAsync();
                await FileServices.SaveFileAsync(content, path);
            }
        }
    }
}

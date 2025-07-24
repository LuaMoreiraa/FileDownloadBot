using Xunit;
using FileDownloadBot.Services;
using System.IO;
using System.Threading.Tasks;

public class FileServiceTests
{
    [Fact]
    public void CreateDirectory_ShouldCreateProperPath()
    {
        string path = FileServices.GetDownloadPath(@"C:\TestDownload\", "100MB");
        Assert.True(Directory.Exists(path));
    }

    [Fact]
    public async Task SaveFileAsync_ShouldSaveContent()
    {
        var content = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("test content"));
        string path = @"C:\TestDownload\testfile.txt";

        await FileServices.SaveFileAsync(content, path);

        Assert.True(File.Exists(path));

        if (File.Exists(path))
            File.Delete(path);
    }

}

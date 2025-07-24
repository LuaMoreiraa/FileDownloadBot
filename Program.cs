using FileDownloadBot.Services;
using FileDownloadBot.Models;
using FileDownloadBot;

var navigator = new NavigatorService();
navigator.NavigateToTestFilesSite();
var driver = navigator.GetDriver();

var downloadFiles = new List<DownloadFile>
{
    new() { FileName = "100MB.Bin", Url= "https://fsn1-speed.hetzner.com/100MB.bin",SizeLabel = "100MB"},
    new() { FileName = "1GB.Bin", Url= "https://fsn1-speed.hetzner.com/1GB.bin", SizeLabel = "1GB"},
    new() { FileName = "10GB.Bin", Url= "https://fsn1-speed.hetzner.com/10GB.bin", SizeLabel = "10GB"},
};

var clickDownloader = new ClickDownloadService(driver);
clickDownloader.DownloaddByClick(downloadFiles);

var requestDownload = new RequestDownloadService();
await requestDownload.DownloadByRequestAsync(downloadFiles, @"C:\Downloads\Requests");

navigator.Quit();
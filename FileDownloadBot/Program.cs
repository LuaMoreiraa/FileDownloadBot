using FileDownloadBot.Services;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        RunDownloadAutomation();
    }

    static void RunDownloadAutomation()
    {
        var navigator = new NavigatorService();
        string downloadFolder = @"C:\Downloads";

        try
        {
            navigator.NavigateToDownloadPage();

            DownloadAndWait(navigator, "100MB.bin", downloadFolder, 30);
            DownloadAndWait(navigator, "1GB.bin", downloadFolder, 60);
            DownloadAndWait(navigator, "10GB.bin", downloadFolder, 300);

            Console.WriteLine("Todos os downloads foram iniciados.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        finally
        {
            navigator.Quit();
        }
    }

    static void DownloadAndWait(NavigatorService navigator, string fileName, string folder, int timeoutSeconds)
    {
        string filePath = Path.Combine(folder, fileName);
        if (File.Exists(filePath))
            File.Delete(filePath);

        navigator.DownloadFile(fileName);
        Console.WriteLine($"Aguardando download de {fileName}...");

        int waited = 0;
        while (!File.Exists(filePath) && waited < timeoutSeconds * 1000)
        {
            Thread.Sleep(500);
            waited += 500;
        }

        if (File.Exists(filePath))
            Console.WriteLine($"Download concluído: {fileName}");
        else
            Console.WriteLine($"Timeout: {fileName} não foi baixado em {timeoutSeconds}s.");
    }
}

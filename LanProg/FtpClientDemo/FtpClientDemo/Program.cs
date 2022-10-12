using System.Net;

var ip = "96.126.107.50";

async Task<string> ListFiles(string ip, string user, string password, string directory = "/")
{
    var ftpRequest = WebRequest.Create($"ftp://{ip}{directory}") as FtpWebRequest;
    ftpRequest.Credentials = new NetworkCredential(user, password);
    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    var ftpResponse = await ftpRequest.GetResponseAsync() as FtpWebResponse;
    var stream = ftpResponse.GetResponseStream();
    var reader = new StreamReader(stream);
    return await reader.ReadToEndAsync();
}

async Task<string> RetriveTextFile(string ip, string user, string password, string path)
{
    var ftpRequest = WebRequest.Create($"ftp://{ip}/{path}") as FtpWebRequest;
    ftpRequest.Credentials = new NetworkCredential(user, password);
    ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
    var ftpResponse = await ftpRequest.GetResponseAsync() as FtpWebResponse;
    var stream = ftpResponse.GetResponseStream();
    var reader = new StreamReader(stream);
    return await reader.ReadToEndAsync();
}

Console.WriteLine("Folder / contents:");
Console.WriteLine(await ListFiles(ip, "yuriy", "password"));

Console.WriteLine("File readme.txt contents:");
Console.WriteLine(await RetriveTextFile(ip, "yuriy", "password", "readme.txt"));
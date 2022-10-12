using System.Net;

string ip = "96.126.107.50";

async Task PutFileToFtp(string host, string user, string password, string dir, string file)
{
    var request = FtpWebRequest.Create($"ftp://{host}/{file}");
    request.Credentials = new NetworkCredential(user, password);
    request.Method = WebRequestMethods.Ftp.UploadFile;

    using var fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
    using var requestStream = request.GetRequestStream();
    await fileStream.CopyToAsync(requestStream);

}

await PutFileToFtp(ip, "yuriy", "password", "/", "readme.txt");


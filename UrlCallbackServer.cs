using System;
using System.Net;
using System.Text;

namespace JiraTempoAppGodot;

public static class UrlCallbackServer
{
    public const string CallbackUrl = "http://localhost:3000/";
    private const string ResponseText = "Ok! You can close this window!";

    public static string WaitAndGetCodeFromQueryParam()
    {
        using var listener = new HttpListener();
        listener.Prefixes.Add(CallbackUrl);
        listener.Start();

        Console.WriteLine($"Listening on {CallbackUrl}");

        var context = listener.GetContext();
        var query = context.Request.QueryString;
        var code = query["code"];
        using var response = context.Response;

        // return ok
        response.StatusCode = (int)HttpStatusCode.OK;
        response.StatusDescription = "Status OK";

        // return response text
        var data = ResponseText;
        var buffer = Encoding.UTF8.GetBytes(data);
        response.ContentLength64 = buffer.Length;
        using var responseOutputStream = response.OutputStream;
        responseOutputStream.Write(buffer, 0, buffer.Length);

        listener.Stop();

        return code;
    }
}
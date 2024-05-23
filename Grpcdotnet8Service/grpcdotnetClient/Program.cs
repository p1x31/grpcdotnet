using Grpc.Core;
using Grpc.Net.Client;
using Grpcdotnet8Service;
using System.IO.IsolatedStorage;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;



WinHttpHandler handler = new WinHttpHandler()
{
    SslProtocols = SslProtocols.Tls13,
    WindowsProxyUsePolicy = WindowsProxyUsePolicy.DoNotUseProxy
};

X509Certificate2 cert = new X509Certificate2("C://Users//User//dev//grpcdotnet//Grpcdotnet8Service//grpcdotnetClient//ca.pfx", "test");
handler.ClientCertificates.Add(cert);

GrpcChannelOptions options = new GrpcChannelOptions() { HttpHandler = handler };

using var channel = GrpcChannel.ForAddress("https://localhost:7215", options);



var client = new Greeter.GreeterClient(channel);


Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

Console.Write("name: ");
var name = Console.ReadLine();
var watch = System.Diagnostics.Stopwatch.StartNew();
var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
Console.WriteLine($"server reply: {reply.Message}");
watch.Stop();
var elapsedMs = watch.ElapsedMilliseconds;
Console.WriteLine($"{elapsedMs} ms taken");

Console.ReadKey();

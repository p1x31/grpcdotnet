using Grpc.Core;
using Grpc.Net.Client;
using Grpcdotnet8Service;
using System.IO.IsolatedStorage;
using System.Text;


using var channel = GrpcChannel.ForAddress("https://localhost:7215", new GrpcChannelOptions
{
    HttpHandler = new WinHttpHandler()
});


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

using Grpc.Net.Client;
using Server;

// using var channel = GrpcChannel.ForAddress("https://localhost:5001");
// var client = new Greeter.GreeterClient(channel);
// Console.Write("Введите имя: ");
// string name = Console.ReadLine();
// var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
// Console.WriteLine("Ответ сервера: " + reply.Message);
// Console.ReadKey();


var locker = new object();

for (int i = 1; i < 6; i++)
{
    var thread = new Thread(Print);
    thread.Name = i.ToString();
    thread.Start();
}


void Print()
{
    lock (locker)
    {
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
            Thread.Sleep(1000);
        }
    }
}
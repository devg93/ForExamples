// using System.Threading.Channels;

// var channel = Channel.CreateBounded<string>(new BoundedChannelOptions(100)
// {
//     FullMode = BoundedChannelFullMode.Wait
// });


//   // Producer
//         _ = Task.Run(async () =>
//         {
//             for (int i = 0; i < 5; i++)
//             {
//                 await channel.Writer.WriteAsync($"Message {i}");
//                 //await Task.Delay(500);
//             }

//             channel.Writer.Complete(); // დაასრულე ჩაწერა
//         });

// // მომხმარებელი (consumer)
// await foreach (var item in channel.Reader.ReadAllAsync())
// {
//     Console.WriteLine(item); // hello, world
// }


public class Program
{
    public static void Main(string[] args)
    {
        // Channel example is commented out above.
        // You can uncomment and run the code to see how it works.

        var arr = new
        {
            Name = "John",
            Age = 30,
            IsEmployed = true,
            Address = new { City = "New York", ZipCode = "10001" }

        };

        Console.WriteLine($"{arr}");
    }
}
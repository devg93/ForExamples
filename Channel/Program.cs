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









// using System.Reflection.Metadata;

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// public sealed class Repository
// {
//     // ერთი საერთო საცავი ყველა ინსტანსისთვის
//     private static readonly List<object> _items = new();
//     // საერთო lock static საცავზე
//     private static readonly object _sync = new();

//     // სინქრონული ოპერაციაა → ან გავხდათ ბოლომდე სინქრონი, ან ვაბრუნებთ ValueTask-ს სწორად
//     public ValueTask<bool> AddAsync(object? item)
//     {
//         if (item is null) return new ValueTask<bool>(false);

//         lock (_sync)
//         {
//             _items.Add(item);
//             // საჭიროების შემთხვევაში აქ შეგიძლია დაბეჭდო Count/Capacity
//             Console.WriteLine($"Count = {_items.Count}, Capacity = {_items.Capacity}");
//         }

//         return new ValueTask<bool>(true);
//     }

//     public ValueTask<IReadOnlyList<object>> GetAllAsync()
//     {
//         lock (_sync)
//         {
//             // კოპიას ვაბრუნებთ, რომ გარეთ ვერ შეცვალონ შიდა ლისტი
//             return new ValueTask<IReadOnlyList<object>>(_items.ToList());
//         }
//     }
// }

// public class Program
// {
//     // Main ასინქრონული, რომ await იმუშაოს
//     public static async Task Main(string[] args)
//     {
//         var repository = new Repository();

//         await repository.AddAsync("Hello, World!");
//         await repository.AddAsync(42);
//         await repository.AddAsync(3.14);
//         await repository.AddAsync(true);
//         await repository.AddAsync(new { Name = "Alice", Age = 25 });
//         await repository.AddAsync(new { Name = "Alice", Age = 25 });

//         var all = await repository.GetAllAsync();
//         foreach (var res in all)
//         {
//             Console.WriteLine($"item: {res}");
//         }

//         var arr = new
//         {
//             Name = "John",
//             Age = 30,
//             IsEmployed = true,
//             Address = new { City = "New York", ZipCode = "10001" }
//         };
//         Console.WriteLine(arr);
//     }
// }



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Repository
{
    private static readonly List<object> items = new List<object>();

    public ValueTask<bool> AddAsync(object? item)
    {
        if (item != null)
        {
            items.Add(item);
            return new ValueTask<bool>(true);
        }
        return new ValueTask<bool>(false);
    }

    public ValueTask<List<object>> GetAllAsync()
    {
        return new ValueTask<List<object>>(items.ToList());
    }
}

public class Program
{
    public static async Task Main()
    {
        var repo = new Repository();

        // --- await-ის გარეშე ---
        var taskWithoutAwait = repo.AddAsync("Hello Giorgi Tugushia");
        Console.WriteLine(taskWithoutAwait); 
        // გამოიტანს ValueTask<Boolean>, არა შედეგს

        // --- await-ით ---
        bool resultWithAwait = await repo.AddAsync("Hello Again Giorgi Tugushia");
        Console.WriteLine(resultWithAwait); 
        // გამოიტანს True, ანუ შედეგი უკვე ამოღებულია

        // --- await-ის გარეშე GetAll ---
        var taskList = repo.GetAllAsync();
        Console.WriteLine(taskList); 
        // გამოიტანს ValueTask<List<Object>>, არა ლისტს

        // --- await-ით GetAll ---
        var list = await repo.GetAllAsync();
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}

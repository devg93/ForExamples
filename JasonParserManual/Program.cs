using System.Text.Json;
using JasonParserManual;
public class Program
{
    public class Ex
    {
        [SkipJson]
        public string? Name { get; set; }
        public string? Lname { get; set; }
    }



    public class Ex2
    {
        public string? Name2 { get; set; }
        public string? Lname2 { get; set; }
    }
    public static void Main(string[] args)
    {

        string fileName = "/home/neo/Desktop/ForExamples/JasonParserManual/WeatherForecast.json";

        string jsonString = File.ReadAllText(fileName);


        var p = new { FirstName = "Anna", SecretNote = "don't share" };
        string json = CustomSerialize2.CustomSerialize(p);
        Console.WriteLine(json);


        Ex2 weatherForecast = JsonSerializer.Deserialize<Ex2>(jsonString)!;



        //===========================================================================================//

        var res = JsonSerializer.Serialize(new Ex { Name = "name", Lname = "Lname" });

        var res2 = JsonSerializer.Deserialize<Ex>(res);
    }
}
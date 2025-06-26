
using System.Text.Json;


namespace JasonParserManual;

public class CustomSerialize2
{
    public static string CustomSerialize<T>(T obj)
    {
        var props = typeof(T).GetProperties();
        var dict = new Dictionary<string, object>();

        foreach (var prop in props)
        {
            if (Attribute.IsDefined(prop, typeof(SkipJsonAttribute)))
                continue;

            dict[prop.Name] = prop.GetValue(obj);
        }

        return JsonSerializer.Serialize(dict);
    }

}

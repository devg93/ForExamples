public interface IMethodFactory
{
    void Print(string key);
}


public class Word : IMethodFactory
{
    public void Print(string key1)
    {
        Console.WriteLine($"word print this key ->> {key1} ");
    }
}

public class Pdf : IMethodFactory
{
    public void Print(string key2)
    {
        Console.WriteLine($"Pdf print this key ->> {key2}");
    }
}

//=================================================================//
public abstract class Creator
{
    public abstract IMethodFactory CreateAnimal();
}

public class WordCretor : Creator
{
    public override IMethodFactory CreateAnimal()
    => new Word();
}

public class PdfCretor : Creator
{
    public override IMethodFactory CreateAnimal()
       => new Pdf();
}

//========================================================================
public class Program
{
    public static void Main(string[] args)
    {
        Creator creator = new WordCretor();
        creator.CreateAnimal().Print("word");

        Creator creator2 = new PdfCretor();
        creator2.CreateAnimal().Print("Pdf");

        
    }
}
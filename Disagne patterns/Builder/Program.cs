using System;
using System.Diagnostics;

[DebuggerDisplay("{Mouse} | {Display} | {Keyboard}")]
public class Computer
{
    public string? Mouse { get; set; }
    public string? Display { get; set; }
    public string? Keyboard { get; set; }

    // public Computer SetDisplay(string value)
    // {

    //     Display = value;
    //     return this;
    // }

    // public Computer SetKeyboard(string value)
    // {
    //     Keyboard = value;
    //     return this;
    // }

    // public Computer SetMouse(string value)
    // {
    //     Mouse = value; return this;
    //  }



    // public override bool Equals(object? obj)
    // {
    //     return base.Equals(obj);

    // }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    // public override string ToString()
    // {
    //     return $"Mouse: {Mouse}, Display: {Display}, Keyboard: {Keyboard}";
    // }
}

public interface IComputerBuilder
{
    void SetMouse(string value);
    void SetDisplay(string value);
    void SetKeyboard(string value);

    Computer GetComputerInstance();
}

public class ComputerBuilder : IComputerBuilder
{
    private readonly Computer _computer = new();

    public void SetDisplay(string value) => _computer.Display = value;
    public void SetKeyboard(string value) => _computer.Keyboard = value;
    public void SetMouse(string value) => _computer.Mouse = value;

    public Computer GetComputerInstance() => _computer;
}



// ComputerBuilder 2 constructor chainig

public class ComputerBuilderConstructorChaining
{

    private Computer _computer = new();
    private delegate void SetMethod<in T>(T value);

    private ComputerBuilderConstructorChaining Do2(SetMethod<Computer> set)
    {
        set(_computer);
        return this;
    }
    private ComputerBuilderConstructorChaining Do(Action<Computer> set)
    {
        set(_computer);
        return this;
    }

    public ComputerBuilderConstructorChaining SetKeyboard2(string value)
        => Do(c => c.Keyboard = value);

    public ComputerBuilderConstructorChaining SetDisplay2(string value)
   => ReturnThis(_computer.Display = value);

    public ComputerBuilderConstructorChaining SetMouse2(string value)
        => ReturnThis(_computer.Mouse = value);

    //==============================================================================//

    public ComputerBuilderConstructorChaining SetKeyboard(string value)
        => ReturnThis(_computer.Keyboard = value);

    public ComputerBuilderConstructorChaining SetDisplay(string value)
        => ReturnThis(_computer.Display = value);

    public ComputerBuilderConstructorChaining SetMouse(string value)
        => ReturnThis(_computer.Mouse = value);

    public Computer Build() => _computer;

    // ჰელპერი: მნიშვნელობას იგნორირებს და აბრუნებს this-ს
    private ComputerBuilderConstructorChaining ReturnThis<T>(T _)
        => this;




}


public class Program
{
    public static void Main(string[] args)
    {
        IComputerBuilder builder = new ComputerBuilder();

        builder.SetDisplay("Dell Monitor");
        builder.SetKeyboard("Logitech Keyboard");
        // builder.SetMouse("Razer Mouse");

        // var result = builder.GetComputerInstance();
        //  Console.WriteLine($"GetComputerInstance -> { builder.GetComputerInstance()}");
        ComputerBuilderConstructorChaining computerBuilderConstructorChainig = new();
        computerBuilderConstructorChainig.SetDisplay("");


        var c = builder.GetComputerInstance();
        Console.WriteLine($"Mouse={c.Mouse}, Display={c.Display}, Keyboard={c.Keyboard}");


    }
}

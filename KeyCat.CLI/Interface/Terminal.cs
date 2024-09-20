namespace KeyCat.CLI.Interface;

public static class Terminal
{
    public static void Print(string message) => Console.Write(message);
    public static void Print(string message, ConsoleColor fontColor)
    {
        Console.ForegroundColor = fontColor;
        Console.Write(message);
        Console.ResetColor();
    }

    public static void PrintLine(string message) => Console.WriteLine(message);
    public static void PrintLine(string message, ConsoleColor fontColor)
    {
        Console.ForegroundColor = fontColor;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static bool PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
        return false;
    }

    public static string Input()
    {
        return Console.ReadLine() ?? "";
    }

    public static void Input(out string input)
    {
        input = Console.ReadLine() ?? "";
    }

    public static string Input(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }

    public static void Input(string message, out string input)
    {
        Console.Write(message); 
        input = Console.ReadLine() ?? "";
    }

    public static string Input(string message, ConsoleColor fontColor)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(message);
        Console.ResetColor();
        return Console.ReadLine() ?? "";
    }

    public static void Input(string message, ConsoleColor fontColor, out string input)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(message);
        Console.ResetColor();
        input = Console.ReadLine() ?? "";
    }
}
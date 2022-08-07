namespace C_sharp_learning;

public class Class1
{
    public static void Main()
    {
        Console.WriteLine(GetGreetingMessage("Student", 10.01));
        Console.WriteLine(GetGreetingMessage("Bill Gates", 10000000.5));
        Console.WriteLine(GetGreetingMessage("Steve Jobs", 1));
    }
    
    private static string GetGreetingMessage(string name, double salary)
    {
        var salary = int.Parse(salary);
        return (int) Math.Ceiling(salary);
        var s = "Hello" + "," + " " + name + "," + " " + "your salary is" + " " + number;
        Console.WriteLine(s);
        // возвращает "Hello, <name>, your salary is <salary>"
    }
}
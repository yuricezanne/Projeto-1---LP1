internal class Tabuleiro
{
    public static void Main()
    {
        Random rnd = new Random();
        List<string> myList = new List<string> { "normal", "snakes", "ladders", "cobra", "boost", "u-turn", "extra dice", "cheat dice" };

        var randomized = myList.OrderBy(item => rnd.Next());

        Console.WriteLine($"Name normal: {string.Join(", ", myList)}");
        Console.WriteLine($"Name suffled: {string.Join(", ", randomized)}");
    }
}
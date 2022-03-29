public static void Main()
{
    Random rnd = new Random();
    List<string> myList = new List<string> { "normal", "snakes", "ladders", "cobra", "boost", "u-turn", "extra dice", "cheat dice" };

    var randomized = myList.OrderBy(item => rnd.Next());
    List<string> finalList = randomized.ToList();
    finalList.Insert(0, "normal");
    finalList.Add("normal");

    int[] casas = new int[myList.Count];

    Console.WriteLine($"Name normal: {string.Join(", ", myList)}");
    Console.WriteLine($"Name shuffled: {string.Join(", ", finalList)}");
}

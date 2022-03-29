List[Random.Range(1, List.Count)];
class Tabuleiro
{
    int[] matrix = new int[5, 5] {"normal", "snakes", "ladders", "cobra", "boost", "u-turn", "extra dice", "cheat dice"};
    Random rnd = new Random();
    int index = rnd.Next(matrix.Length);
    Console.WriteLine($"Name: {names[index]");
}




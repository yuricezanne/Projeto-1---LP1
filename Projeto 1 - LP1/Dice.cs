namespace Projeto_1___LP1
{
    /// <summary>
    /// Class Dice
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// Generates dice number
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int DiceNumberGenerator(
            Player player)
        {
            int diceNumber;
            Random random = new Random();
            diceNumber = random.Next(1, 7);

            switch (player.Name)
            {
                case "Player 1":
                    Console.WriteLine("Player 1, press NumPad 1 to roll the dice.");
                    if (Console.ReadKey().Key == ConsoleKey.NumPad1)
                    {
                        Console.WriteLine("You rolled a " + diceNumber);
                        return diceNumber;
                    }
                    break;
                case "Player 2":
                    Console.WriteLine("Player 2, press NumPad 2 to roll the dice.");
                    if (Console.ReadKey().Key == ConsoleKey.NumPad2)
                    {
                        Console.WriteLine("You rolled a " + diceNumber);
                        return diceNumber;
                    }
                    break;
            }
            return 0;
        }
    }   
}
namespace Projeto_1___LP1
{
    public class MainMenu
    {
        public static void GameBoot()
        {
            Console.WriteLine("ULHT presents - \nSnakes & Ladders \na game by Yuri Pinto, Vasco Anjos & Bernardo Schmidt\n\n\nPRESS SPACEBAR TO START");

            if(Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Game game = new Game();
                game.StartGame();
            }
        }
    }
}

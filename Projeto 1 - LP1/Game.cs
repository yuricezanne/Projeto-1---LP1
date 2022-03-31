namespace Projeto_1___LP1
{
    public class Game
    {
        public void StartGame()
        {
            Player player1 = new Player()
            {
                Name = "Player 1",
                CurrentSquare = 1,
                HasCheatDice = false,
                HasExtraDice = false,
            };
            Player player2 = new Player()
            {
                Name = "Player 2",
                CurrentSquare = 1,
                HasCheatDice = false,
                HasExtraDice = false,
            };
            Board board = new Board();
            board.BoardGenerator();
        }
        
       
    }
}

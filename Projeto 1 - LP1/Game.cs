namespace Projeto_1___LP1
{
    /// <summary>
    /// Class Game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Starts game
        /// </summary>
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
            var createdBoard = board.BoardGenerator();
            Dice dice = new Dice();

            string currentPlayer = player1.Name;

            //Game does not end before player reaches square 25
            while (player1.CurrentSquare != 25 || player2.CurrentSquare != 25)
            {
                if (currentPlayer.Equals(player1.Name))
                {
                    player1.CurrentSquare += dice.DiceNumberGenerator(player1);
                    player1.CurrentSquare = SquareChecker(createdBoard, player1.CurrentSquare);

                    currentPlayer = player2.Name;
                }
                else
                {
                    currentPlayer = player1.Name;
                }
            }
        }

        /// <summary>
        /// Calculates player position
        /// </summary>
        /// <param name="board"></param>
        /// <param name="playerSquare"></param>
        /// <returns></returns>
        private int SquareChecker(
            SortedDictionary<int, string> board, 
            int playerSquare)
        {
            string currentSquare = board[playerSquare];

            switch (currentSquare)
            {
                case "normal":
                    return playerSquare;
                case "snakes":
                    var snakeSquare = playerSquare - 5;
                    if (snakeSquare < 1)
                    {
                        return 1;
                    }
                    return snakeSquare;
                case "ladders":
                    return playerSquare;
                case "cobra":
                    return playerSquare;
                case "boost":
                    return playerSquare;
                case "u-turn":
                    return playerSquare;
                case "extra dice":
                    return playerSquare;
                case "cheat dice":
                    return playerSquare;
            }
            return playerSquare;
        }
       
    }
}

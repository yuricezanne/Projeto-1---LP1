namespace Projeto_1___LP1
{
    /// <summary>
    /// Class Game
    /// </summary>
    public class Game
    {
       
        public bool _player1UsedCheatDice;
        public bool _player2UsedCheatDice;

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
            string winner = string.Empty;

            //Game does not end before player reaches square 25
            while (!player1.Winner && !player2.Winner)
            {
                if (currentPlayer.Equals(player1.Name))
                {
                    bool usedExtraDice = false;
                    if (player1.HasExtraDice)
                    {
                        Console.WriteLine("Player 1, do you want to use the Extra Dice? Y/N");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            usedExtraDice = true;
                            player1.HasExtraDice = false;
                            player1.CurrentSquare += dice.DiceNumberGenerator(player1);
                            player1 = SquareChecker(
                                createdBoard,
                                player1);

                            if(player1.CurrentSquare >= 25)
                            {
                                continue;
                            }
                        }
                    }

                    int player1NumberMoves = dice.DiceNumberGenerator(player1);
                    int alteredDiceValue = 0;

                    if (player1.HasCheatDice && !usedExtraDice && !_player1UsedCheatDice)
                    {
                        Console.WriteLine("Player 1, do you want to use the Cheat Dice? Y/N");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            _player1UsedCheatDice = true;
                            player1.HasCheatDice = false;
                            Console.WriteLine("\nInsert a value between 1 and 6");
                            string? value = string.Empty;

                            while (string.IsNullOrEmpty(value) &&
                                !Enumerable.Range(1, 6).Contains(alteredDiceValue))
                            {
                                try
                                {
                                    value = Console.ReadLine();
                                    alteredDiceValue = int.Parse(value);
                                }
                                catch
                                {
                                    value = null;
                                    alteredDiceValue = 0;
                                }
                            }
                            player1.CurrentSquare = +alteredDiceValue;
                        }
                    }

                    player1.CurrentSquare += player1NumberMoves;

                    player1 = SquareChecker(
                        createdBoard,
                        player1);

                    Console.WriteLine($"player1 current square: {player1.CurrentSquare}");

                    if (player1.CurrentSquare >= 25)
                    {
                        player1.Winner = true;
                        winner = player1.Name;
                        continue;
                    }

                    currentPlayer = player2.Name;
                }
                else
                {
                    bool usedExtraDice = false;
                    if (player2.HasExtraDice)
                    {
                        Console.WriteLine("Player 2, do you want to use the Extra Dice? Y/N\n");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            usedExtraDice = true;
                            player2.HasExtraDice = false;
                            player2.CurrentSquare += dice.DiceNumberGenerator(player2);
                            player2 = SquareChecker(
                                createdBoard,
                                player2);

                            if (player2.CurrentSquare >= 25)
                            {
                                continue;
                            }
                        }
                    }

                    int player2NumberMoves = dice.DiceNumberGenerator(player2);
                    int alteredDiceValue = 0;

                    if (player2.HasCheatDice && !usedExtraDice && !_player2UsedCheatDice)
                    {
                        Console.WriteLine("Player 2, do you want to use the Cheat Dice? Y/N");
                        if (Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            player2.HasCheatDice = false;
                            _player2UsedCheatDice = true;
                            Console.WriteLine("\nInsert a value between 1 and 6");
                            string? value = string.Empty;

                            while (string.IsNullOrEmpty(value) &&
                                !Enumerable.Range(1, 6).Contains(alteredDiceValue))
                            {
                                try
                                {
                                    value = Console.ReadLine();
                                    alteredDiceValue = int.Parse(value);
                                }
                                catch
                                {
                                    value = null;
                                    alteredDiceValue = 0;
                                }
                            }
                            player2.CurrentSquare = +alteredDiceValue;
                        }
                    }

                    player2.CurrentSquare += player2NumberMoves;

                    player2 = SquareChecker(
                        createdBoard,
                        player2);

                    Console.WriteLine($"player2 current square: {player2.CurrentSquare}");

                    if (player2.CurrentSquare >= 25)
                    {
                        player2.Winner = true;
                        winner = player2.Name;
                        continue;
                    }

                    currentPlayer = player1.Name;
                }
            }

            Console.WriteLine($"{winner} won the game!");
        }

        /// <summary>
        /// Calculates player position
        /// </summary>
        /// <param name="board"></param>
        /// <param name="playerSquare"></param>
        /// <returns></returns>
        private Player SquareChecker(
            SortedDictionary<int, string> board,
            Player player)
        {
            if (player.CurrentSquare > 25)
            {
                player.CurrentSquare = 25;
            }

            string currentSquare = board[player.CurrentSquare];

            switch (currentSquare)
            {
                case "normal":
                    break;
                case "snakes":
                    var snakeSquare = player.CurrentSquare - 9;
                    if (snakeSquare < 1)
                    {
                        Console.WriteLine("You are in a snake location. Drop 1 on vertical!");

                        player.CurrentSquare = 1;
                    }
                    break;
                case "ladders":
                    var ladderSquare = player.CurrentSquare + 9;
                    if (ladderSquare > 25)
                    {
                        Console.WriteLine("You are in a ladders location. Move to the ladder");

                        player.CurrentSquare = 25;
                    }
                    break;
                case "cobra":
                    Console.WriteLine("You are in a Cobra location. Go back to the beginning!");
                    player.CurrentSquare = 1;
                    break;
                case "boost":
                    Console.WriteLine("You are in a boost location. Advance 2 squares!");
                    player.CurrentSquare += 2;
                    break;
                case "u-turn":
                    Console.WriteLine("You are in a u-turn location. Go back 2 squares!");
                    player.CurrentSquare -= 2;
                    break;
                case "extra dice":
                    if (!player.HasExtraDice)
                    {
                        player.HasExtraDice = true;
                    }
                    break;
                case "cheat dice":
                    if (!player.HasCheatDice)
                    {
                        player.HasCheatDice = true;
                    }
                    break;
            }
            return player;
        }
       
    }
}

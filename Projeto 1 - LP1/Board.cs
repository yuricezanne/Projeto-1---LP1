namespace Projeto_1___LP1
{
    /// <summary>
    /// Class board
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Create the game board
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<int, string> BoardGenerator()
        {
            Random rnd = new Random();
            List<string> myList = new List<string> { "normal", "snakes", "snakes", "ladders", "ladders", "cobra", "boost", "u-turn", "extra dice", "cheat dice" };
            //Shuffles previously created list
            List<string> shuffledList = myList.OrderBy(i => Guid.NewGuid()).ToList(); 

            //Add first and last entries of the board
            SortedDictionary<int, string> board = new SortedDictionary<int, string>();
            board.Add(1, "normal");
            board.Add(25, "normal");

            int id = 1;

            //Add random entries to the board
            foreach (var item in shuffledList)
            {
                id++;
                board.Add(id, item);
            }

            for (int i = 12; i < 25; i++)
            {
                var randomEntry = rnd.Next(myList.Count);

                if (board.Values.Where(a => a.Equals("snakes")).Count() >= 4
                    && myList[randomEntry].Equals("snakes"))
                {
                    i--;
                    continue;
                }
                else if (board.Values.Where(a => a.Equals("ladders")).Count() >= 4
                   && myList[randomEntry].Equals("ladders"))
                {
                    i--;
                    continue;
                }
                else if (board.Values.Where(a => a.Equals("cobra")).Count() >= 1
                   && myList[randomEntry].Equals("cobra"))
                {
                    i--;
                    continue;
                }
                else if (board.Values.Where(a => a.Equals("boost")).Count() >= 2
                   && myList[randomEntry].Equals("boost"))
                {
                    i--;
                    continue;
                }
                else if (board.Values.Where(a => a.Equals("extra dice")).Count() >= 1
                   && myList[randomEntry].Equals("extra dice"))
                {
                    i--;
                    continue;
                }

                board.Add(i, myList[randomEntry]);
            }
            return board;
        }
    }
}

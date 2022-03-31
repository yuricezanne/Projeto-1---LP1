namespace Projeto_1___LP1
{
    public class Board
    {
        public SortedDictionary<int, string> BoardGenerator()
        {
            Random rnd = new Random();
            List<string> myList = new List<string> { "normal", "snakes", "snakes", "ladders", "ladders", "cobra", "boost", "u-turn", "extra dice", "cheat dice" };
            List<string> shuffledList = myList.OrderBy(i => Guid.NewGuid()).ToList(); //Ordena aleatoriamente os conteudos da lista de cima

            SortedDictionary<int, string> board = new SortedDictionary<int, string>();
            board.Add(1, "normal");
            board.Add(25, "normal");

            for (int i = 2; i < myList.Count; i++)
            {
                board.Add(i, shuffledList[i]);
            }

            for (int i = 13; i < 25; i++)
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

            var lines = board.Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
            Console.WriteLine(string.Join(Environment.NewLine, lines));
            Console.WriteLine(board.Values.Where(a => a.Equals("snakes")).Count());

            return board;
        }
    }
}

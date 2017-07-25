using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameTW
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cellList = "E,E,J,H,E,T,J,T,E,E,H,J,T,H,E,E,J,H,E,T,J,T,E,E,H,J,T,H,J,E,E,J,H,E,T,J,T,E,E,H,J,T,E,H,E".Split(',').ToArray();
            int numberOfPlayers = 3;
            int initialMoney = 1000;
            BoardGame bGame = new BoardGame(cellList,numberOfPlayers,initialMoney);
            int[] diceOutputs = { 4, 4, 4, 6, 7, 8, 5, 11, 10, 12, 2, 3, 5, 6, 7, 8, 5, 11, 10, 12, 2, 3, 5, 6, 7, 8, 5, 11, 10, 12 };           
            for(int i= 0;i < diceOutputs.Length;i++)
            {
                var playerId = i % numberOfPlayers;
                bGame.MovePlayer(playerId, diceOutputs[i]);
            }
            bGame.ShowResult();
            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameTW
{
    public class BoardGame
    {
        public List<Cell> Cells { get; set; }
        public List<Player> Players { get; set; }
        public BoardGame(string[] cellList, int totalNumberOfPlayers, int initialMoney)
        {
            initializeCells(cellList);
            initializePlayers(totalNumberOfPlayers, initialMoney);
            initializeGame();
        }

        private void initializeCells(string[] cellList)
        {
            Cells = new List<Cell>();
            for (int i = 0; i < cellList.Length; i++)
            {
                ICellType cType = null;
                switch(cellList[i])
                {
                    case "E":
                        cType = new EmptyCellType();
                        break;
                    case "J":
                        cType = new JailCellType();
                        break;
                    case "T":
                        cType = new TreasureCellType();
                        break;
                    case "H":
                        cType = new HotelCellType();
                        break;
                    default:
                        throw new Exception("Unknown Cell Type");                       
                }
                Cell c = new Cell(i, cType);
                Cells.Add(c);
            }
        }

        private void initializePlayers(int totalNumberOfPlayers, int initialMoney)
        {
            Players = new List<Player>();
            for (int i = 0; i < totalNumberOfPlayers; i++)
            {
                Player player = new Player(i, initialMoney);
                Players.Add(player);
            }
        }

        private void initializeGame()
        {
            if (Cells.Count > 0)
            {
                foreach (var player in Players)
                {
                    player.CurrentCell = Cells[0];
                }
            }
            else
                throw new Exception("No sufficent cells");
        }

        public void MovePlayer(int playerId, int diceResult)
        {
            Player player = this.Players.Single(item => item.PlayerId == playerId);
            int currentCellIndex = player.CurrentCell.CellId;
            int newIndex = currentCellIndex + diceResult;
            if(newIndex >= Cells.Count)
            {
                newIndex = newIndex - Cells.Count;
            }
            player.CurrentCell = Cells[newIndex];
            player.CurrentCell.CellType.CellTypeBehavior(player);
            HotelCellType hType = player.CurrentCell.CellType as HotelCellType;
            if(hType != null && hType.IsOpted && hType.OptedBy == player)
            {
                player.AssetsCell.Add(player.CurrentCell);
            }
        }

        public void ShowResult()
        {

            foreach(var player in Players.OrderByDescending(item=> item.TotalWorth))
            {
                Console.WriteLine("Player " + player.PlayerId + " has total worth " + player.TotalWorth);
            }
        }
    }
}

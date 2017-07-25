using System.Collections.Generic;

namespace BoardGameTW
{
    public class Player
    {
        public Player(int playerToken, int assetMoney)
        {
            this.PlayerId = playerToken;
            this.AssetMoney = assetMoney;
            this.AssetsCell = new List<Cell>();
        }
        internal int PlayerId { get; set; }
        internal int AssetMoney { get; set; }
        internal Cell CurrentCell { get; set; }
        internal List<Cell> AssetsCell { get; set; }
        internal int TotalWorth
        {
            get
            {
                int toalWorth = 0;
                foreach(var cell in AssetsCell)
                {
                    toalWorth += cell.CellType.CellWorth;
                }
                toalWorth += AssetMoney;
                return toalWorth;
            }
        }
    }
}

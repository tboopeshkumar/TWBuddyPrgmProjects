using System;

namespace BoardGameTW
{
    public class TreasureCellType : ICellType
    {
        public int CellWorth => 0;

        public void CellTypeBehavior(Player player)
        {
            if (player != null)
            {
                player.AssetMoney += 200;
            }
        }
    }
}

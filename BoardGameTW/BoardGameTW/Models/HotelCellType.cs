using System;

namespace BoardGameTW
{
    public class HotelCellType : ICellType
    {
        public int CellWorth => 200;

        internal bool IsOpted { get; private set; }
        internal Player OptedBy { get; private set; }
        public void CellTypeBehavior(Player player)
        {
            if (player != null)
            {
                if (player == OptedBy) return;
                if (IsOpted)
                {
                    player.AssetMoney -= 50;
                }
                else
                {
                    player.AssetMoney -= 200;
                    OptedBy = player;                    
                    IsOpted = true;
                }
            }
        }
    }
}

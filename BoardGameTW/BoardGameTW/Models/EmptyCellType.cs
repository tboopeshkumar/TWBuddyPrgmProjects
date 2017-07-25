using System;

namespace BoardGameTW
{
    public class EmptyCellType : ICellType
    {
        public int CellWorth => 0;

        public void CellTypeBehavior(Player player)
        {
            
        }
    }
}

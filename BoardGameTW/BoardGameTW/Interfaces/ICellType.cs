namespace BoardGameTW
{
    public interface ICellType
    {
        int CellWorth { get; }
        void CellTypeBehavior(Player player);
    }
}

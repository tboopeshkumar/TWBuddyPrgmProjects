namespace BoardGameTW
{
    public class Cell
    {
        public Cell(int id,ICellType cellType)
        {
            this.CellId = id;
            this.CellType = cellType;
        }

        private int cellId;

        public int CellId
        {
            get { return cellId; }
            set { cellId = value; }
        }

        public ICellType CellType { get; set; }

    }
}

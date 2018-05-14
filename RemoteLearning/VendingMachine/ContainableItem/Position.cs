namespace VendingMachine.ContainableItem
{
    public class Position
    {
        public Position(int position, int rowSize)
        {
            this.Column = position % rowSize == 0 ? rowSize : position % rowSize;
            if (position % rowSize == 0)
            {
                this.Row = position / rowSize;
            }
            else
            {
                this.Row = (position / rowSize) + 1;
            }
        }

        public Position(string input)
        {
            int.TryParse(input[0].ToString(), out int row);
            int.TryParse(input[1].ToString(), out int col);
            this.Row = row;
            this.Column = col;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public string GetPosition()
        {
            return this.Row + this.Column.ToString();
        }
    }
}

namespace VendingMachine.ContainableItem
{
    using System;
    using System.Collections.Generic;

    using VendingMachine.View;

    /// <summary>
    /// An abstraction for an NxN matrix that resembles a vending machine.
    /// </summary>
    public class VendingMachineMatrix
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<int, int> matrix;
        private readonly int size;

        public VendingMachineMatrix(int size)
        {
            this.size = size;
            this.matrix = new Dictionary<int, int>();

            // Default, every position is unoccupied.
            for (int position = 1; position <= size * size; position++)
            {
                this.matrix.Add(position, 0);
            }
        }

        /// <summary>
        /// Calculates an available position for an item size
        /// </summary>
        /// <param name="itemSize">The amount of columns this item occupies</param>
        /// <returns>A valid position or null if no position can be found</returns>
        public Position GetNextPosition(int itemSize, int itemId)
        {
            if (itemSize > this.size)
            {
                throw new Exception("The specified size for the product is incorrect !");
            }

            foreach (KeyValuePair<int, int> position in this.matrix)
            {
                if (position.Value > 0)
                {
                    // if it is occupied, continue
                    continue;
                }

                // find the row maximum value based on position and max column size
                int rowMax = ((position.Key / this.size) + 1) * this.size;
                if (position.Key + itemSize - 1 > rowMax)
                {
                    // if is bigger, find another row
                    continue;
                }

                // see if all needed positions are free
                bool nextPositionsAreFree = true;
                for (int startPosition = position.Key + 1; startPosition < position.Key + itemSize; startPosition++)
                {
                    if (this.matrix[startPosition] > 0)
                    {
                        nextPositionsAreFree = false;
                        break;
                    }
                }

                if (!nextPositionsAreFree)
                {
                    // not all necessary positions are free
                    continue;
                }

                // at this point we have a position found, occupy all slots in the matrix for the item.
                for (int indexPosition = position.Key; indexPosition < position.Key + itemSize; indexPosition++)
                {
                    this.matrix[indexPosition] = itemId;
                }

                // create new position object and return it
                Position matrixPosition = new Position(position.Key, this.size);

                return matrixPosition;
            }

            return null;
        }

        public void Print(IView view)
        {
            foreach (KeyValuePair<int, int> position in this.matrix)
            {
                view.Print(position.Value.ToString());
                if (position.Key % this.size == 0)
                {
                    view.PrintOneLine();
                }
                else
                {
                    view.Print("\t");
                }
            }
        }

        public int GetItemIdAtPosition(Position position)
        {
            int posInMatrix = ((position.Row - 1) * this.size) + position.Column;
            return this.matrix[posInMatrix];
        }

        public void ClearPositionsInMatrix(int objId)
        {
            var listofPositions = new List<int>();
            foreach (KeyValuePair<int, int> position in this.matrix)
            {
                if (position.Value == objId)
                {
                    listofPositions.Add(position.Key);
                }
            }

            foreach (int position in listofPositions)
            {
                this.matrix[position] = 0;
            }
        }
    }
}

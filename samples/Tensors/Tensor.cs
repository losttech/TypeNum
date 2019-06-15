namespace Tensors
{
    using System;
    using TypeNum;

    class Tensor<NCols, NRows>
        where NCols : unmanaged, Numeral
        where NRows : unmanaged, Numeral
    {
    public static int ColumnCount { get; } = default(NCols).Num;
    public static int RowCount { get; } = default(NRows).Num;

    internal readonly float[,] values = new float[ColumnCount, RowCount];

        public void Mul<NOtherRows>(Tensor<NRows, NOtherRows> by, MutableTensor<NCols, NOtherRows> result)
            where NOtherRows : unmanaged, Numeral
        {
            if (by == null) throw new ArgumentNullException(nameof(by));
            if (result == null) throw new ArgumentNullException(nameof(result));

            for (int resultCol = 0; resultCol < ColumnCount; resultCol++)
                for (int resultRow = 0; resultRow < MutableTensor<NCols, NOtherRows>.RowCount; resultRow++)
                    for (int row = 0; row < RowCount; row++)
                        result.values[resultCol, resultRow] += this.values[resultCol, row] * by.values[row, resultRow];
        }
    }
}

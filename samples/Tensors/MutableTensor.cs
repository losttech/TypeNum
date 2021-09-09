namespace Tensors
{
    using TypeNum;

    class MutableTensor<NCols, NRows>: Tensor<NCols, NRows>
        where NCols : unmanaged, INumeral
        where NRows : unmanaged, INumeral
    {
        public void Add(MutableTensor<NCols, NRows> tensor)
        {
            for (int col = 0; col < ColumnCount; col++)
                for (int row = 0; row < RowCount; row++)
                    this.values[col, row] += tensor.values[col, row];
        }

        public float this[int col, int row] {
            get => this.values[col, row];
            set => this.values[col, row] = value;
        }
    }
}

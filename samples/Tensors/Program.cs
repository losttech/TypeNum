namespace Tensors
{
    using TypeNum;
    class Program
    {
        static void Main(string[] args)
        {
            var diag1 = new MutableTensor<N2, N2> {
                [0, 0] = 1,
                [1, 1] = 1,
            };
            var all1 = new MutableTensor<N2, N2> {
                [0,0] = 1,
                [0,1] = 1,
                [1,0] = 1,
                [1,1] = 1,
            };
            var sum = new MutableTensor<N2, N2>();
            sum.Add(diag1);
            sum.Add(all1);

            var mul = new MutableTensor<N2, N2>();
            sum.Mul(all1, result: mul);
            // OK

            var mulByFail = new MutableTensor<N2, Sum<N1, N2>>();
            // sum.Mul(mulByFail, result: mul);
            // error CS0411: The type arguments for method 
            // 'Tensor<N2, N2>.Mul<NOtherRows>(Tensor<N2, NOtherRows>, MutableTensor<N2, NOtherRows>)'
            // cannot be inferred from the usage. Try specifying the type arguments explicitly.
        }
    }
}

namespace TypeNum {
    public interface Numeral {
        int Num { get; }
    }

    public interface Numeral<T>
    {
        int Num { get; }
    }
}

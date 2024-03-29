# TypeNum
Type-level integers for C#

[![NuGet](https://img.shields.io/nuget/v/TypeNum.svg)](https://www.nuget.org/packages/TypeNum/)
[![Build Status](https://losttech.visualstudio.com/TypeNum/_apis/build/status/losttech.TypeNum?branchName=master)](https://losttech.visualstudio.com/TypeNum/_build/latest?definitionId=29&branchName=master)

# Example
```csharp
class Tensor<NCols, NRows>
    where NCols : struct, INumeral
    where NRows : struct, INumeral
{
    public static int ColumnCount { get; } = NCols.Num;
    public static int RowCount { get; } = NRows.Num;

    internal readonly float[,] values = new float[ColumnCount, RowCount];

    public void Add(Tensor<NCols, NRows> tensor)
    {
        for (int col = 0; col < ColumnCount; col++)
            for (int row = 0; row < RowCount; row++)
                this.values[col, row] += tensor.values[col, row];
    }
}
```

## Shorthands
For non-power-of-two numerals it is useful to add shorthands.
Unfortunately declaring one is rather verbose in C#:
```csharp
using N39 = TypeNum.Sum<TypeNum.Sum<TypeNum.Sum<
			TypeNum.N32,
			TypeNum.N4>,
			TypeNum.N2>,
			TypeNum.N1>;

...

Debug.Assert(N39.Num == 39);
var thirtyNine = new Tensor<N39, N39>();
```

# Consistency
Technically, `Sum<N1, N0>` and `Sum<N0, N1>` represent the same numeral.
However, there is no way to express it in C# type system. To alleviate that
TypeNum tries to enforce one and only way to represent specific number.

To take advantage of that enforcement, avoid declaring your own implementations
of the `Numeral` interface, and stick to `N*`, `Twice<T>`, and `Sum<T1, T2>`
classes. They enforce several rules at run time (and, potentially, [compile
time in the future](https://github.com/losttech/TypeNum/issues/1)):

## Twice
In `Twice<T>` `T` can only be one of the following:

* the largest predefined type numeral (currently `N4096`)
* another `Twice<*>`

So `Twice<T>` can only be used to represent very large numerals

## Sum
The following rules are enforced on parameters `T1` and `T2` of `Sum<T1, T2>`:

* `T1.Num` must be strictly greater (>) than `T2.Num` (swap them, if yours are opposite)
* `T2` can never be another `Sum<*,*>`. Replace any `Sum<A, Sum<B, C>>` with
`Sum<Sum<A, B>, C>`
* if `T1` itself is a `Sum<A, B>`, then in `Sum<Sum<A, B>, C>` `A` and `B` must
each be strictly greater (>) than `C`

Following these rules will ensure, that equal type numerals are always
represented by identical types.

# F# Example
In F# (unlike C#) operators can introduce new generic type parameters,
which enables defining statically-typed matrix multiplication as an operator:

```fsharp
type Matrix<'rows, 'cols>() =
    static member ( * )(left: Matrix<'rows, 'cols>, right: Matrix<'cols, 'ncols>) =
        Matrix<'rows, 'ncols>()

module private Test =
    open TypeNum

    type N3 = Sum<N2, N1>
    type N7 = Sum<N4, N3>
    type N5 = Sum<N4, N1>

    let a = Matrix<N7, N5>()
    let b = Matrix<N5, N3>()
    let product = a * b

```
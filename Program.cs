
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;

public class Matrix<T> where T: struct,
    IEquatable<T>,
    IFormattable,
    IConvertible,
    IComparable,
    IComparable<T>
{
    T[,] _matrix;
    public T this[int row, int col] { get => _matrix[row, col]; set => _matrix[row, col] = value; }
    public bool Empty { get =>  _matrix.Length == 0; }
    public Matrix(int row, int col)
    {
        _matrix = new T[row, col];
    }
    public Matrix(int n) : this(n, n) { }
    public Matrix() : this(3, 3) { }
    public static Matrix<T>? Add(Matrix<T> first, Matrix<T> second)
    {
        if (!first.Equals(second) || first.GetType() != second.GetType()) return null;
        Matrix<T> result = new(first._matrix.GetLength(0), first._matrix.GetLength(1));
        for(int row = 0; row < first._matrix.GetLength(0); row++)
        {
            for(int col = 0; col < first._matrix.GetLength(1); col++)
            {
                dynamic firstval = first[row, col];
                dynamic secondval = second[row, col];
                result[row,col] = firstval + secondval;
            }
        }
        return result;
    }
    public static Matrix<T>? operator+(Matrix<T> first, Matrix<T> second) => Add(first, second);
    public void Fill(T elem)
    {

        for (int row = 0; row < _matrix.GetLength(0); row++)
        {
            for(int col = 0; col < _matrix.GetLength(1); col++)
            {
                this[row,col] = elem;
            }
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_matrix.GetLength(0) + (dynamic)_matrix[0, 0], _matrix.GetLength(1) + ((dynamic)_matrix[0, 0]));
    }
    public override bool Equals(object? obj)
    {
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));
        if (obj is Matrix<T> matrix) 
        { 
            return _matrix.GetLength(0) == matrix._matrix.GetLength(0) && 
                _matrix.GetLength(1) == matrix._matrix.GetLength(1);
        }
        return false;
    }
    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        for (int row = 0; row < _matrix.GetLength(0); row++) 
        {
            stringBuilder.Append("| ");
            for(int col = 0; col < _matrix.GetLength(1); col++)
            {
                stringBuilder.Append($"{_matrix[row, col]}, ");
            }
            stringBuilder.Append("|\n");
        }
        return stringBuilder.ToString();
    }
}
public class @class
{
    public static void Main()
    {
        Matrix<int> matrix = new(10,10);
        matrix.Fill(10);
        Matrix<int> another_matrix = new(9, 10);
        another_matrix.Fill(20);
        Matrix<int> result = matrix + another_matrix ?? new Matrix<int>(0);
        Console.WriteLine(result);
    }
}

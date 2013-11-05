using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExercise
{
    public interface IDiagonalMatrix<T> : ISquareMatrix
    {
        T DefaultElement { get; }
    }
}

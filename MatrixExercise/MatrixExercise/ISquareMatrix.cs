﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExercise
{
    public interface ISquareMatrix<T> : ISquareMatrixBase
    {
        void SetElements(T[][] matrixArray);
    }
}

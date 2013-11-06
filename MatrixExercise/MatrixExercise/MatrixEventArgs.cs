using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExercise
{
    internal class MatrixEventArgs<T> : EventArgs
    {
        #region [Properties]

        public int I { get; private set; }
        public int J { get; private set; }
        public T Element { get; private set; }

        #endregion


        #region [Ctor's]

        public MatrixEventArgs(int i, int j, T element)
        {
            I = i;
            J = j;
            Element = element;
        }

        #endregion

    }
}

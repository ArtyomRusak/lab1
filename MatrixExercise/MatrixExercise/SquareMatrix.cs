using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExercise
{
    public class SquareMatrix<T> : Matrix<T>, ISquareMatrix
    {
        #region [Constants]

        private const string WRONG_INDEX = "Index is less than zero or greater than size of matrix";

        #endregion


        #region [Private members]

        private readonly T[][] _data;

        #endregion


        #region [Ctor's]

        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("size");
            }

            SizeOfMatrix = size;

            _data = new T[SizeOfMatrix][];
            for (int i = 0; i < SizeOfMatrix; i++)
            {
                _data[i] = new T[SizeOfMatrix];
            }
        }

        #endregion


        #region Overrides of Matrix<T>

        public override void Add(int i, int j, T element)
        {
            CheckArguments(i, j);

            _data[i][j] = element;
        }

        public override void Edit(int i, int j, T element)
        {
            CheckArguments(i, j);

            _data[i][j] = element;
        }

        public override T GetElement(int i, int j)
        {
            CheckArguments(i, j);

            return _data[i][j];
        }

        public override void ShowMatrix()
        {
            // Show matrix. Here we can see a NullReferenceException(For example: obj.ToString()). Need to catch it.
        }

        public override T this[int i, int j]
        {
            get
            {
                return GetElement(i, j);
            }
            set
            {
                Add(i, j, value);
            }
        }

        #endregion
        

        #region [SquareMatrix members]

        private void CheckArguments(int i, int j)
        {
            if (i < 0 || i >= SizeOfMatrix)
            {
                throw new ArgumentException(WRONG_INDEX, "i");
            }
            if (j < 0 || j >= SizeOfMatrix)
            {
                throw new ArgumentException(WRONG_INDEX, "j");
            }
        }

        #endregion


        #region Implementation of ISquareMatrix

        public int SizeOfMatrix { get; private set; }

        #endregion
    }
}

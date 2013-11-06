using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExercise
{
    public class DiagonalMatrix<T> : Matrix<T>, IDiagonalMatrix<T>
    {
        #region [Constants]

        private const string WRONG_INDEX = "Index is less than zero or greater than size of matrix";
        private const string WRONG_INDEX_SPECIFIED = "This is diagonal matrix. Index to add or edit must not be equals.";
        private const string WRONG_SIZE = "Size must be greater than zero";
        private const string WRONG_SIZE_ARRAY = "Wrong size of array";

        #endregion


        #region [Private members]

        private T[][] _data;

        #endregion


        #region [Ctor's]

        public DiagonalMatrix(int size, T defaultElement)
        {
            if (size <= 0)
            {
                throw new ArgumentException(WRONG_SIZE, "size");
            }

            SizeOfMatrix = size;
            DefaultElement = defaultElement;
            handler += OnElementChanged;

            _data = new T[SizeOfMatrix][];
            for (int i = 0; i < SizeOfMatrix; i++)
            {
                _data[i] = new T[SizeOfMatrix];
            }

            for (int i = 0; i < SizeOfMatrix; i++)
            {
                for (int j = 0; j < SizeOfMatrix; j++)
                {
                    if (i != j)
                    {
                        _data[i][j] = DefaultElement;
                    }
                }
            }
        }

        #endregion


        #region Overrides of Matrix<T>

        public override event EventHandler handler;

        public override void Edit(int i, int j, T element)
        {
            CheckArguments(i, j);
            CheckArgumentSpecific(i, j);

            _data[i][j] = element;

            MatrixEventArgs<T> e = new MatrixEventArgs<T>(i, j, element);
            if (handler != null)
            {
                handler(this, e);
            }
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
                CheckArguments(i, j);
                CheckArgumentSpecific(i, j);

                _data[i][j] = value;
            }
        }

        #endregion


        #region Implementation of IDiagonalMatrix<T>

        public T DefaultElement { get; private set; }

        public void SetDefaultElement(T defaultElement)
        {
            DefaultElement = defaultElement;

            for (int i = 0; i < SizeOfMatrix; i++)
            {
                for (int j = 0; j < SizeOfMatrix; j++)
                {
                    if (i != j)
                    {
                        _data[i][j] = DefaultElement;
                    }
                }
            }
        }

        public void SetElements(T[] diagonalArray)
        {
            if (diagonalArray.Length != SizeOfMatrix)
            {
                throw new ArgumentException(WRONG_SIZE_ARRAY, "diagonalArray");
            }

            for (int i = 0; i < SizeOfMatrix; i++)
            {
                _data[i][i] = diagonalArray[i];
            }
        }

        #endregion


        #region [DiagonalMatrix members]

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

        private void CheckArgumentSpecific(int i, int j)
        {
            if (i != j)
            {
                throw new ArgumentException(WRONG_INDEX_SPECIFIED);
            }
        }

        private void OnElementChanged(object sender, EventArgs e)
        {
            // Need to implement.
        }

        public void RemoveDefaultEventImplementation()
        {
            handler -= OnElementChanged;
        }

        #endregion


        #region Implementation of ISquareMatrixBase

        public int SizeOfMatrix { get; private set; }

        #endregion
    }
}

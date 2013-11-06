﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExercise
{
    public class SquareMatrix<T> : Matrix<T>, ISquareMatrix<T>
    {
        #region [Constants]

        private const string WRONG_INDEX = "Index is less than zero or greater than size of matrix";
        private const string WRONG_SIZE = "Size must be greater than zero";
        private const string WRONG_SIZE_ARRAY = "Wrong size of array";
        private const int DEFAULT_INDEX = 0;

        #endregion


        #region [Private members]

        private T[][] _data;

        #endregion


        #region [Ctor's]

        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException(WRONG_SIZE, "size");
            }

            SizeOfMatrix = size;
            handler += OnElementChanged;

            _data = new T[SizeOfMatrix][];
            for (int i = 0; i < SizeOfMatrix; i++)
            {
                _data[i] = new T[SizeOfMatrix];
            }
        }

        #endregion


        #region Overrides of Matrix<T>

        public override event EventHandler handler;

        public override void Edit(int i, int j, T element)
        {
            CheckArguments(i, j);

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

                _data[i][j] = value;
            }
        }

        #endregion


        #region Implementation of ISquareMatrix

        public int SizeOfMatrix { get; private set; }

        public void SetElements(T[][] matrixArray)
        {
            if ((matrixArray.Length != matrixArray[DEFAULT_INDEX].Length) || matrixArray.Length != SizeOfMatrix)
            {
                throw new ArgumentException(WRONG_SIZE_ARRAY, "matrixArray");
            }

            _data = matrixArray;
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

        private void OnElementChanged(object sender, EventArgs e)
        {
            // Need to implement.
        }

        public void RemoveDefaultEventImplementation()
        {
            handler -= OnElementChanged;
        }

        #endregion
    }
}

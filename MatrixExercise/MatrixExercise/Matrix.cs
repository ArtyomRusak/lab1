using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExercise
{
    public abstract class Matrix<T>
    {
        public abstract event EventHandler handler;

        public abstract void Edit(int i, int j, T element);
        public abstract T GetElement(int i, int j);
        public abstract void ShowMatrix();
        public abstract T this[int i, int j] { get; set; }
    }
}

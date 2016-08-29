using System;
using System.Text;

namespace Matrix
{
    public class Matrix
    {
        private readonly int[,] data;


        public Matrix(int[,] data)
        {
            this.data = new int[data.GetLength(0), data.GetLength(1)];
            this.data = (int[,]) data.Clone();
        }

        public Matrix()
        {
            data = new[,]
            {
                {1, 0, 1},
                {0, 1, 0},
                {1, 0, 1}
            };
        }

        public int SumDiag
        {
            get
            {
                int result = 0;
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (i == j || i+j == data.GetLength(0) - 1)
                            result += data[i, j];
                    }
                }
                return result;
            }
            private set { }
        }

        public int this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public int GetLength()
        {
            return data.GetLength(0)*data.GetLength(1);
        }

        public int GetLength(int dimension)
        {
            return data.GetLength(dimension);
        }

        private bool IsCoumnPositive(int column)
        {
            if (column >= 0 && column < data.GetLength(1))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    if (data[i,column] < 0)
                    return false;
                }
                return true;
            }
            else
            {
                throw new ArgumentException("Wrong column");
            }
        }

        public int SumPositive()
        {
            int result = 0;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (IsCoumnPositive(i))
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        result += data[j, i];
                    }
                }
            }
            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < data.GetLength(0); i++)
            {
                for (var j = 0; j < data.GetLength(1); j++)
                {
                    sb.Append(data[i, j]);
                    sb.Append("\t");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Figures:IEnumerable //,IEnumerator
    {
        
        IFigure[] figures;
        //int currentNumber;// номер текущего элемента, возвращаемого нумератором
        public Figures(params IFigure[] figs)
        {
           
            figures=(IFigure[])figs.Clone();
        }
        private static int Comparer(IFigure f1,IFigure f2)
        {
            return f1.Square.CompareTo(f2.Square);
        }
        //индексатор
        public IFigure this[int i]
        {
            get { return figures[i]; }
        }
        public int Count
        {
            get { return figures.Length; }
        }
        //сортировка по площади
        public void Sort()
        {

            Array.Sort(figures);
        }
        //сортировка по типу фигур
        public void Sort(IComparer comparer)
        {
            Array.Sort(figures,comparer);
        }


        public IEnumerator GetEnumerator()
        {
            //Reset();
            //return this;

            for (int i = 0; i < Count; i++)
                yield return figures[i];

        }
         public IEnumerable ByTwo()
        {
            for (int i = 0; i < Count; i+=2)
                yield return figures[i];
        }

         public IEnumerable Back()
         {
             for (int i = Count-1; i >=0; i --)
                 yield return figures[i];
         }
        //public object Current
        //{
        //    get { return figures[currentNumber]; }
        //}

        //public bool MoveNext()
        //{
        //    currentNumber+=1;
        //    return (currentNumber < Count);
        //}

        //public void Reset()
        //{
        //    currentNumber=-1;
        //}
    }
}

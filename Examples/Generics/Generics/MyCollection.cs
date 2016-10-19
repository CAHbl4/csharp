using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class MyCollection<T>:IEnumerable<T> where T : IComparable<T>, new()
    {
        T[] array;
        public MyCollection(params T[] arr)
        {
            array = new T[arr.Length];
            arr.CopyTo(array, 0);

        }
        public int Count()
        {
            return array.Length;
        }
        public void Add(T entity)
        {
            Array.Resize<T>(ref array, array.Length + 1);
            array[array.Length - 1] = entity;
        }
        public T this[int i]//индексатор
        {
            get
            {
                return array[i];
            }
        }
        public void Sort()
        {
            Array.Sort(array);
        }
        public T CreateEntity()
        {
            return new T();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count(); i++)
                yield return array[i]; 
           
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
           for(int i=0;i<Count();i++)
               yield  return  array[i];
        }
    }
}

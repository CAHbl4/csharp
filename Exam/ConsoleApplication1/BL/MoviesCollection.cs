using System;
using System.Collections;
using System.Collections.Generic;

namespace BL
{
    public class MoviesCollection<T>: IEnumerable<T>
        where T : AbstractMovie
    {
        readonly List<T> collection = new List<T>();

        public T this[int i]
        {
            get
            {
                if ((i < 0) || (i > collection.Count - 1))
                    throw new ArgumentOutOfRangeException("Index out of range");
                return collection[i];
            }
            set
            {
                if ((i < 0) || (i > collection.Count - 1))
                    throw new ArgumentOutOfRangeException("Index out of range");
                collection[i] = value;
            }
        }

        public void Add(T movie)
        {
            collection.Add(movie);
        }

        public T[] Find(Predicate<T> predicate)
        {
            List<AbstractMovie> result = new List<AbstractMovie>();
            foreach (T movie in collection)
            {
                if (predicate(movie)) result.Add(movie);
            }
            return (T[]) result.ToArray();
        }

        public void Clear()
        {
            collection.Clear();
        }

        public int Count => collection.Count;
        

        public T[] ToArray()
        {
            return collection.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
using System;

namespace BugFix
{
    public class DynamicArray<T>
    {
        private T[] baseArray;
        public int Count { get; private set; }

        public DynamicArray( uint size)
        {
            baseArray = new T[size];
            Count = 0;
        }

        public void Add(int index, T item)
        {
            
            if (index >= baseArray.Length)
            {
                Resize(index);
            }
            for (int i = Count - 1; i >= index; i--)
            {
                baseArray[i + 1] = baseArray[i];
            }

            baseArray[index] = item;
            Count++;
        }

        private void Resize(int sz)
        {
            int newSize = sz * 2;
            T[] temp = new T[newSize];
            Array.Copy(baseArray, temp, Count);
            baseArray = temp;
            Count = sz;
        }
        // Indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return baseArray[index];
            }
        }
    }
}

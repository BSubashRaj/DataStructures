using System;
using System.Text;

namespace DataStructures
{
    class Array<T>
    {
        private T[] _items;
        private int _count;
        public int Capacity;

        public Array(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Capacity = size;
            _items = new T[size];
        }

        public void Insert(T value)
        {
            if (IsFull())
            {
                IncreaseCapacity();
                _items = Copy(_items);
            }

            _items[_count++] = value;
        }

        public T RemoveAtIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException();
            }
            var removed = _items[index];
            for (var i = index; i < _count; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
            if (IsReducible())
            {
                DecreaseCapacity();
                _items = Copy(_items);
            }
            return removed;
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < _count; i++)
            {
                if (Equals(item, _items[i]))
                    return i;
            }
            return -1;
        }

        public int LastIndexOf(T item)
        {
            for (var i = _count - 1; i >= 0; i--)
            {
                if (Equals(item, _items[i]))
                    return i;
            }
            return -1;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public T Find(Predicate<T> condition)
        {
            for (var i = 0; i < _count; i++)
            {
                if (condition(_items[i]))
                    return _items[i];
            }
            return default(T);
        }

        public void ForEach(Action<T> action)
        {
            for (var i = 0; i < _count; i++)
            {
                action(_items[i]);
            }
        }

        public int Size()
        {
            return _count;
        }

        private void IncreaseCapacity()
        {
            Capacity = (int)Math.Round(Capacity * 1.5, MidpointRounding.AwayFromZero);
        }

        private void DecreaseCapacity()
        {
            Capacity = (int)Math.Round(_count * 1.5, MidpointRounding.AwayFromZero);
        }

        private T[] Copy(T[] array)
        {
            var newArray = new T[Capacity];
            for (var i = 0; i < _count; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }

        private bool IsFull()
        {
            return Capacity == _count;
        }

        private bool IsReducible()
        {
            return (int)Math.Round(_count * 1.5, MidpointRounding.AwayFromZero) < Capacity;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            for (var i = 0; i < _count - 1; i++)
            {
                stringBuilder.Append(_items[i] + ", ");
            }
            stringBuilder.Append(_items[_count - 1] + "]");
            return stringBuilder.ToString();
        }
    }
}

/// Sample Tests
//var array = new Array<int>(5);
//array.Insert(1);
//array.Insert(2);
//array.Insert(3);
//array.Insert(4);
//array.Insert(5);
//array.Insert(6);
//array.Insert(1);
//array.Insert(2);
//array.Insert(3);
//array.Insert(4);
//array.Insert(5);
//array.Insert(6);
//array.Insert(7);
//Console.WriteLine(array);
//Console.WriteLine(array.Size());
//Console.WriteLine(array.Capacity);
//array.RemoveAtIndex(6);
//array.RemoveAtIndex(11);
//Console.WriteLine(array);
//Console.WriteLine(array.Size());
//Console.WriteLine(array.Capacity);
//array.RemoveAtIndex(1);
//array.RemoveAtIndex(1);
//array.RemoveAtIndex(1);
//array.RemoveAtIndex(1);
//Console.WriteLine(array);
//Console.WriteLine(array.Size());
//Console.WriteLine(array.Capacity);
//Console.WriteLine(array.LastIndexOf(12));
//Console.WriteLine(array.Find(a => a == 5));
//array.ForEach((item) =>
//{
//    Console.WriteLine(item);
//});
//Console.WriteLine(array.Contains(7));
/// 

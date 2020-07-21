using System;

namespace DataStructures
{
    class Heap
    {
        private int[] _items = new int[20];
        private int Size = 0;

        public void Insert(int value)
        {
            if (IsFull())
                throw new InvalidOperationException();
            _items[Size++] = value;

            if (Size > 1)
                BubbleUp(Size - 1);
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var first = _items[0];
            _items[0] = _items[--Size];

            if (Size > 1)
                BubbleDown(0);

            return first;
        }

        private bool IsFull()
        {
            return Size == _items.Length;
        }

        private bool IsEmpty()
        {
            return Size == 0;
        }

        private void BubbleUp(int childIndex)
        {
            var parentIndex = ParentIndex(childIndex);
            if (parentIndex != -1)
            {
                CompareAndSwap(parentIndex, childIndex);
                BubbleUp(parentIndex);
            }
        }

        private void BubbleDown(int parentIndex)
        {
            var leftChildIndex = LeftChildIndex(parentIndex);
            var rightChildIndex = RightChildIndex(parentIndex);
            if (leftChildIndex == -1)
                return;
            else if (rightChildIndex == -1)
            {
                CompareAndSwap(parentIndex, leftChildIndex);
            }
            else
            {
                var maxIndex = MaxIndex(leftChildIndex, rightChildIndex);
                CompareAndSwap(parentIndex, maxIndex);
                BubbleDown(LeftChildIndex(parentIndex));
            }
        }

        private int LeftChildIndex(int parentIndex)
        {
            var leftChildIndex = parentIndex * 2 + 1;
            return leftChildIndex >= Size ? -1 : leftChildIndex;
        }

        private int RightChildIndex(int parentIndex)
        {
            var rightChildIndex = parentIndex * 2 + 2;
            return rightChildIndex >= Size ? -1 : rightChildIndex;
        }

        private int ParentIndex(int childIndex)
        {
            var parentIndex = (childIndex + 1) / 2 - 1;
            return parentIndex < 0 ? -1 : parentIndex;
        }

        private void CompareAndSwap(int parentIndex, int childIndex)
        {
            if (_items[parentIndex] < _items[childIndex])
            {
                Swap(parentIndex, childIndex);
            }
        }

        private void Swap(int first, int second)
        {
            var temp = _items[first];
            _items[first] = _items[second];
            _items[second] = temp;
        }

        private int MaxIndex(int leftIndex, int rightIndex)
        {
            return _items[leftIndex] > _items[rightIndex] ? leftIndex : rightIndex;
        }

        public void Heapify(int[] array)
        {
            var lastParent = array.Length / 2 - 1;
            for (var i = lastParent; i >= 0; i--)
            {
                Heapify(array, i);
            }
        }

        private void Heapify(int[] array, int index)
        {
            var largerIndex = index;

            var leftIndex = (index * 2) + 1;
            if (leftIndex < array.Length && array[leftIndex] > array[largerIndex])
                largerIndex = leftIndex;

            var rightIndex = (index * 2) + 2;
            if (rightIndex < array.Length && array[rightIndex] > array[largerIndex])
                largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            SWAP(array, index, largerIndex);
            Heapify(array, largerIndex);
        }

        private void SWAP(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        public int GetKthMaxValue(int k)
        {
            if (k <= 0 || k > Size)
                throw new InvalidOperationException();

            var heap = new Heap();
            foreach (var item in _items)
            {
                heap.Insert(item);
            }
            for (var i = 1; i < k; i++)
            {
                heap.Remove();
            }
            return heap.Max();
        }

        public int Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            return _items[0];
        }

        public void Display()
        {
            Console.Write("[");
            for (var i = 0; i < Size - 1; i++)
            {
                Console.Write($"{_items[i]}, ");
            }
            if (Size == 0)
                Console.WriteLine("]");
            else
                Console.WriteLine($"{_items[Size - 1]}]");
        }

        public void Display(int[] array)
        {
            var length = array.Length;
            Console.Write("[");
            for (var i = 0; i < length - 1; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            if (length == 0)
                Console.WriteLine("]");
            else
                Console.WriteLine($"{array[length - 1]}]");
        }
    }
}

//
//var heap = new Heap();
//heap.Insert(10);
//            heap.Insert(20);
//            heap.Insert(30);
//            heap.Insert(11);
//            heap.Display();
//            Console.WriteLine(heap.Remove());
//            heap.Display();
//            Console.WriteLine(heap.Remove());
//            heap.Display();
//            heap.Insert(20);
//            heap.Insert(30);
//            heap.Display();

//            Console.WriteLine(heap.GetKthMaxValue(1));
//            Console.WriteLine(heap.GetKthMaxValue(2));
//            Console.WriteLine(heap.GetKthMaxValue(5));
//            var arr = new int[] { 5, 3, 8, 4, 1, 2 };
//heap.Heapify(arr);
//            heap.Display(arr);

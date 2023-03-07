using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Lab2
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private T[] array;
        private const int initialSize = 8;

        public int Count { get; private set; }

        public int Capacity => array.Length;

        public bool IsEmpty => Count == 0;


        public MaxHeap(T[] initialArray = null)
        {
            array = new T[initialSize];

            if (initialArray == null)
            {
                return;
            }

            foreach (var item in initialArray)
            {
                Add(item);
            }

        }

        /// <summary>
        /// Returns the min item but does NOT remove it.
        /// Time complexity: O(1).
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            return array[0];
        }

        // TODO
        /// <summary>
        /// Adds given item to the heap.
        /// Time complexity: O(log(n)).
        /// </summary>
        public void Add(T item)
        {
            int nextEmptyIndex = Count;

            array[nextEmptyIndex] = item;

            TrickleUp(nextEmptyIndex - 1 );

            Count++;

            // resize if full
            if (Count == Capacity)
            {
                DoubleArrayCapacity();
            }
        }

        public T Extract()
        {
            return ExtractMax();
        }

        public T ExtractMax()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T max = array[0];

            // swap root (first) and last element
            Swap(0, Count - 1);

            // "remove" last
            Count--;

            // trickle down from root (first)
            TrickleDown(0);

            return max;
        }



        /// <summary>
        /// Returns true if the heap contains the given value; otherwise false.
        /// Time complexity: O( N ).
        /// </summary>
        public bool Contains(T value)
        {
            // linear search

            for (int i = 0; i < Count -1; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Updates the first element with the given value from the heap.
        /// Time complexity: O(log(n))
        /// </summary>
        public void Update(T oldValue, T newValue)
        {

            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }



            for (int i = 0; i < Count; i++)
            {

                if (array[i].CompareTo(oldValue) == 0)
                {

                    array[i] = newValue;


                    if (newValue.CompareTo(oldValue) < 0)
                    {
                        TrickleUp(i);
                        return;
                    }

                    else if (newValue.CompareTo(oldValue) > 0)
                    {
                        TrickleDown(i);
                        return;
                    }

                }

            }

            throw new Exception();
        }

        /// <summary>
        /// Removes the first element with the given value from the heap.
        /// Time complexity: O(logn(n))
        /// </summary>
        public void Remove(T value)
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(value))
                {
                    int index = i;

                    array[index] = array[Count - 1];
                    Count--;

                    if (index == 0 || array[index].CompareTo(array[Parent(index)]) < 0)
                    {
                        TrickleDown(index);
                        return;
                    }

                    TrickleUp(index);
                    return;

                }
            }

            throw new IndexOutOfRangeException();
        }


        // Time Complexity: O( log(n) )
        private void TrickleUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            while (index > 0)
            {
                int parentIndex = Parent(index);

                if (array[index].CompareTo(array[parentIndex]) <= 0 )
                {
                    return;
                }

                Swap(index, parentIndex);

                index = parentIndex;
            }
        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleDown(int index)
        {

            int childIndex = LeftChild(index);
            var value = array[index];

            while (childIndex < Count)
            {
                var maxValue = value;
                int maxIndex = -1;
                int i = 0;
                while (i < 2 && i + childIndex < Count)
                {
                    if (array[i + childIndex].CompareTo(maxValue) > 0)
                    {
                        maxValue = array[i + childIndex];
                        maxIndex = i + childIndex;
                    }
                    i++;
                } 

                if(maxValue.CompareTo(value) == 0)
                {
                    return;
                }
                    
                Swap(index, maxIndex);

                
                index = maxIndex;
                
                childIndex = LeftChild(index);
                
            }
            
        }


        /// <summary>
        /// Gives the position of a node's parent, the node's position in the heap.
        /// </summary>
        private static int Parent(int position)
        {
            return (position - 1) / 2;
        }


        /// <summary>
        /// Returns the position of a node's left child, given the node's position.
        /// </summary>
        private static int LeftChild(int position)
        {
            return 2 * position + 1;
        }


        /// <summary>
        /// Returns the position of a node's right child, given the node's position.
        /// </summary>
        private static int RightChild(int position)
        {
            return 2 * position + 2;
        }

        private void Swap(int index1, int index2)
        {
            var temp = array[index1];

            array[index1] = array[index2];
            array[index2] = temp;
        }

        private void DoubleArrayCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }


    }
}




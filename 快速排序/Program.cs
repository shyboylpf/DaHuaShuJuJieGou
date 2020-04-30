using System;

namespace 快速排序
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] source = new int[5] { 5, 4, 3, 2, 1 };
            //Random rd = new Random();
            //for (int i = 0; i < source.Length; i++)
            //{
            //    source[i] = rd.Next(1, 100);
            //}

            var result = QuickSort(source);
            Console.WriteLine(string.Join(',', result));
        }

        private static int[] QuickSort(int[] source)
        {
            _quickSort(ref source, 0, source.Length - 1);
            return source;
        }

        private static void _quickSort(ref int[] arr, int low, int high)
        {
            if (low < high)
            {
                // pi is partitioning index,  arr[p] is now
                // at right place
                int pi = _position(ref arr, low, high);

                _quickSort(ref arr, low, pi - 1);
                _quickSort(ref arr, pi + 1, high);
            }
        }

        private static int _position(ref int[] arr, int low, int high)
        {
            // index of smaller element
            int i = low - 1;
            // pivot
            int pivot = arr[high];

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i += 1;
                    if (i != j)
                    {
                        // exchage arr[i] , arr[j]
                        arr[i] ^= arr[j];
                        arr[j] ^= arr[i];
                        arr[i] ^= arr[j];
                    }
                }
            }
            if (i + 1 != high)
            {
                // exchange arr[i+1],  arr[high]
                arr[i + 1] ^= arr[high];
                arr[high] ^= arr[i + 1];
                arr[i + 1] ^= arr[high];
            }

            return i + 1;
        }
    }
}
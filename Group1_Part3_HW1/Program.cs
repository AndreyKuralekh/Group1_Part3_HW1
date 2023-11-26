using System.Diagnostics;

namespace Group1_Part3_HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[1000000];
            Console.WriteLine($"Array {arr.Length} generation started...");
            FillArray(arr);
            Console.WriteLine($"Array {arr.Length} generation finished...");

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------");

            Console.WriteLine($"O(n) Linear method started...");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var average = GetAverage(arr);

            stopwatch.Stop();
            Console.WriteLine($"            Average has been calculated: {average}");
            Console.WriteLine($"O(n) Linear method finished: duration is {stopwatch.ElapsedMilliseconds} milliseconds");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------");


            Console.WriteLine($"O(n) Linear-logarifmic method started...");
            stopwatch.Reset();
            stopwatch.Start();
            
            QuickSort(arr, 0, arr.Length - 1);

            stopwatch.Stop();
            Console.WriteLine($"O(n log n) Linear-logarifmic method finished...");
            Console.WriteLine($"O(n log n) Linear-logarifmic method finished: duration is {stopwatch.ElapsedMilliseconds} milliseconds");
            //PrintArray(arr);
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------");


            arr = new int[20000];
            Console.WriteLine($"Array {arr.Length} generation started...");
            FillArray(arr);
            Console.WriteLine($"Array {arr.Length} generation finished...");
            Console.WriteLine($"O(n^2) quadratic complexity method started..."); 
            stopwatch.Reset();
            stopwatch.Start();

            BubbleSort(arr);

            stopwatch.Stop();
            //PrintArray(arr);
            Console.WriteLine($"O(n^2) quadratic complexity method finished...");
            Console.WriteLine($"O(n^2) quadratic complexity method finished: duration is {stopwatch.ElapsedMilliseconds} milliseconds");

            Console.WriteLine("Finish!");
        }
        private static void FillArray(int[] arr)
        {
            var rnd = new Random();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = rnd.Next();
            }
        }
        //O(n) linear
        private static int GetAverage (int[] arr) 
        {
            Int64 sum = 0;
            foreach (var item in arr) 
            { 
                sum = sum + item;
            }
            return (int)(sum / arr.Length);
        }
        static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                // Разделение массива и получение индекса опорного элемента
                int pivotIndex = Partition(array, low, high);

                // Рекурсивная сортировка элементов до и после опорного элемента
                QuickSort(array, low, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, high);
            }
        }

        static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    // Обмен значениями
                    Swap(array, i, j);
                }
            }

            // Обмен опорного элемента с элементом, находящимся посередине (i + 1)
            Swap(array, i + 1, high);

            return i + 1;
        }

        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        static void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Обмен значениями, если текущий элемент больше следующего
                        Swap(array, j, j + 1);
                    }
                }
            }
        }
    }
}
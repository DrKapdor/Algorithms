namespace Algorithm
{
    public class Bootstrap
    {
        public static void Main(string[] args)
        {
            IndexedQueue<int> queue = new IndexedQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(2);
            queue.Enqueue(453);
            queue.Enqueue(23);
            queue.Enqueue(1);
            queue.Enqueue(1);
            queue.Enqueue(78);
            queue.Enqueue(34);
            TestBinaryInsertionSort(queue);
        }

        private static void TestBinaryInsertionSort(IndexedQueue<int> queue)
        {
            queue.Comparator = new IntComparator();
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            queue.BinaryInsertionSort();
            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Console.WriteLine("Результат:");
            while (queue.Count > 0) Console.WriteLine(queue.Dequeue());
            Console.WriteLine($"Время сортировки: {end - start} мс.");
        }

        //Создаём реализацию компаратора для целочисленных значений
        private class IntComparator : IComparator<int>
        {
            public int Compare(int a, int b)
            {
                return a - b;
            }
        }
    }
}
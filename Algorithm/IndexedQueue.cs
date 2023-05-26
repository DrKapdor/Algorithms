namespace Algorithm
{
    public class IndexedQueue<T> : Queue<T>
    {
        private IComparator<T>? comparator;

        public IComparator<T> Comparator
        {
            set { comparator = value; }
        }

        //Возвращает элемент в соответствии с его порядковым номером (индексом)
        public T Get(int index)
        {
            if (Count == 0) throw new Exception("IndexQueue is empty");
            if (index > Count - 1) throw new Exception($"Index \"{index}\" is out of range");
            if (index == 0) return Peek();
            for (int i = 0; i < index; i++) Enqueue(Dequeue());
            T target = Peek();
            for (int i = index; i < Count; i++) Enqueue(Dequeue());
            return target;
        }

        //Устанавливает элемент в очереди в соответствии с переданным порядковым номером (индексом)
        public void Set(int index, T element)
        {
            if (Count < 1) throw new Exception("IndexQueue is empty");
            if (index > Count - 1) throw new Exception($"Index \"{index}\" is out of range");
            for (int i = 0; i < index; i++) Enqueue(Dequeue());
            Dequeue();
            Enqueue(element);
            for (int i = index + 1; i < Count; i++) Enqueue(Dequeue());
        }

        //Сортировка методом бинарной вставки
        public void BinaryInsertionSort()
        {
            if (comparator == null) throw new Exception("Comparator is undefined");
            for (int i = 1; i < Count; i++)
            {
                T key = this[i];
                int left = 0;
                int right = i - 1;
                //Находим место для вставки элемента в отсортированную часть массива
                while (left <= right)
                {
                    int middle = (left + right) / 2;
                    if (comparator.Compare(this[middle], key) > 0) right = middle - 1;
                    else left = middle + 1; 
                }
                //Сдвигаем элементы, дабы освободить место для вставки
                for (int j = i - 1; j >= left; j--) this[j + 1] = this[j];
                this[left] = key;
            }
        }

        //Переопределяем индексатор
        public T this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }
    }
}

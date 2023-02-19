using System.Collections;

namespace CustomList
{
    public class CustomList<T> : IList<T>
    {
        private T[] _items = Array.Empty<T>();
        private int _size = 0;

        public int Capacity { get; private set; } = 0;
        public int Count => _size;
        public bool IsReadOnly => false;

        public CustomList(int capacity = 0)
        {
            if (capacity > 0)
            {
                Capacity = capacity;
                _items = new T[capacity];
            }
        }

        public T this[int index]
        {
            get
            {
                ThrowIfIndexOutOfRange(index);
                return _items[index];
            }
            set
            {
                ThrowIfIndexOutOfRange(index);
                _items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (_size == Capacity)
            {
                Resize();
            }
            _items[_size] = item;
            _size++;
        }

        public void Insert(int index, T item)
        {
            ThrowIfIndexOutOfRange(index);
            if (_size == Capacity)
            {
                Resize();
            }

            for (int i = _size; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
            _size++;
        }

        public void Clear()
        {
            _items = new T[Capacity];
            _size = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                T current = _items[i];
                if (current == null && item == null || current != null && current.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            for (int i = index; i < _size - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _size--;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }
            if (_size > array.Length - arrayIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(array), "Destination array was not long enough. Check the destination index, length, and the array's lower bounds.");
            }
            for (int i = 0; i < _size; i++)
            {
                array[arrayIndex++] = _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _items)
            {
                yield return item;
            }
        }

        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > _size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException($"Index out of range: {index}");
            }
        }

        private void Resize()
        {
            if (Capacity == 0)
            {
                Capacity = 4;
                _items = new T[Capacity];
            }
            else
            {
                T[] resized = new T[Capacity * 2];
                for (int i = 0; i < Capacity; i++)
                {
                    resized[i] = _items[i];
                }
                _items = resized;
                Capacity *= 2;
            }
        }
    }
}

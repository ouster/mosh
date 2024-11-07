namespace DnA1.MyArray;

public class ComparerT<T> where T : IComparable<T>
{
    public bool IsGreaterThan(T a, T b)
    {
        return a.CompareTo(b) > 0;
    }

    public bool IsLessThan(T a, T b)
    {
        return a.CompareTo(b) < 0;
    }

    public bool IsEqualTo(T a, T b)
    {
        return a.CompareTo(b) == 0;
    }
}

public class MyArray<T> where T : IComparable<T>, new()
{
    private int _capacity = 4;
    private T[] _items;
    private int _size;

    public MyArray()
    {
        _items = new T[_capacity];
        _size = 0;
    }

    public void Insert(T item)
    {
        if (_items.Length == _size)
        {
            Resize();
        }

        _items[_size++] = item;
    }

    public void RemoveAt(int index)
    {
        if (index >= _size || index < 0)
            throw new IndexOutOfRangeException();

        for (var i = index; i < _size; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[--_size] = default!;
    }

    public void InsertAt(T item, int index)
    {
        var newItems = new List<T>(_capacity + 1);

        if (index > _size || index < 0)
            throw new IndexOutOfRangeException();

        for (var i = 0; i < _size; i++)
        {
            if (i == index)
            {
                newItems.Add(item);
            }

            newItems.Add(_items[i]);
        }

        _items = newItems.ToArray();
        _size++;
    }

    public int IndexOf(T value)
    {
        for (int index = 0; index < _size; index++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[index], value))
            {
                return index;
            }
        }

        return -1;
    }

    public T Max()
    {
        var comparer = new ComparerT<T>();
        var max = _items[0];
        for (var index = 0; index < _size; index++)
        {
            if (comparer.IsGreaterThan(_items[index], max))
            {
                max = _items[index];
            }
        }

        return max;
    }

    public T[] Reverse()
    {
        var reverse = new List<T>(_capacity);
        for (var index = _size - 1; index >= 0; index--)
        {
            reverse.Add(_items[index]);
        }

        _items = reverse.ToArray();
        return reverse.ToArray();
    }

    public T[] Common(T[] array)
    {
        List<T> common = new List<T>(_capacity);
        common.AddRange(array.Where(comparable => _items.Contains(comparable)));

        return common.ToArray();
    }

    private void Resize()
    {
        var newCapacity = _capacity * 2;
        var newItems = new T[newCapacity];

        for (var i = 0; i < _capacity; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
        _capacity = newCapacity;
        Console.WriteLine($"New capacity {_capacity}");
    }

    private IEnumerable<T> GetEnumerator()
    {
        for (var i = 0; i < _size; i++)
        {
            yield return _items[i];
        }
    }

    public string Message()
    {
        return $"[ {string.Join(", ", GetEnumerator().ToArray())} ]";
    }

    public T[] ToArray()
    {
        return _items.ToArray();
    }
    
}
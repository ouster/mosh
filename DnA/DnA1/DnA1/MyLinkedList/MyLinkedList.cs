using System.Drawing;

namespace DnA1.MyLinkedList;

public class MyLinkedList<T>()
{
    public class MyNode(T value, MyNode? next = null)
    {
        public T Value { get; set; } = value;
        public MyNode? Next { get; set; }
    }

    private MyNode? _first = null;
    private MyNode? _last = null;
    private int _count = 0;


    public bool Contains(T value)
    {
        return IndexOf(value) != -1;
    }

    public void AddFirst(T value)
    {
        var newNode = new MyNode(value);
        if (IsEmpty())
        {
            _first = _last = newNode;
        }
        else
        {
            newNode.Next = _first;
            _first = newNode;
        }

        _count++;
    }

    public void DeleteFirst()
    {
        if (IsEmpty())
            throw new KeyNotFoundException();

        if (_first == _last)
        {
            _first = _last = null;
        }
        else
        {
            var second = _first?.Next;
            if (_first != null) _first.Next = null;
            _first = second;
        }

        _count--;
    }


    public void AddLast(T value)
    {
        var newNode = new MyNode(value);
        if (IsEmpty())
            _first = _last = newNode;
        else
        {
            if (_last != null) _last.Next = newNode;
            _last = newNode;
        }

        _count++;
    }

    private bool IsEmpty()
    {
        return _first == null;
    }

    public void DeleteLast()
    {
        if (IsEmpty())
            throw new KeyNotFoundException();

        if (_last == _first)
        {
            _last = _first = null;
        }
        else
        {
            var previous = GetPrevious(_last);
            _last = previous;
            if (_last != null) _last.Next = null;
        }

        _count--;
    }

    private MyNode? GetPrevious(MyNode? node)
    {
        var current = _first;
        while (current != null)
        {
            if (current.Next == node) return current;
            current = current.Next;
        }

        return null;
    }

    public int IndexOf(T value)
    {
        var node = _first;
        var index = 0;
        while (node != null)
        {
            if (node.Value != null && node.Value.Equals(value))
                return index;
            node = node.Next;
            index++;
        }

        return -1;
    }

    public int Size()
    {
        return _count;
    }

    public T[] ToArray()
    {
        var array = new T[_count];
        var node = _first;
        var index = 0;
        while (node != null)
        {
            array[index++] = node.Value;
            node = node.Next;
        }

        return array;
    }

    public void Reverse()
    {
        var previous = _first;
        var current = _first?.Next;
        while (current != null)
        {
            var next = current?.Next;
            current!.Next = previous;
            previous = current;
            current = next;
        }

        _last = _first;
        if (_last != null) _last.Next = null;
        _first = previous;
    }

    public T GetKthNode(int k)
    {
        if (IsEmpty())
        {
            throw new IndexOutOfRangeException();
        }
        var targetNode = _first;
        var offsetNode = _first;

        for (var i = 0; i < k - 1; i++)
        {
            offsetNode = offsetNode?.Next;
            if (offsetNode?.Next == null) 
                throw new IndexOutOfRangeException();
        }

        while (offsetNode != _last)
        {
            targetNode = targetNode?.Next;
            offsetNode = offsetNode?.Next;
        }

        return targetNode!.Value;
    }
}
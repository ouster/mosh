namespace DnA1.MyStack;

public class MyStack<T>
{
    private readonly List<T> _myStack = [];
    
    public MyStack()
    {
        
    }

    public int Length => _myStack.Count;

    public void Push(T value)
    {
        _myStack.Add(value);
    }

    public T Pop()
    {
        if (_myStack.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }
        var item = _myStack[^1];
        _myStack.RemoveAt(_myStack.Count - 1);
        return item;
    }
}
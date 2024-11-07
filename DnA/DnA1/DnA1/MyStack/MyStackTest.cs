using DnA1.MyStack;
using Xunit;

namespace DnA1;

public class MyStackTest : IDisposable
{
    public void Dispose()
    {
    }

    [Fact]
    public void myStack_can_be_constructed_and_popped()
    {
        var stack = new MyStack<int>();
        stack.Push(1);
        Assert.Equal(1, stack.Pop());
        Assert.Equal(0, stack.Length);
    }
}
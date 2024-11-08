using Xunit;

namespace DnA1.MyQueue;

public class MyQueueTest
{
    [Fact]
    public void TestReverse()
    {
        var myQueue = new MyQueue<int>();
        Queue<int> inQueue = new Queue<int>([1, 2, 3, 4]);
        Queue<int> outQueue = new Queue<int>([4, 3, 2, 1]);

        var actual = myQueue.reverse(inQueue);
        Assert.Equal(outQueue, actual);
    }
}
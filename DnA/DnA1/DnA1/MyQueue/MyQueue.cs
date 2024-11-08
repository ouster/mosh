using System.Collections;

namespace DnA1.MyQueue;

public class MyQueue<T>
{
    public Queue<T> reverse(Queue<T> queue)
    { 
        var reverse = new List<T>(queue.Count);
        var index = queue.Count - 1;
        while (queue.Any())
        {
            reverse.Insert(0, queue.Dequeue());
        }

        return new Queue<T>(reverse);
    }
}
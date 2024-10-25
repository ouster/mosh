using DnA1.MyLinkedList;
using Xunit.Abstractions;

namespace DnA1;

public class MyLinkedInTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private MyLinkedList<string> _list;

    public MyLinkedInTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _list = new MyLinkedList<string>();
        _list.AddFirst("bob");
        _list.AddLast("alice");
    }

    [Fact]
    public void AddFirstNodeTest()
    {
        Assert.True(_list.Contains("bob"));
        Assert.Equal(2, _list.Size());
    }

    [Fact]
    public void IndexOfTest()
    {
        Assert.Equal(1, _list.IndexOf("alice"));
        Assert.Equal(2, _list.Size());
    }

    [Fact]
    public void DeleteFirstNodeTest()
    {
        _list.DeleteFirst();
        Assert.Equal(-1, _list.IndexOf("bob"));
        Assert.True(_list.Contains("alice"));
        Assert.Equal(1, _list.Size());
    }

    [Fact]
    public void DeleteLastNodeTest()
    {
        _list.DeleteLast();
        Assert.Equal(-1, _list.IndexOf("alice"));
        Assert.True(_list.Contains("bob"));
        Assert.Equal(1, _list.Size());
    }

    [Fact]
    public void DeleteFirstLastNodeTest()
    {
        _list.AddFirst("claire");
        _list.DeleteLast();
        _list.DeleteFirst();
        Assert.True(_list.Contains("bob"));
        Assert.Equal(1, _list.Size());
    }

    [Fact]
    public void ToArrayTest()
    {
        var expected = new string[] { "bob", "alice" };
        Assert.Equal(expected, _list.ToArray());
    }

    [Fact]
    public void DeleteFirstLastEmptyNodeTest()
    {
        _list = new MyLinkedList<string>();
        try
        {
            _list.DeleteLast();
            Assert.Fail();
        }
        catch (KeyNotFoundException)
        {
        }

        try
        {
            _list.DeleteFirst();
        }
        catch (KeyNotFoundException)
        {
        }

        Assert.False(_list.Contains("bob"));
        Assert.Equal(0, _list.Size());
    }

    [Fact]
    public void ReverseListTest()
    {
        _list.AddLast("pudding");

        _list.Reverse();

        _testOutputHelper.WriteLine(_list.ToArray().ToString());

        var expected = new string[] { "pudding", "alice", "bob" };
        Assert.Equal(expected, _list.ToArray());
    }

    [Fact]
    public void GetKthNodeTest()
    {
        _list.AddLast("pudding");
        _list.AddLast("trigger");
        _list.AddLast("bailey");

        _testOutputHelper.WriteLine(_list.ToArray().ToString());


        Assert.Equal("bailey", _list.GetKthNode(1));
        Assert.Equal("trigger", _list.GetKthNode(2));
        Assert.Equal("pudding", _list.GetKthNode(3));
    }
}
using DnA1.Array;
using Xunit.Abstractions;

namespace DnA1;

public class MyArrayTests : IDisposable
{
    private readonly ITestOutputHelper _testOutputHelper;
    private MyArray<int> _array;

    public MyArrayTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _array = new MyArray<int>();
        _array.Insert(10);
        _array.Insert(20);
        _array.Insert(30);
        _array.Insert(40);
        _array.Insert(50);
        _testOutputHelper.WriteLine("Setup");
    }

    [Fact]
    public void InsertAndRemoveTest()
    {
        try
        {
            _array.Message();
            _array.RemoveAt(2);
            _array.Message();

            var expected = new[] { 10, 20, 40, 50 };
            Assert.Equal(expected, _array.ToArray());
        }
        catch (Exception ex)
        {
            _testOutputHelper.WriteLine(ex.Message);
        }
    }

    [Fact]
    public void InsertAtTestOutOfRange()
    {
        try
        {
            _array.RemoveAt(-1);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            _testOutputHelper.WriteLine(ex.Message);
        }

        _array.Message();
        try
        {
            _array.RemoveAt(5);
            Assert.Fail();
        }
        catch (Exception ex)
        {
            _testOutputHelper.WriteLine(ex.Message);
        }
    }


    [Fact]
    public void MaxTest()
    {
        var max = _array.Max();
        Assert.Equal(50, max);
    }


    [Fact]
    public void CommonTest()
    {
        var common = _array.Common([10, 40, 66]);
        var expected = new[] { 10, 40 };
        Assert.Equal(expected, common);
    }


    [Fact]
    public void IndexOfTest()
    {
        var indexOf = _array.IndexOf(50);
        Assert.Equal(4, indexOf); 

        indexOf = _array.IndexOf(555);
        Assert.Equal(-1, indexOf);
    }

    [Fact]
    public void ReverseTest()
    {
        var reverse = _array.Reverse();
        var expected = new[] { 50, 40, 30, 20, 10 };
        Assert.Equal(expected, reverse);
    }

    public void Dispose()
    {
    }
}
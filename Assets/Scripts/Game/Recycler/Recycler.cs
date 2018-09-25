/**
 * 对象回收
 */

using Base.Common;
using Base.Extension;
using System.Collections.Generic;

public interface IRecyclable
{
    string GetRecycleType();
    void Dispose();
}

public class Recycler : Singleton<Recycler>
{
    private static DictionaryEx<string, Stack<IRecyclable>> pool;

    /// <summary>
    /// 初始化
    /// </summary>
    public Recycler()
    {
        pool = new DictionaryEx<string, Stack<IRecyclable>>();
    }

    /// <summary>
    /// 回收对象
    /// </summary>
    public void Push(IRecyclable obj)
    {
        var type = obj.GetRecycleType();
        var stack = pool[type];
        if (stack == null)
        {
            stack = new Stack<IRecyclable>();
            pool.Add(type, stack);
        }
        stack.Push(obj);
    }

    /// <summary>
    /// 使用对象
    /// </summary>
    public IRecyclable Pop(string type)
    {
        var stack = pool[type];
        if (stack != null && stack.Count > 0)
        {
            return stack.Pop();
        }
        return null;
    }
}



/**
 * 对象池管理
 */

using System;
using Base.Common;
using Base.Extension;
using System.Collections.Generic;

namespace Base.Pool
{
    public interface IRecycler
    {
        void Dispose();
    }

    public class PoolManager : Singleton<PoolManager>
    {
        /// <summary>
        /// 对象池存放的最大对象数
        /// </summary>
        private const int MAX_SIZE = 20;
        /// <summary>
        /// 对象池类型与队列映射
        /// </summary>
        private DictionaryEx<Type, Queue<IRecycler>> poolDict = new DictionaryEx<Type, Queue<IRecycler>>();

        /// <summary>
        /// 回收对象
        /// </summary>
        public void Push<T>(T obj) where T : IRecycler
        {
            var type = typeof(T);
            var queue = poolDict[type];
            if (queue == null || queue.Contains(obj) || queue.Count > MAX_SIZE) return;
            obj.Dispose();
            queue.Enqueue(obj);
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        public T Pop<T>() where T : class, IRecycler
        {
            var type = typeof(T);
            var queue = poolDict[type];
            if (queue != null && queue.Count > 0) return queue.Dequeue() as T;
            return null;
        }

        /// <summary>
        /// 释放所有对象池
        /// </summary>
        public void Release()
        {
            foreach(var queue in poolDict)
            {
                foreach(var recycler in queue.Value)
                {
                    recycler.Dispose();
                }
                queue.Value.Clear();
            }
        }
    }
}

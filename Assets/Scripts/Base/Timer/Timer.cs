/**
 * 定时器
 */

using System;
using Base.Pool;
using UnityEngine;

namespace Base.Timer
{
    public class Timer : IRecycler
    {
        /// <summary>
        /// 持续时间
        /// </summary>
        private float duration; 
        /// <summary>
        /// 循环次数
        /// </summary>
        private int loop;
        /// <summary>
        /// 结束回调
        /// </summary>
        private Action finishAction;
        /// <summary>
        /// 当前时间
        /// </summary>
        private float time = 0;
        //==========================================================================
        public bool Active { get; private set; }
        //==========================================================================
        
        /// <summary>
        /// 重置
        /// </summary>
        public void Reset(float duration, int loop, Action finishAction)
        {
            this.duration = duration;
            this.loop = loop;
            this.time = duration;
            this.finishAction = finishAction;
            Active = true;
        }

        /// <summary>
        /// 定时返回，返回true, 表示定时器结束
        /// </summary>
        public void Update()
        {
            if (!Active) return;
            var deltaTime = Time.deltaTime;
            time -= deltaTime;
            if (time < 0)
            {
                if (finishAction != null) finishAction();
                if (loop > 0)
                {
                    loop--;
                    time += duration;
                }
                if (loop == 0)
                {
                    Active = false;
                    return;
                }
                else if (loop < 0)
                {
                    time += duration;
                }
            }
        }

        /// <summary>
        /// 释放回收
        /// </summary>
        public void Dispose()
        {
            duration = 0;
            loop = 0;
            time = 0;
            finishAction = null;
            Active = false;
        }
    }
}

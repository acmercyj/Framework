/**
 * 定时器管理
 */

using System;
using Base.Common;
using Base.Pool;
using System.Collections.Generic;

namespace Base.Timer
{
    public class TimerManager : Singleton<TimerManager>
    {
        /// <summary>
        /// 定时器集合
        /// </summary>
        private HashSet<Timer> timerSet = new HashSet<Timer>();
        /// <summary>
        /// 待删除的定时器列表
        /// </summary>
        private List<Timer> removeTimerList = new List<Timer>();
        
        /// <summary>
        /// 创建定时器
        /// </summary>
        public Timer CreateTimer(float duration, int loop, Action finishAction)
        {
            var timer = PoolManager.Instance.Pop<Timer>();
            timer.Reset(duration, loop, finishAction);
            timerSet.Add(timer);
            return timer;
        }

        public void Update()
        {
            // 是否清除删除列表
            bool clear = false;
            foreach(var timer in timerSet)
            {
                timer.Update();
                // 定时器完成
                if (!timer.Active)
                {
                    clear = true;
                    removeTimerList.Add(timer);
                }
            }
            for (int i = 0; i < removeTimerList.Count; i++)
            {
                var timer = removeTimerList[i];
                if (timerSet.Contains(timer))
                {
                    timerSet.Remove(timer);
                    PoolManager.Instance.Push<Timer>(timer);
                }
            }
            if (clear) removeTimerList.Clear();
        }
    }
}



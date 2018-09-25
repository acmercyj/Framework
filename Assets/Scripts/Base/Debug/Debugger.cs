﻿/**
 * 调试器
 */

namespace Base.Debug
{
    public class Debugger
    {
        /// <summary>
        /// 日志输出
        /// </summary>
        public static void Log(string message, params object[] args)
        {
            UnityEngine.Debug.Log(string.Format(message, args));
        }

        /// <summary>
        /// 根据结果打印消息
        /// </summary>
        public static void Log(bool result, string message)
        {
            if (!result)
                LogError(message);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        public static void LogError(string message, params object[] args)
        {
            UnityEngine.Debug.LogError(string.Format(message, args));
        }
    }
}

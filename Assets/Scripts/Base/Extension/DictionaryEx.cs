﻿/**
 * 字典扩展
 */

using System;
using System.Collections.Generic;

namespace Base.Extension
{
    public class DictionaryEx<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey indexKey]
        {
            set { base[indexKey] = value; }
            get
            {
                try
                {
                    return base[indexKey];
                }
                catch (Exception)
                {
                    return default(TValue);
                }
            }
        }
    }
}

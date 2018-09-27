/**
 * 数据驱动
 */

using System;

namespace Base.DataDriven
{
    public class Data<T>
    {
        private T value;

        /// <summary>
        /// 数据修改的监听回调 
        /// </summary>
        private Action<T> OnChange;

        public T Value
        {
            get { return value; }
            set { SetVaule(value); }
        }

        /// <summary>
        /// 检测新旧值，不一致则触发修改监听
        /// </summary>
        private void SetVaule(T value)
        {
            if (value != null && value.Equals(this.value)) return;
            if (this.value != null && this.value.Equals(value)) return;
            if (value == null && this.value == null) return;

            this.value = value;
            OnChange(value);
        }

        /// <summary>
        /// 添加数值变化的监听
        /// </summary>
        public void AddChangeListener(Action<T> listener)
        {
            OnChange += listener;
        }
        
        /// <summary>
        /// 删除监听
        /// </summary>
        public void RemoveChangeListener(Action<T> listener)
        {
            OnChange -= listener;
        }
    }
}

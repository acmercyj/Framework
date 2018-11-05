/**
 * ScrollRect嵌套ScrollRect
 * 内层滚动层会拦掉外层的滚动层监听
 * 内层滚动层监听垂直滚动时，外层滚动层则监听水平滚动
 */

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VHScrollRect : ScrollRect
{
    /// <summary>
    /// 外层Scroll
    /// </summary>
    public ScrollRect OuterScroll;
    /// <summary>
    /// 内层Scroll是否垂直滚动
    /// </summary>
    public bool IsVertical = true;
    /// <summary>
    /// 是否触发自己的事件
    /// </summary>
    private bool isSelf = false;

    /// <summary>
    /// 开始拖动监听
    /// </summary>
    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (IsVertical)
        {
            if (Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x))
            {
                isSelf = true;
                base.OnBeginDrag(eventData);
            }
            else
            {
                isSelf = false;
                if (OuterScroll != null)
                    OuterScroll.OnBeginDrag(eventData);
            }
        }
        else
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                isSelf = true;
                base.OnBeginDrag(eventData);
            }
            else
            {
                isSelf = false;
                if (OuterScroll != null)
                    OuterScroll.OnBeginDrag(eventData);
            }
        }
    }

    /// <summary>
    /// 拖动事件
    /// </summary>
    public override void OnDrag(PointerEventData eventData)
    {
        if (isSelf)
        {
            base.OnDrag(eventData);
        }
        else
        {
            if (OuterScroll != null)
                OuterScroll.OnDrag(eventData);
        }
    }

    /// <summary>
    /// 拖动结束
    /// </summary>
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (isSelf)
        {
            base.OnEndDrag(eventData);
        }
        else
        {
            if (OuterScroll != null)
                OuterScroll.OnEndDrag(eventData);
        }
    }
}

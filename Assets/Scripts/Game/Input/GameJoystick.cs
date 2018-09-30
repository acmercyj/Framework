/**
 * 描述：游戏摇杆
 */

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class GameJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    /// <summary>
    /// 摇杆中心控件
    /// </summary>
    public RectTransform Center;
    /// <summary>
    /// 摇杆底图
    /// </summary>
    public RectTransform BackGround;
    /// <summary>
    /// 中心控件移动的半径范围
    /// </summary>
    public float Radius;
    /// <summary>
    /// 中心控件的开始位置
    /// </summary>
    private Vector3 startPos;

    //==========================================================================
    public Action<Vector2> Drag;
    public Action<Vector2> OnDown;
    public Action OnUp;
    //=========================================================================

    private void Start()
    {
        startPos = Center.transform.position;
    }

    /// <summary>
    /// 按下
    /// </summary>
    /// <param name="data">Data.</param>
    public void OnPointerDown(PointerEventData data)
    {
        var vec = SetCenterPosition(data);
        if (OnDown != null)
            OnDown(vec);
    }

    /// <summary>
    /// 抬起
    /// </summary>
    /// <param name="data">Data.</param>
    public void OnPointerUp(PointerEventData data)
    {
        Center.DOMove(startPos, 0.1f).SetEase(Ease.OutSine);
        if (OnUp != null)
            OnUp();
    }

    /// <summary>
    /// 拖动
    /// </summary>
    /// <param name="data">Data.</param>
    public void OnDrag(PointerEventData data)
    {
        var vec = SetCenterPosition(data);
        if (Drag != null)
            Drag(vec);
    }

    /// <summary>
    /// 设置摇杆中心控件位置
    /// </summary>
    /// <param name="data">Data.</param>
    private Vector2 SetCenterPosition(PointerEventData data)
    {
        var vec = Vector2.zero;
        var localPosition = new Vector2(data.position.x - BackGround.position.x, data.position.y - BackGround.position.y);

        if (localPosition.sqrMagnitude > Radius * Radius)
        {
            localPosition = localPosition.normalized * Radius;
        }

        Center.localPosition = localPosition;
        vec.x = localPosition.x / Radius;
        vec.y = localPosition.y / Radius;
        return vec;
    }
}

/**
 * 自定义按钮
 * 自带摇杆，CD图
 */

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
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
    /// 技能CD遮罩
    /// </summary>
    public Image CDImage;
    /// <summary>
    /// 中心控件的开始位置
    /// </summary>
    private Vector3 startPos;
    //==========================================================================
    public Action<Vector2> Drag;
    public Action<Vector2> OnDown;
    public Action OnUp;
    //==========================================================================

    /// <summary>
    /// 按下时设置摇杆位置
    /// </summary>
    public void Down()
    {
        BackGround.gameObject.SetActive(true);
        BackGround.localPosition = transform.localPosition;
        Center.localPosition = Vector3.zero;
        startPos = Center.localPosition;
    }

    /// <summary>
    /// 抬起时设置摇杆消失
    /// </summary>
    public void Up()
    {
        BackGround.gameObject.SetActive(false);
    }

    /// <summary>
    /// 按下
    /// </summary>
    /// <param name="data">Data.</param>
    public virtual void OnPointerDown(PointerEventData data)
    {
        var vec2 = SetCenterPosition(data);
        if (OnDown != null)
            OnDown(vec2);
    }

    /// <summary>
    /// 抬起
    /// </summary>
    /// <param name="data">Data.</param>
    public virtual void OnPointerUp(PointerEventData data)
    {
        //iTween.ScaleTo(gameObject, Vector3.one, 0.1f);
        if (OnUp != null)
            OnUp();
    }

    /// <summary>
    /// 拖动
    /// </summary>
    /// <param name="data">Data.</param>
    public virtual void OnDrag(PointerEventData data)
    {
        var vec2 = SetCenterPosition(data);
        if (Drag != null)
            Drag(vec2);
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


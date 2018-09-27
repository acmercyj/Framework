/**
 * 单位对象基类(逻辑对象)
 */

using UnityEngine;
using Base.DataDriven;

public class Unit : Entity
{
    /// <summary>
    /// 逻辑对象对应的表现对象
    /// </summary>
    protected Visual visual;

    //==========================================================================
    public Data<Vector3> Position;
    public Data<Vector3> Forward;
    //==========================================================================

    /// <summary>
    /// 构造
    /// </summary>
    public Unit() : base()
    {
        Position = new Data<Vector3>();
        Forward = new Data<Vector3>();
        Position.AddChangeListener(ChangePosition);
        Forward.AddChangeListener(ChangeForward);
    }

    /// <summary>
    /// 释放清理
    /// </summary>
    public virtual void Release()
    {
        Position.RemoveChangeListener(ChangePosition);
        Forward.RemoveChangeListener(ChangeForward);
    }

    /// <summary>
    /// 改变位置
    /// </summary>
    private void ChangePosition(Vector3 position)
    {
      
    }

    /// <summary>
    /// 改变转向
    /// </summary>
    private void ChangeForward(Vector3 forward)
    {

    }
}
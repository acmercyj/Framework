/**
 * 单位对象基类(逻辑对象)
 */

using UnityEngine;
using Base.DataDriven;
using Sheet;

public class Unit : Entity
{
    /// <summary>
    /// 逻辑对象对应的表现对象
    /// </summary>
    protected Visual visual;
    //==========================================================================
    public Data<Vector3> Position;
    public Data<Vector3> Forward;
    public EUnit EUnit { get; protected set; }
    public UnitTable Table { get; private set; }
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
    /// 创建
    /// </summary>
    public virtual void Create(int id)
    {
        Table = SheetManager.Instance.GetSheetInfo<UnitTable>(id);
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
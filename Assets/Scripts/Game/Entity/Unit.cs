/**
 * 单位对象基类(逻辑对象)
 */

using UnityEngine;
using Base.DataDriven;
using Sheet;
using System;

public class Unit : Entity
{
    private bool isMoveBtnDown = false;
    protected StateManager stateManager;

    //==========================================================================
    public Data<Vector3> Position;
    public Data<Vector3> Forward;
    public Data<bool> Dead;
    public EUnit UnitType { get; protected set; }
    public UnitTable Table { get; private set; }
    //==========================================================================

    /// <summary>
    /// 构造
    /// </summary>
    public Unit() : base()
    {
        Position = new Data<Vector3>();
        Forward = new Data<Vector3>();
        Dead = new Data<bool>();
        stateManager = new StateManager(this);
    }

    /// <summary>
    /// 创建
    /// </summary>
    public virtual void Create(int id)
    {
        Table = SheetManager.Instance.GetSheetInfo<UnitTable>(id);
        VisualManager.Instance.CreateVisual(this);
        Dead.Value = false;
        Position.AddChangeListener(ChangePosition);
        Forward.AddChangeListener(ChangeForward);
        AddState(EState.Move, DoMove);
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
    /// 添加指定状态及改状态对应的移动回调
    /// </summary>
    /// <param name="eState"></param>
    /// <param name="moveFunc"></param>
    public void AddState(int eState, Action moveFunc = null)
    {
        stateManager.AddState(eState, moveFunc);
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
    
    /// <summary>
    /// 逻辑帧更新
    /// </summary>
    public void FixedUpdate()
    {
        if (!Dead.Value)
        {
            stateManager.FixedUpdate();
        }
    }

    /// <summary>
    /// 移动操作
    /// </summary>
    private void DoMove()
    {

    }
}
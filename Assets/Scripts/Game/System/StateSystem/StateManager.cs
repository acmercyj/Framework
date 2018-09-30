/**
 * 状态系统管理
 */

using Sheet;
using System;
using Base.DataDriven;
using System.Collections.Generic;

class MoveFunc
{
    public EMoveMode mode;
    public int priority;
    public Action func;
}

public class StateManager
{
    private Unit owner;
    private LinkedList<MoveFunc> moveFuncList = new LinkedList<MoveFunc>();

    public StateManager(Unit owner)
    {
        this.owner = owner;
    }

    /// <summary>
    /// 不同状态对移动、转向、普通、技能的影响 
    /// </summary>
    /// <param name="id">状态id</param>
    /// <param name="moveFunc">对移动产生影响的回调</param>
    public void AddState(int id, Action moveFunc = null)
    {
        var table = SheetManager.Instance.GetSheetInfo<StateTable>(id);
        if (moveFunc == null) return;

        var curMoveFunc = moveFuncList.First;
        if (curMoveFunc == null)
        {
            moveFuncList.AddFirst(CreateMoveFunc(table, moveFunc));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private MoveFunc CreateMoveFunc(StateTable table, Action moveFunc)
    {
        var mf = new MoveFunc();
        mf.mode = (EMoveMode)table.moveMode;
        mf.priority = table.movePriority;
        mf.func = moveFunc;
        return mf;
    }
}

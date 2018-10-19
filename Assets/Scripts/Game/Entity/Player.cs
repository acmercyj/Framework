/**
 * 玩家对象基类
 */

public class Player : Unit
{
    private bool inputMoveFlag = false;
    /// <summary>
    /// 创建
    /// </summary>
    public override void Create(int id)
    {
        base.Create(id);
        UnitType = EUnit.Player;
        GameInput.OnVKey = OnVkey;
        AddState(EState.Move, DoMove);
    }

    /// <summary>
    /// 输入控制
    /// </summary>
    private void OnVkey(EVKey vkey, object arg)
    {
        switch(vkey)
        {
            case EVKey.Move:
                break;
            case EVKey.MoveX:
                break;
            case EVKey.MoveY:
                break;
            case EVKey.MoveStart:
                break;
            case EVKey.MoveEnd:
                break;
        }
    }

    /// <summary>
    /// 移动操作
    /// </summary>
    private void DoMove()
    {

    }
}

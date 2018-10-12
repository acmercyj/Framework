/**
 * 玩家对象基类
 */

using UnityEngine;

public class Player : Unit
{
    /// <summary>
    /// 创建
    /// </summary>
    public override void Create(int id)
    {
        base.Create(id);
        UnitType = EUnit.Player;
        GameInput.OnVKey = OnVkey;
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
}

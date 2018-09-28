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
        EUnit = EUnit.Player;
    }
}

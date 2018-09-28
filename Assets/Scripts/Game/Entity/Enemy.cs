/**
 * 敌方对象基类
 */

using UnityEngine;

public class Enemy : Unit
{
    /// <summary>
    /// 创建
    /// </summary>
    public override void Create(int id)
    {
        base.Create(id);
        EUnit = EUnit.Enemy;
    }
}


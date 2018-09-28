/**
 * 单位管理器
 */

using System;
using Base.Common;
using UnityEngine;
using System.Collections.Generic;

public class EntityManager : Singleton<EntityManager>
{
    private Transform root;
    private Player player;
    private Dictionary<int, Unit> enemyDict = new Dictionary<int, Unit>();
    private Dictionary<int, Unit> unitDict = new Dictionary<int, Unit>();
    
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        if (root != null) return;
        root = new GameObject("EntityRoot").transform;
    }

    /// <summary>
    /// 创建实例
    /// </summary>
    private T CreateInstance<T>() where T : Entity
    {
        return Activator.CreateInstance<T>();
    }

    /// <summary>
    /// 创建玩家
    /// </summary>
    public void CreatePlayer(int id, Vector3 pos = default(Vector3))
    {
        if (player != null) return;

        player = CreateInstance<Player>();
        player.Create(id);
        player.CreateVisual(root);
    }

    /// <summary>
    /// 创建敌人
    /// </summary>
    public void CreateEnemy(int id, Vector3 pos = default(Vector3), Vector3 forward = default(Vector3))
    {
        var enemy = CreateInstance<Enemy>();
        enemy.Create(id);
        enemy.CreateVisual(root);
    }

    /// <summary>
    /// 清理
    /// </summary>
    public void Release()
    {
        foreach(var unit in unitDict)
        {
            unit.Value.Release();
        }

        player = null;
        enemyDict.Clear();
        unitDict.Clear();
    }
}
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
    private Dictionary<int, Unit> map;
    
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
    }

    /// <summary>
    /// 清理
    /// </summary>
    public void Release()
    {

    }
}
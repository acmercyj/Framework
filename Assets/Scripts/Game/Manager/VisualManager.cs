/**
 * 可视对象管理器
 */

using Base.Common;
using UnityEngine;

public class VisualManager : Singleton<VisualManager>
{

    private Transform EntityRoot;

    /// <summary>
    /// 创建对象根节点
    /// </summary>
    public VisualManager()
    {
        if (EntityRoot != null) return;
        EntityRoot = new GameObject("EntityRoot").transform;   
    }

    /// <summary>
    /// 创建可视对象
    /// </summary>
    public void CreateVisual(Unit unit)
    {
        var table = unit.Table;
        var go = new GameObject(table.id.ToString());
        go.transform.SetParent(EntityRoot);
        var visual = go.AddComponent<Visual>();
        visual.Create(unit);
    }
}
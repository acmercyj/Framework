/**
 * 可视对象基类(渲染表现)
 */

using Sheet;
using UnityEngine;

public class Visual : MonoBehaviour
{
    /// <summary>
    /// 对应的逻辑单位
    /// </summary>
    private Unit owner;
    
    /// <summary>
    /// 绑定逻辑对象
    /// </summary>
    public void Create(Unit owner)
    {
        this.owner = owner;
        SetModel(string.Format("Unit/{0}/{1}", owner.Table.id, owner.Table.model));
    }

    /// <summary>
    /// 设置模型
    /// </summary>
    private void SetModel(string path)
    {
        var model = ResourcesManager.Instance.Load<GameObject>(path);
        if (model != null)
        {
            Instantiate(model, transform);
        }
    }
}
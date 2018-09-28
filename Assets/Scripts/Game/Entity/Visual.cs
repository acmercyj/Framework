/**
 * 可视对象基类(渲染表现)
 */

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
    public void Bind(Unit owner)
    {
        this.owner = owner; 
    }
}
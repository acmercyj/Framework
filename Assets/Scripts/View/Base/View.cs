/**
 * 视图UI基类
 */

using UnityEngine;

public abstract class View : MonoBehaviour
{
    /// <summary>
    /// 进入页面
    /// </summary>
    /// <param name="args"></param>
    public virtual void Enter(params object[] args) { gameObject.SetActive(true); }

    /// <summary>
    /// 退出页面
    /// </summary>
    public virtual void Exit() { gameObject.SetActive(false); }
}

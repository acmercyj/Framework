/**
 * 视图UI基类
 */

using UnityEngine;

public abstract class View : MonoBehaviour
{
    /// <summary>
    /// 视图是否打开着 
    /// </summary>
    public bool IsOpen { get { return gameObject.activeSelf; } }
    
    /// <summary>
    /// 打开视图 
    /// </summary>
    public virtual void Open(params object[] args)
    {
        if (!IsOpen)
            gameObject.SetActive(true);

        transform.SetAsLastSibling();
    }

    /// <summary>
    /// 关闭视图
    /// </summary>
    public virtual void Close()
    {
        if (IsOpen)
            gameObject.SetActive(false);
    }

    /// <summary>
    /// 销毁页面视图
    /// </summary>
    public virtual void Destroy() { GameObject.Destroy(gameObject); }
}

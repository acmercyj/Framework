/**
 * 资源加载
 */

using UnityEngine;
using Base.Debug;
using Base.Common;

public class ResourcesManager : Singleton<ResourcesManager>
{
    /// <summary>
    /// 加载
    /// </summary>
    public T Load<T>(string path) where T : Object
    {
        var prefab = Resources.Load<T>(path);
        Debugger.Log(prefab != null, string.Format("未找到指定路径[{0}]下的prefab", path));
        return prefab;
    }

    /// <summary>
    /// 加载所有
    /// </summary>
    public T[] LoadAll<T>(string path) where T : Object
    {
        return Resources.LoadAll<T>(path);
    }
}




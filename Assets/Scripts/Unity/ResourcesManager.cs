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
        Debugger.Log(prefab != null, string.Format("[{0}] Not Exists", path));
        return prefab;
    }
}




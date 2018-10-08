/**
 * 视图UI管理
 */

using Base.Common;
using Base.Debug;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : Singleton<ViewManager>
{
    /// <summary>
    /// 视图UI映射
    /// </summary>
    private Dictionary<string, View> viewDict = new Dictionary<string, View>();
    /// <summary>
    /// 视图UI堆栈
    /// </summary>
    private Stack<View> viewStack = new Stack<View>();
    /// <summary>
    /// 添加视图的节点
    /// </summary>
    private Transform viewRoot;

    /// <summary>
    /// 加载页面
    /// </summary>
    private T Load<T>(string path) where T : View, new()
    {
        T ui = null;
        var prefab = ResourcesManager.Instance.Load<GameObject>(path);
        if (prefab != null)
        {
            var go = GameObject.Instantiate(prefab);
            AddChild(go.transform);
            ui = go.GetComponent<T>();
            if (ui != null)
            {
                viewDict.Add(path, ui);
            }
            else
            {
                Debugger.LogError("[{0}] No Component [{1}]", path, typeof(T).ToString());
            }
        }
        return ui;
    }

    /// <summary>
    /// 添加节点
    /// </summary>
    private void AddChild(Transform child)
    {
        if (child == null)
        {
            Debugger.LogError("Child Not Exists");
            return;
        }

        if (viewRoot == null)
        {
            var canvas = GameObject.Find("Canvas");
            if (canvas == null)
            {
                Debugger.LogError("Canvas Not Exists");
                return;
            }
            viewRoot = canvas.transform;
        }

        child.SetParent(viewRoot, false);
    }

    /// <summary>
    /// 显示视图
    /// </summary>
    public T Push<T>(string path, params object[] args) where T : View, new()
    {
        var view = viewDict.ContainsKey(path) ? viewDict[path] : Load<T>(path);

        if (view != null)
        {
            view.Open(args);
            viewStack.Push(view);
        }

        return (T)view;
    }

    /// <summary>
    /// 关闭视图
    /// </summary>
    public void Pop()
    {
        if (viewStack.Count == 0) return;
        var view = viewStack.Peek();
        view.Close();
        viewStack.Pop();
    }

    /// <summary>
    /// 替换视图
    /// </summary>
    /// <param name="clear">是否清理所有弹窗</param>
    public void Replace<T>(string name, bool clear = false, params object[] args) where T : View, new()
    {
        if (clear)
        {
            while (viewStack.Count > 0)
            {
                Pop();
            }
            Push<T>(name, args);
        }
        else
        {
            Pop();
            Push<T>(name, args);
        }
    }

    /// <summary>
    /// 清除所有视图
    /// </summary>
    public void Clear()
    {
        foreach (var view in viewDict.Values)
        {
            view.Destroy();
        }

        viewDict.Clear();
        viewStack.Clear();
    }
}

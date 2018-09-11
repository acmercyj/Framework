/**
 * 描述：视图UI管理
 */

using Base.Common;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : Singleton<ViewManager>
{
    /// <summary>
    /// 视图UI映射
    /// </summary>
    private Dictionary<string, View> viewMap = new Dictionary<string, View>();
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
    private T Load<T>(string name) where T : View, new()
    {
        T ui = null;
        var prefab = ResourcesManager.Instance.Load<T>(name);
        if (prefab != null)
        {
            var go = GameObject.Instantiate(prefab);
            ui = go.GetComponent<T>();
            AddChild(go.transform);
            viewMap.Add(name, ui);
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
            Debug.LogError("Node Not Found");
            return;
        }

        if (viewRoot == null)
        {
            var canvas = GameObject.Find("Canvas");
            if (canvas == null)
            {
                Debug.LogError("Canvas Not Found");
                return;
            }
            viewRoot = canvas.transform;
        }

        child.SetParent(viewRoot, false);
    }

    /// <summary>
    /// 显示视图
    /// </summary>
    public void Push<T>(string name, params object[] args) where T : View, new()
    {
        var view = viewMap.ContainsKey(name) ? viewMap[name] : Load<T>(name);

        if (view != null)
        {
            view.Enter(args);
            viewStack.Push(view);
        }
    }

    /// <summary>
    /// 关闭视图
    /// </summary>
    public void Pop()
    {
        if (viewStack.Count == 0)
            return;

        var view = viewStack.Peek();
        view.Exit();
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
            while(viewStack.Count > 0)
            {
                var view = viewStack.Peek();
                view.Exit();
                viewStack.Pop();
            }
            Push<T>(name, args);
        }
        else
        {
            var view = viewStack.Peek();
            view.Exit();
            viewStack.Pop();
            Push<T>(name, args);
        }
    }

    /// <summary>
    /// 清除所有视图
    /// </summary>
    public void Clear()
    {
        foreach(var view in viewMap.Values)
        {
            GameObject.Destroy(view.gameObject);
        }

        viewMap.Clear();
        viewStack.Clear();
    }
}

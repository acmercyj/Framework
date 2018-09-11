/**
 * 描述：模块管理
 */

using System;
using System.Collections.Generic;
using Base.Common;

public class ModuleManager : Singleton<ModuleManager>
{
    /// <summary>
    /// 模块映射列表
    /// </summary>
    private Dictionary<string, Module> moduleMap = new Dictionary<string, Module>();

    /// <summary>
    /// 获得模块
    /// </summary>
    public T GetModule<T>(string name) where T : Module
    {
        return (T)(moduleMap.ContainsKey(name) ? moduleMap[name] : CreateModule(name));
    }

    /// <summary>
    /// 创建模块
    /// </summary>
    public Module CreateModule(string name)
    {
        Module module = null;
        Type type = Type.GetType(name);

        if (type != null)
        {
            module = Activator.CreateInstance(type) as Module;
            moduleMap.Add(name, module);
        }

        return module;
    }
}

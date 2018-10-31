/**
 * Lua主入口
 */

using UnityEngine;
using XLua;

public class LuaMain : MonoBehaviour
{
    [SerializeField] TextAsset luaScript;
    private LuaEnv luaEnv = new LuaEnv();
    public static LuaMain Instance { get; private set; }

    /// <summary>
    /// 初始化Lua环境
    /// </summary>
    private void Awake()
    {
        Instance = this;

    }
}

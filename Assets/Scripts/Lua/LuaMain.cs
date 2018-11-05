/**
 * Lua主入口
 */

using XLua;
using Base.Common;

public class LuaMain : Singleton<LuaMain>
{
    private LuaEnv luaEnv = new LuaEnv();

    /// <summary>
    /// 初始化Lua环境
    /// </summary>
    public void Init()
    {
        LuaTable meta = luaEnv.NewTable();
        meta.Set("__index", luaEnv.Global);
        //scriptEnv.SetMetaTable(meta)
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void Update()
    {
        if (luaEnv != null)
        {
            luaEnv.Tick();
        }
    }

    /// <summary>
    /// 销毁
    /// </summary>
    public void OnDestroy()
    {
        if (luaEnv != null) luaEnv.Dispose();
    }
}

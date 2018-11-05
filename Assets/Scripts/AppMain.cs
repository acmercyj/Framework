/**
 * 程序主入口
 */

using UnityEngine;
using Base.Timer;

public class AppMain : MonoBehaviour
{
    /// <summary>
    /// 开始游戏，初始化配置文件
    /// </summary>
    private void Awake()
    {
        //DontDestroyOnLoad(this);
        AppConfig.Init();
        SheetManager.Instance.Init();
        //GameSceneManager.Instance.LoadScene("Main", () =>
        //{
        //    ViewManager.Instance.Push<MainView>(ViewDef.MainView);
        //});
    }

    /// <summary>
    /// 更新总入口
    /// </summary>
    private void Update()
    {
        TimerManager.Instance.Update();
    }

    /// <summary>
    /// 销毁清除
    /// </summary>
    private void OnDestroy()
    {
        LuaMain.Instance.OnDestroy(); 
    }
}

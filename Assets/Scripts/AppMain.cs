/**
 * 程序主入口
 */

using UnityEngine;
using Sheet;

public class AppMain : MonoBehaviour
{
    /// <summary>
    /// 开始游戏，初始化配置文件
    /// </summary>
    private void Start()
    {
        DontDestroyOnLoad(this);

        SheetManager.Instance.Init();

        GameSceneManager.Instance.LoadScene("Main", () =>
        {
            ViewManager.Instance.Push<MainView>(ViewDef.MainView);
        });
    }
}

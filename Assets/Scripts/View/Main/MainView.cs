/**
 * 主界面视图
 */

using UnityEngine;

public class MainView : View
{
    /// <summary>
    /// 点击开始
    /// </summary>
    public void OnStart()
    {
        GameSceneManager.Instance.LoadScene("Fight", () =>
        {
            ViewManager.Instance.Clear();
            ViewManager.Instance.Push<FightView>(ViewDef.FightView);
            var fightModule = ModuleManager.Instance.GetModule<OfflineModule>(ModuleDef.OfflineModule);
            fightModule.StartGame();
        });
    }
}


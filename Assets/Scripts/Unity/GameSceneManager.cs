/**
 * 场景管理
 */

using System;
using Base.Common;
using UnityEngine.SceneManagement;

public class GameSceneManager : Singleton<GameSceneManager>
{
    /// <summary>
    /// 场景加载回调
    /// </summary>
    public Action SceneLoaded { get; set; }

    /// <summary>
    /// 注册回调
    /// </summary>
    public GameSceneManager()
    {
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if (SceneLoaded != null)
            {
                SceneLoaded();
                SceneLoaded = null;
            }
        };
    }

    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name=""></param>
    public void LoadScene(string name, Action action = null)
    {
        SceneLoaded = action;
        SceneManager.LoadScene(name);
        // SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
}


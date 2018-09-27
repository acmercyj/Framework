/**
 * 离线模块(单机模式)
 */

using UnityEngine;

public class OfflineModule : Module
{
    private int fameIndex;

    /// <summary>
    /// 开始游戏
    /// </summary>
    public void StartGame()
    {
        //创建游戏
        GameManager.Instance.CreateGame();
        //创建输入
        //GameInput.Create();

        UpdateHelper.AddUpdateListener(Update);
        UpdateHelper.AddFixedUpdateListener(FixedUpdate);
    }

    /// <summary>
    /// 离线模式的固定帧驱动游戏逻辑
    /// </summary>
    private void Update()
    {
        GameManager.Instance.Update(Time.deltaTime);
    }

    /// <summary>
    /// 离线模式的固定帧驱动游戏逻辑
    /// </summary>
    private void FixedUpdate()
    {
        fameIndex++;
        GameManager.Instance.FixedUpdate(fameIndex);
    }
}

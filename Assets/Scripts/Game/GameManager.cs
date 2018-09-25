/**
 * 游戏管理
 */

using Base.Common;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// 游戏是否正在进行
    /// </summary>
    private bool isRunning;

    //==========================================================================
    public bool IsRunning { get { return isRunning; } }
    //==========================================================================

    /// <summary>
    /// 创建游戏
    /// </summary>
    public void CreateGame()
    {
        isRunning = true;
    }

    /// <summary>
    /// 渲染帧更新
    /// </summary>
    public void Update(float deltaTime)
    {
    }

    /// <summary>
    /// 固定帧更新
    /// </summary>
    public void FixedUpdate(int fameIndex)
    {
    }
}


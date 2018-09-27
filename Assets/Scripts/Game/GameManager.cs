/**
 * 游戏管理
 */

using Base.Common;

public class GameManager : Singleton<GameManager>
{

    //==========================================================================
    public bool IsRunning { get; private set; }
    //==========================================================================

    /// <summary>
    /// 创建游戏
    /// </summary>
    public void CreateGame()
    {
        IsRunning = true;
        EntityManager.Instance.Init();
    }

    /// <summary>
    /// 施放游戏
    /// </summary>
    public void ReleaseGame()
    {
        EntityManager.Instance.Release(); 
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
        if (!IsRunning)
            return;
    }
}


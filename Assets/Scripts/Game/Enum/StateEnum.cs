/**
 * 状态枚举
 */

public static class EState
{
    /// <summary>
    /// 移动
    /// </summary>
    public static int Move = 0;
    /// <summary>
    /// 转向
    /// </summary>
    public static int Rotate = 1;
    /// <summary>
    /// 眩晕
    /// </summary>
    public static int Dizzy = 2;
    /// <summary>
    /// 翻滚
    /// </summary>
    public static int Roll = 3;
}

/// <summary>
/// 移动模式
/// </summary>
public enum EMoveMode
{
    /// <summary>
    /// 共存
    /// </summary>
    Coexist,
    /// <summary>
    /// 替换
    /// </summary>
    Replace
}
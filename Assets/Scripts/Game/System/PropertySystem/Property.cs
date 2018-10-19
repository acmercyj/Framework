/**
 * 属性
 */

public class Property
{
    private float value = 0;
    private float addition = 0;
    private float multiplication = 1;
    
    /// <summary>
    /// 数值值
    /// </summary>
    public float Value { get; protected set; }

    /// <summary>
    /// 设置固定加成值
    /// </summary>
    protected void SetAddition(float add)
    {
        
    }

    /// <summary>
    /// 计算结果
    /// </summary>
    protected void RecalculateValue()
    {
        Value = value * multiplication + addition;
    }
}


/**
 * 实体对象基类
 */

public abstract class Entity
{
    public static int id = 0;
    /// <summary>
    /// 唯一id
    /// </summary>
    public int ID { get; private set; }
    
    /// <summary>
    /// 构造
    /// </summary>
    protected Entity()
    {
        ID = id++;
    }
}
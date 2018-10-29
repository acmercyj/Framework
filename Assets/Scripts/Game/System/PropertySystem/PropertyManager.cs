/**
 * 属性对象管理
 */

using System.Collections.Generic;

public class PropertyManager
{
    private Dictionary<EProperty, Property> propertyDict = new Dictionary<EProperty, Property>(); 

    /// <summary>
    /// 根据枚举id创建对应属性对象
    /// </summary>
    private Property CreateProperty(EProperty id)
    {
        var property = new Property();
        propertyDict.Add(id, property);
        return property;
    }
    
    /// <summary>
    /// 获得属性
    /// </summary>
    private Property GetProperty(EProperty id)
    {
        if (propertyDict.ContainsKey(id)) return propertyDict[id];
        return CreateProperty(id);
    }

    public float GetPropertyValua(EProperty id)
    {
        return 0;
    }
}

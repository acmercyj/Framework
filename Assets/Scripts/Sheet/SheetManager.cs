/**
 * 描述：表格数据管理
 */

using Sheet;
using System.Collections.Generic;
using Base.Debug;
using Base.Common;

public class SheetManager : Singleton<SheetManager>
{
    /// <summary>
    /// 以id为key存储的表格
    /// sheetMap["Unit"][1001]
    /// </summary>
    private Dictionary<string, Dictionary<int, object>> sheetMap;

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        sheetMap = new Dictionary<string, Dictionary<int, object>>();
        InitUnitInfo();
    }

    /// <summary>
    /// 根据表名和id获得表格数据
    /// </summary>
    public T GetSheetInfo<T>(int id)
    {
        string name = typeof(T).ToString();
        if (sheetMap.ContainsKey(name))
        {
            var dict = sheetMap[name];
            if (dict.ContainsKey(id))
            {
                return (T)dict[id];
            }
            else
            {
                Debugger.LogError("{0} id Not Exist!", id);
            }

        }
        else
        {
            Debugger.LogError("{0} Not Exist!");
        }
        return default(T);
    }

    /// <summary>
    /// 初始化单位表
    /// </summary>
    private void InitUnitInfo()
    {
        var sheet = new Dictionary<int, object>();
        sheetMap.Add("Sheet.UnitTable", sheet);
        var items = SheetUtil.GetSheetInfo<UnitTable_ARRAY>("UnitTable").items;
        items.ForEach(item => sheet[item.id] = item);
    }
}

/**
 * 配置定义
 */

using ProtoBuf;
using UnityEngine;

[ProtoContract]
public class AppConfig
{
    [ProtoMember(1)]
    public string Version = "1.0.0";
    [ProtoMember(2)]
    public string Language = "CN";
    [ProtoMember(3)]
    public bool EnableBgMusic = true;

    //==========================================================================
    private static AppConfig mValue = new AppConfig();
    public static AppConfig Value { get { return mValue; } }
    public readonly static string Path = Application.persistentDataPath + "/AppConfig.data";
    //==========================================================================

    /// <summary>
    /// 初始化
    /// </summary>
    public static void Init()
    {
        //if (!FileUtils.Exists(Path))
        //{
        //    Save();
        //    return;
        //}

        //byte[] data = FileUtils.ReadFile(Path);
        //if (data != null && data.Length > 0)
        //{
        //    var config = PBSerializer.NDeserialize<AppConfig>(data);
        //    if (config != null)
        //    {
        //        mValue = config;
        //    }
        //}
    }

    /// <summary>
    /// 保存
    /// </summary>
    public static void Save()
    {
        //if (mValue != null)
        //{
        //    var data = PBSerializer.NSerialize<AppConfig>(mValue);
        //    FileUtils.SaveFile(Path, data);
        //}
    }
}




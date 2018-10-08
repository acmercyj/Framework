/**
 * 配置定义
 */

using ProtoBuf;
using UnityEngine;
using Base.Utils;

[ProtoContract]
public class AppConfig
{
    [ProtoMember(1)]
    public string Version = "1.0.0";
    [ProtoMember(2)]
    public string Language = "EN";
    [ProtoMember(3)]
    public bool EnableBgMusic = true;
    [ProtoMember(4)]
    public bool EnableSound = true;

    private static string path = Application.persistentDataPath + "/AppConfig.bytes";
    //==========================================================================
    public static AppConfig Value { get; private set; }
    //==========================================================================

    /// <summary>
    /// 初始化
    /// </summary>
    public static void Init()
    {
        Value = new AppConfig();
        if (FileUtil.Exists(path))
        {
            var data = FileUtil.ReadFile(path);
            if (data != null && data.Length > 0)
            {
                var config = ProtobufUtil.NDeserialize<AppConfig>(data);
                if (config != null) Value = config;
            }
        }
        else
        {
            Save();
        }
    }

    /// <summary>
    /// 保存
    /// </summary>
    public static void Save()
    {
        if (Value != null)
        {
            var data = ProtobufUtil.NSerialize<AppConfig>(Value);
            FileUtil.SaveFile(path, data);
        }
    }
}




/**
 * 描述：表格读取工具
 */

using ProtoBuf;
using System.IO;
using UnityEngine;

public class SheetUtil
{
    /// <summary>
    /// 获得表格数据
    /// </summary>
    public static T GetSheetInfo<T>(string fileName)
    {
        FileStream fileStream;
        fileStream = GetSheetFileStream(fileName);
        if (fileStream != null)
        {
            T t = Serializer.Deserialize<T>(fileStream);
            fileStream.Close();
            return t;
        }

        return default(T);
    }

    /// <summary>
    /// 获得表格文件流
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private static FileStream GetSheetFileStream(string fileName)
    {
        string filePath = GetSheetPath(fileName);
        if (File.Exists(filePath))
        {
            FileStream fileStream = File.OpenRead(filePath);
            return fileStream;
        }

        return null;
    }

    /// <summary>
    /// 获得表格路径
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private static string GetSheetPath(string fileName)
    {
        return Application.streamingAssetsPath + "/Sheet/" + fileName + ".bytes";
    }
}


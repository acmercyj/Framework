/**
 * 描述：文件工具类
 */

using System;
using System.IO;

namespace Base.Utils
{
    using Debug;

    public class FileUtil
    {
        /// <summary>
        /// 读取文件
        /// </summary>
        public static byte[] ReadFile(string fullpath)
        {
            byte[] buffer = null;
            if (File.Exists(fullpath))
            {
                FileStream fs = null;
                try
                {
                    fs = File.OpenRead(fullpath);
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                }
                catch (Exception e)
                {
                    Debugger.LogError("ReadFile() Path:{0}, Error:{1}", fullpath, e.Message);
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
            }
            else
            {
                Debugger.LogError("ReadFile() File is Not Exist:{0}", fullpath);
            }
            return buffer;
        }

        /// <summary>
        /// 保存数据到文件
        /// </summary>
        public static int SaveFile(string fullpath, byte[] content)
        {
            if (content == null)
                content = new byte[0];

            string dir = PathUtil.GetParentDir(fullpath);
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch (Exception e)
                {
                    Debugger.LogError("SaveFile() CreateDirectory Error! Dir:{0}, Error:{1}", dir, e.Message);
                    return -1;
                }
            }

            FileStream fs = null;
            try
            {
                fs = new FileStream(fullpath, FileMode.Create, FileAccess.Write);
                fs.Write(content, 0, content.Length);
            }
            catch (Exception e)
            {
                Debugger.LogError("SaveFild() Path:{0}, Error{1}", fullpath, e.Message);
                fs.Close();
                return -1;
            }

            fs.Close();
            return content.Length;
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        public static bool Exists(string fullpath)
        {
            return File.Exists(fullpath);
        }
    }
}




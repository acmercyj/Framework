/**
 * 描述：路径工具类
 */

namespace Base.Utils
{
    public class PathUtil
    {
        public static readonly string[] PathHeadDefine = { "jar://", "jar:file:///", "file:///", "http://", "https://" };

        /// <summary>
        /// 获得文件的目录
        /// </summary>
        public static string GetParentDir(string path)
        {
            string parent = "", child = "";
            SplitPath(path, ref parent, ref child);
            return parent;
        }

        /// <summary>
        /// 分割路径
        /// </summary>
        /// <param name="bSplitExt">是否分割后缀</param>
        public static string SplitPath(string path, ref string parent, ref string child, bool bSplitExt = false)
        {
            string ext = "";
            string head = SplitPath(path, ref parent, ref child, ref ext);
            return head;
        }

        /// <summary>
        /// 分割路径
        /// </summary>
        public static string SplitPath(string path, ref string parent, ref string child, ref string ext)
        {
            string head = GetPathHead(path);

            int index = path.LastIndexOf("/");
            int index2 = path.LastIndexOf("\\");
            index = System.Math.Max(index, index2);

            if (index == head.Length - 1)
            {
                parent = "";
                child = parent;
            }
            else
            {
                parent = path.Substring(0, index);
                child = path.Substring(index + 1);
            }

            index = child.LastIndexOf(".");
            if (index >= 0)
            {
                ext = child.Substring(index + 1);
                child = child.Substring(0, index);
            }

            return head;
        }

        /// <summary>
        /// 检测路径开头
        /// </summary>
        public static string GetPathHead(string path)
        {
            for (int i = 0; i < PathHeadDefine.Length; i++)
            {
                if (path.StartsWith(PathHeadDefine[i]))
                {
                    return PathHeadDefine[i];
                }
            }

            return "";
        }
    }
}

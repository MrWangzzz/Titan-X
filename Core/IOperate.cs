using System;
using System.Collections;
using System.IO;
using System.Text;

using UnityEngine;
namespace TitanX
{
    public class IOperate : Singleton<IOperate>
    {
        /// <summary>
        /// 读取Txt文件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList ResourcesFile(string name)
        {
            //TextAsset text = Resources.Load(name) as TextAsset;
            var text = File.OpenText(PathManger.GetPath+ PathManger.EditorCfg + name+".txt");
            string s = "";
            ArrayList al = new ArrayList();
            while ((s = text.ReadLine()) != null)
            {
                al.Add(s);
            }
            return al;
        }
 

        /// <summary>创建文件</summary>
        /// <param name="path">路径</param>
        /// <param name="name">文件名</param>
        /// <param name="Data">数据</param>
        public void CreateFile(string Data, string name = "", string _path = "")
        {
            try
            {
                string path = PathManger.GetPath+PathManger.UIScriptsPath;
                if (name != "")
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                }
                FileStream fs = new FileStream(name == "" ? path : path + "//" + name, FileMode.Create, FileAccess.Write);
                byte[] bs = Encoding.UTF8.GetBytes(Data);
                fs.Write(bs, 0, bs.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                DebugEX.Log("Tip", ex.Message);
            }
        }
    }
}

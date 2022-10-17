using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using Excel;
using Newtonsoft.Json.Linq;
using System;
namespace TitanX
{
    public class ExcelEditor
    {

        /// <summary>
        /// 表格的存放位置
        /// </summary>
        static string configPath = "../Doc/Excel";

        /// <summary>
        /// 模板存放位置
        /// </summary>
        static string scriptsPath
        {
            get
            {
                return PathManger.GetPath + PathManger.JsonScriptsPath;
            }
        }

        /// <summary>
        /// json文件存放位置
        /// </summary>
        static string jsonPath
        {
            get
            {
                return PathManger.GetPath + PathManger.JsonPath;
            }
        }

        /// <summary>
        /// 表格数据列表
        /// </summary>
        static List<TableData> dataList = new List<TableData>();



        /// <summary>
        /// 遍历文件夹，读取所有表格
        /// </summary>
        [UnityEditor.MenuItem("Tools / ReadExcel")]
        public static void ReadExcel()
        {
            RemoveUnnecessary();
            if (Directory.Exists(configPath))
            {
                //获取指定目录下所有的文件
                DirectoryInfo direction = new DirectoryInfo(configPath);
                FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
                Debug.Log("fileCount:" + files.Length);

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.EndsWith(".meta") || !files[i].Name.EndsWith(".xlsx"))
                    {
                        continue;
                    }
                    Debug.Log("FullName:" + files[i].FullName);
                    LoadData(files[i].FullName, files[i].Name);
                }
                //刷新项目
                UnityEditor.AssetDatabase.Refresh();
            }
            else
            {
                Debug.LogError("ReadExcel configPath not Exists!");
            }
        }
        /// <summary>
        /// 删除被启用的json与模板
        /// </summary>
        private static void RemoveUnnecessary()
        {
            Directory.Delete(scriptsPath, true);
            Directory.Delete(jsonPath, true);

        }



        /// <summary>
        /// 读取表格并保存脚本及json
        /// </summary>
        static void LoadData(string filePath, string fileName)
        {
            //获取文件流
            FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            //生成表格的读取
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            // 表格数据全部读取到result里(引入：DataSet（using System.Data;）
            DataSet result = excelDataReader.AsDataSet();

            CreateTemplate(result, fileName);

            CreateJson(result, fileName);
        }

        /// <summary>
        /// 生成json文件
        /// </summary>
        static void CreateJson(DataSet result, string fileName)
        {
            // 获取表格有多少列 
            int columns = result.Tables[0].Columns.Count;
            // 获取表格有多少行 
            int rows = result.Tables[0].Rows.Count;

            TableData tempData;
            string value;
            JArray array = new JArray();

            //第一行为表头，第二行为类型 ，第三行为字段名 不读取
            for (int i = 3; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // 获取表格中指定行指定列的数据 
                    value = result.Tables[0].Rows[i][j].ToString();

                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }
                    tempData = new TableData();
                    tempData.type = result.Tables[0].Rows[1][j].ToString();
                    tempData.fieldName = result.Tables[0].Rows[2][j].ToString();
                    tempData.value = value;

                    dataList.Add(tempData);
                }

                if (dataList != null && dataList.Count > 0)
                {
                    JObject tempo = new JObject();
                    foreach (var item in dataList)
                    {
                        switch (item.type)
                        {
                            case "string":
                                tempo[item.fieldName] = GetValue<string>(item.value);
                                break;
                            case "int":
                                tempo[item.fieldName] = GetValue<int>(item.value);
                                break;
                            case "float":
                                tempo[item.fieldName] = GetValue<float>(item.value);
                                break;
                            case "bool":
                                tempo[item.fieldName] = GetValue<bool>(item.value);
                                break;
                            case "string[]":
                                tempo[item.fieldName] = new JArray(GetList<string>(item.value, ','));
                                break;
                            case "int[]":
                                tempo[item.fieldName] = new JArray(GetList<int>(item.value, ','));
                                break;
                            case "float[]":
                                tempo[item.fieldName] = new JArray(GetList<float>(item.value, ','));
                                break;
                            case "bool[]":
                                tempo[item.fieldName] = new JArray(GetList<bool>(item.value, ','));
                                break;
                        }
                    }

                    if (tempo != null)
                        array.Add(tempo);
                    dataList.Clear();
                }
            }

            JObject o = new JObject();
            o["datas"] = array;
            o["version"] = "20200331";
            fileName = fileName.Replace(".xlsx", "");
            var path = jsonPath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText(path + fileName + ".json", o.ToString());
        }


        /// <summary>
        /// 字符串拆分列表
        /// </summary>
        static List<T> GetList<T>(string str, char spliteChar)
        {
            string[] ss = str.Split(spliteChar);
            int length = ss.Length;
            List<T> arry = new List<T>(ss.Length);
            for (int i = 0; i < length; i++)
            {
                arry.Add(GetValue<T>(ss[i]));
            }
            return arry;
        }

        static T GetValue<T>(object value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// 生成实体类模板
        /// </summary>
        static void CreateTemplate(DataSet result, string fileName)
        {
            if (!Directory.Exists(scriptsPath))
            {
                Directory.CreateDirectory(scriptsPath);
            }

            field = "";
            for (int i = 0; i < result.Tables[0].Columns.Count; i++)
            {
                string typeStr = result.Tables[0].Rows[1][i].ToString();
                typeStr = typeStr.ToLower();
                if (typeStr.Contains("[]"))
                {
                    typeStr = typeStr.Replace("[]", "");
                    typeStr = string.Format(" List<{0}>", typeStr);
                }

                string nameStr = result.Tables[0].Rows[2][i].ToString();
                if (string.IsNullOrEmpty(typeStr) || string.IsNullOrEmpty(nameStr)) continue;
                field += "public " + typeStr + " " + nameStr + " { get; set; }\r\t\t";
            }

            fileName = fileName.Replace(".xlsx", "");
            string tempStr = Eg_str;
            tempStr = tempStr.Replace("@Name", fileName);
            tempStr = tempStr.Replace("@File1", field);
            File.WriteAllText(scriptsPath + fileName + ".cs", tempStr);

        }

        /// <summary>
        /// 字段
        /// </summary>
        static string field;

        /// <summary>
        /// 实体类模板
        /// </summary>
        static string Eg_str =

            "using System.Collections.Generic;\r" +
            "using UnityEngine;\r" +
            "using Newtonsoft.Json;\r\r" +
            "using TitanX;\r\r" +
            "public class @Name  {\r\r\t\t" +
            "@File1 \r\t\t" +
            "public static string configName = \"@Name\";\r\t\t" +
            "public static @Name config { get; set; }\r\t\t" +
            "public string version { get; set; }\r\t\t" +
            "public List<@Name> datas { get; set; }\r\r\t\t" +
            "public static @Name Get(int id)\r\t\t{\r\t\t\tif (config == null)\r\t\t\t{\r\t\t\tconfig= ConfigManger.Instance.Readjson<@Name>(configName);\r\t\t\t}\r\t\t\tforeach (var item in config.datas)\r\t\t\t{\r\t\t\t\tif (item.id == id)\r\t\t\t\t{ \r\t\t\t\t\treturn item;\r\t\t\t\t}\r\t\t\t}\r\t\t\treturn null;\r\t\t}\r"
             + "\r}";
    }

    public struct TableData
    {
        public string fieldName;
        public string type;
        public string value;

        public override string ToString()
        {
            return string.Format("fieldName:{0} type:{1} value:{2}", fieldName, type, value);
        }
    }
}
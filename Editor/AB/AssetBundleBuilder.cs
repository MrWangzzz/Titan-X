using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace TitanX
{
    public class AssetBundleBuilder
    {

        static Dictionary<string, AssetInfo> assetInfoDict = new Dictionary<string, AssetInfo>();

        private static string curRootAsset = string.Empty;
        private static float curProgress = 0f;

        [MenuItem("Assetbundle / SetAssetbundleName", false, 2001)]
        public static void SetABNames()
        {

            string path = Application.dataPath + "/Resources";
            if (path == null)
            {
                Debug.LogWarning("请先选择目标文件夹");
                return;
            }
            Debug.Log("设置ab名称");
            GetAllAssets(path);
        }

        [MenuItem("Assetbundle / buildAssetBundle / Android", false, 2002)]
        public static void BuildAssetBundleAndroid()
        {
            BuildAssetBundle(BuildTarget.Android);
        }

        [MenuItem("Assetbundle / buildAssetBundle / IOS", false, 2003)]
        public static void BuildAssetBundleIos()
        {
            BuildAssetBundle(BuildTarget.iOS);
        }

        [MenuItem("Assetbundle / buildAssetBundle / Win64", false, 2005)]
        public static void BuildAssetBundleWin64()
        {
            BuildAssetBundle(BuildTarget.StandaloneWindows64);
        }

        static void BuildAssetBundle(BuildTarget target)
        {
            string outputPath = Application.dataPath + "/" + PathManger.AssetDir;
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);
            BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.DeterministicAssetBundle, target);
        }

        [MenuItem("Assetbundle / ClearAllAssetbundelname", false, 2005)]
        public static void CleaarAllABNames()
        {
            string[] abnames = AssetDatabase.GetAllAssetBundleNames();
            foreach (var n in abnames)
            {
                AssetDatabase.RemoveAssetBundleName(n, true);
            }
        }

        public static void GetAllAssets(string rootDir)
        {
            assetInfoDict.Clear();

            DirectoryInfo dirinfo = new DirectoryInfo(rootDir);
            FileInfo[] fs = dirinfo.GetFiles("*.*", SearchOption.AllDirectories);
            int ind = 0;
            foreach (var f in fs)
            {
                curProgress = (float)ind / (float)fs.Length;
                curRootAsset = "正在分析依赖：" + f.Name;
                EditorUtility.DisplayProgressBar(curRootAsset, curRootAsset, curProgress);
                ind++;
                int index = f.FullName.IndexOf("Assets");
                if (index != -1)
                {
                    string assetPath = f.FullName.Substring(index);
                    Object asset = AssetDatabase.LoadMainAssetAtPath(assetPath);
                    string upath = AssetDatabase.GetAssetPath(asset);

                    if (assetPath.StartsWith("Assets") &&
                        !(asset is MonoScript) &&
                        !(asset is LightingDataAsset) &&
                        asset != null
                    )
                    {
                        if (!assetInfoDict.ContainsKey(assetPath))
                        {
                            AssetInfo info = new AssetInfo(upath, true);
                            //标记一下是文件夹下根资源
                            info.IsIndependentAsset = true;
                            CreateDeps(info);
                        }
                        else
                        {
                            assetInfoDict[assetPath].IsIndependentAsset = true;
                        }
                    }
                    EditorUtility.UnloadUnusedAssetsImmediate();
                }
                EditorUtility.UnloadUnusedAssetsImmediate();
            }
            EditorUtility.ClearProgressBar();

            int setIndex = 0;
            foreach (KeyValuePair<string, AssetInfo> kv in assetInfoDict)
            {
                EditorUtility.DisplayProgressBar("正在设置ABName", kv.Key, (float)setIndex / (float)assetInfoDict.Count);
                setIndex++;
                AssetInfo a = kv.Value;
                a.SetAssetBundleName(2);
            }
            EditorUtility.ClearProgressBar();
            EditorUtility.UnloadUnusedAssetsImmediate();
            AssetDatabase.SaveAssets();
        }
        /// <summary>
        /// 递归分析每个所被依赖到的资源
        /// </summary>
        /// <param name="self"></param>
        /// <param name="parent"></param>
        static void CreateDeps(AssetInfo self, AssetInfo parent = null)
        {
            if (self.HasParent(parent))
                return;
            if (assetInfoDict.ContainsKey(self.assetPath) == false)
            {
                assetInfoDict.Add(self.assetPath, self);
            }
            self.AddParent(parent);

            Object[] deps = EditorUtility.CollectDependencies(new Object[] { self.GetAsset() });
            for (int i = 0; i < deps.Length; i++)
            {
                Object o = deps[i];
                if (o is MonoScript || o is LightingDataAsset)
                    continue;
                string path = AssetDatabase.GetAssetPath(o);
                if (path == self.assetPath)
                    continue;
                if (path.StartsWith("Assets") == false)
                    continue;

                AssetInfo info = null;
                if (assetInfoDict.ContainsKey(path))
                {
                    info = assetInfoDict[path];
                }
                else
                {
                    info = new AssetInfo(path);
                    assetInfoDict.Add(path, info);
                }
                EditorUtility.DisplayProgressBar(curRootAsset, path, curProgress);
                CreateDeps(info, self);
            }
            EditorUtility.UnloadUnusedAssetsImmediate();
        }

        static string GetSelectedAssetPath()
        {
            var selected = Selection.activeObject;
            if (selected == null)
            {
                return null;
            }
            Debug.Log(selected.GetType());
            if (selected is DefaultAsset)
            {
                string path = AssetDatabase.GetAssetPath(selected);
                Debug.Log("选中路径： " + path);
                return path;
            }
            else
            {
                return null;
            }
        }
    }
}
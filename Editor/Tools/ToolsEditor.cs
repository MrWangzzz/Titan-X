using System.Collections;
using UnityEditor;
using System.IO;
using TitanX;
using UnityEngine.SceneManagement;
using System;
using UnityEditor.SceneTemplate;
using UnityEditor.SceneManagement;
using UnityEditor.ProjectWindowCallback;
using UnityEditor.Experimental;
using UnityEngine;

public class ToolsEditor : EditorWindow
{
    [MenuItem("Tools/InitProject/初始化项目(自项目建立起只需要点一次)")]
    public static void AddFileInfo()
    {
        ArrayList list = IOperate.Instance.ResourcesFile("FileList");
        for (int i = 0; i < list.Count; i++)
        {
            CreateDirectory(list[i].ToString());
        }
        AssetDatabase.Refresh();

    }
    [MenuItem("Assets/Create/创建MapScene", priority =0)]
    public static void CreatMapScene() 
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, CreateInstance<SceneTools.DoCreateFolder>(), "New Scene", EditorGUIUtility.IconContent(EditorResources.folderIconName).image as Texture2D, null);
    }



    [MenuItem("Assets/Create/创建UI.cs", false, 1)]
    public static void CreateDialog()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, CreateInstance<UITools.DoCreateFolder>(), "New Scripts", EditorGUIUtility.IconContent(EditorResources.folderIconName).image as Texture2D, null);
       
    }

   
    private static void CreateDirectory(string name)
    {
        string path = $"{PathManger.GetPath}{name}";
        if (!Directory.Exists(path))
        {
            DebugEX.Log("创建文件路径", path);
            Directory.CreateDirectory(path);
        }
        else
        {
            DebugEX.Log("路径已存在", path);
        }
    }
}

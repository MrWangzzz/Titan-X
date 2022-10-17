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
    [MenuItem("Tools/InitProject/��ʼ����Ŀ(����Ŀ������ֻ��Ҫ��һ��)")]
    public static void AddFileInfo()
    {
        ArrayList list = IOperate.Instance.ResourcesFile("FileList");
        for (int i = 0; i < list.Count; i++)
        {
            CreateDirectory(list[i].ToString());
        }
        AssetDatabase.Refresh();

    }
    [MenuItem("Assets/Create/����MapScene", priority =0)]
    public static void CreatMapScene() 
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, CreateInstance<SceneTools.DoCreateFolder>(), "New Scene", EditorGUIUtility.IconContent(EditorResources.folderIconName).image as Texture2D, null);
    }



    [MenuItem("Assets/Create/����UI.cs", false, 1)]
    public static void CreateDialog()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, CreateInstance<UITools.DoCreateFolder>(), "New Scripts", EditorGUIUtility.IconContent(EditorResources.folderIconName).image as Texture2D, null);
       
    }

   
    private static void CreateDirectory(string name)
    {
        string path = $"{PathManger.GetPath}{name}";
        if (!Directory.Exists(path))
        {
            DebugEX.Log("�����ļ�·��", path);
            Directory.CreateDirectory(path);
        }
        else
        {
            DebugEX.Log("·���Ѵ���", path);
        }
    }
}

using System.IO;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace TitanX
{
    public  class SceneTools : EditorWindow
    {
         public class DoCreateFolder : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {

                Scene newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
                EditorSceneManager.SetActiveScene(newScene);
                string gameScenePath = pathName + ".unity";
                EditorSceneManager.SaveScene(newScene, gameScenePath);
                AssetDatabase.SaveAssets();
                RefreshAllScene();
                ScenesMenuBuild.UpdateList();
            }
        }


         static void RefreshAllScene()
        {
            string path = Path.Combine(PathManger.GetPath, PathManger.MapSavePath);
            string[] files = Directory.GetFiles(path, "*.unity", SearchOption.AllDirectories);
            EditorBuildSettingsScene[] scenes = new EditorBuildSettingsScene[files.Length + 1];
            for (int i = 0; i < files.Length; ++i)
            {
                int index = files[i].IndexOf("Assets");
                string _path = files[i].Remove(0, index);
                scenes[i + 1] = new EditorBuildSettingsScene(_path, true);
            }
            var str = "Assets/Scenes\\Main.unity";
            scenes[0] = new EditorBuildSettingsScene(str, true);
            EditorBuildSettings.scenes = scenes;
        }


    }
}

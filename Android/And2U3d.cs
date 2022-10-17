using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And2U3d : MonoBehaviour
{
    public static And2U3d Instacne
    {
        get
        {
            if (instacne == null)
            {
                GameObject clone = new GameObject();
                clone.name = "u3d2Android";
                instacne = clone.AddComponent<And2U3d>();
                DontDestroyOnLoad(clone);
            }
            return instacne;
        }
    }
    private static And2U3d instacne;
    private Dictionary<AndObjType, AndroidJavaObject> activitys=new Dictionary<AndObjType, AndroidJavaObject>();
    private AndroidJavaObject unityMainactive;

    public void Init() 
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityMainactive = jc.GetStatic<AndroidJavaObject>("currentActivity");

    }

    /// <summary>
    /// 获取U3D的主MainActive
    /// </summary>
    /// <returns></returns>
    public AndroidJavaObject GetU3DMainActive() 
    {
        return unityMainactive;
    }


}
public enum AndObjType  
{
   Test
}

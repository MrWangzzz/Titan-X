﻿
using UnityEngine;
namespace TitanX
{
    public class Singleton<T> where T : new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = new T();
                return instance;
            }
        }
    }

    public class SingletonGetMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance = null;
        public static T Instance
        {
            get
            {
                return instance;
            }
        }
        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = GetComponent<T>();
            }
        }
    }
    public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {

        private static string MonoSingletionName = "MonoSingletionRoot";
        private static GameObject MonoSingletionRoot;
        private static T instance;

        public static T Instance
        {
            get
            {
                if (MonoSingletionRoot == null)//如果是第一次调用单例类型就查找所有单例类的总结点
                {
                    MonoSingletionRoot = GameObject.Find(MonoSingletionName);
                    if (MonoSingletionRoot == null)//如果没有找到则创建一个所有继承MonoBehaviour单例类的节点
                    {
                        MonoSingletionRoot = new GameObject();
                        MonoSingletionRoot.name = MonoSingletionName;
                        DontDestroyOnLoad(MonoSingletionRoot);//防止被销毁
                    }
                }
                //为空表示第一次获取当前单例类
                if (instance == null)
                {
                    instance = MonoSingletionRoot.GetComponent<T>();
                    if (instance == null)
                    {
                        instance = MonoSingletionRoot.gameObject.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        private void Awake()
        {
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        public virtual void OnAwake() { }

        public virtual void OnStart() { }
    }

}
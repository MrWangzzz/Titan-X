using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
namespace TitanX
{
    /// <summary>
    /// AB的信息
    /// </summary>
    public class AssetBundleInfo
    {
        public AssetBundle m_AssetBundle;
        public int m_ReferencedCount;
        public AssetBundleInfo(AssetBundle assetBundle)
        {
            m_AssetBundle = assetBundle;
            m_ReferencedCount = 0;
        }
    }

    /// <summary>
    /// 资源加载管理类
    /// </summary>
    public class ResourceManger : SingletonMono<ResourceManger>
    {
        private Dictionary<string, AssetBundleInfo> loadEndAssetBundles = new Dictionary<string, AssetBundleInfo>();

        public T CreateObjectInRes<T>(string path) where T : Object
        {
            return Resources.Load(path) as T;
        }

        #region 同步加载
        public GameObject CreatObject(string assetPath) 
        {
            return Instantiate(LoadObject<GameObject>(assetPath));
        }
        public T LoadObject<T>(string assetPath) where T : Object
        {

            if (GameCfg.Instance.isLoadAb)
            {
                int index = assetPath.LastIndexOf('/');
                return Abload<T>(assetPath, assetPath.Substring(index + 1, assetPath.Length - index - 1));
            }
            else
            {
                return Resources.Load<T>(assetPath);
            }
        }
        private T Abload<T>(string assetPath, string name) where T : Object
        {
            assetPath = assetPath.Replace("/", ".");
            var path = PathManger.DataPath + PathManger.ASSETS_LOAD_PREFIX + assetPath + PathManger.ExtName;
            AssetBundle ab = AssetBundle.LoadFromFile(path);
            T obj = ab.LoadAsset(name, typeof(GameObject)) as T;
            ab.Unload(false);
            return obj;
        }
        #endregion
        #region 异步加载
        public void CreatObjectSync(string assetPath,Action<bool,GameObject> ac)
        {
            LoadObjectSync(assetPath,ac);
        }

    
        public void LoadObjectSync<T>(string assetPath, Action<bool, T> ac) where T : Object
        {

            if (GameCfg.Instance.isLoadAb)
            {
                int index = assetPath.LastIndexOf('/');
                StartCoroutine(AbloadSync(assetPath, assetPath.Substring(index + 1, assetPath.Length - index - 1), ac));
            }
            else
            {
                StartCoroutine(loadSync(assetPath, ac));
            }

        }
        private IEnumerator AbloadSync<T>(string assetPath, string name,Action<bool,T> ac) where T : Object
        {
            assetPath = assetPath.Replace("/", ".");
            var path = PathManger.DataPath + PathManger.ASSETS_LOAD_PREFIX + assetPath + PathManger.ExtName;
            var bundleLoadRequest = AssetBundle.LoadFromFileAsync(path);
            var myLoadedAssetBundle = bundleLoadRequest.assetBundle;
            if (myLoadedAssetBundle == null)
            {
                ac?.Invoke(false, null);
                DebugEX.Log("加载失败",name);
                yield break;
            }
            var assetLoadRequest = myLoadedAssetBundle.LoadAssetAsync<GameObject>(name);
            yield return assetLoadRequest;

            ac?.Invoke(assetLoadRequest!=null, assetLoadRequest.asset as T);
            myLoadedAssetBundle.Unload(false);
        }
        private IEnumerator loadSync<T>(string assetPath, Action<bool, T> ac) where T : Object
        {
            ResourceRequest request = Resources.LoadAsync<T>(assetPath);
            yield return request;
            ac?.Invoke(request!=null, request.asset as T);
        }

        #endregion


    }
}

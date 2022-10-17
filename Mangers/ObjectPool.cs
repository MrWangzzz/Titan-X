using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    /// <summary>
    /// �����
    /// </summary>
    public class ObjectPool : SingletonMono<ObjectPool>
    {
        /// <summary>
        /// ����
        /// </summary>
        public Dictionary<string, List<GameObject>> poolsDict = new Dictionary<string, List<GameObject>>();
        /// <summary>
        /// ȡ������
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public GameObject  OutPool(string poolname)
        {
            //���û��������͵ĳ��Ӿʹ���һ��
            if (!poolsDict.ContainsKey(poolname))
            {
                poolsDict.Add(poolname, new List<GameObject>());
            }

            //�õ�����
            List<GameObject> ObjList;
            poolsDict.TryGetValue(poolname, out ObjList);

            //�ڳ�����Ѱ�ұ����ص���Ϸ����
            GameObject go = null;
            foreach (var obj in ObjList)
            {
                if (!obj.activeSelf)
                {
                    go = obj;
                }
            }

            if (go == null)//���������ص���Ϸ����
            {
                go = ResourceManger.Instance.CreatObject(PathManger.UIprefab + poolname);
                ObjList.Add(go);
            }
            else//�������ص���Ϸ����
            {
                go.SetActive(true);
            }
            //go. transform. localEulerAngles(Vector3. zero);
            go.name = go.name.Replace("(Clone)", "");
            return go;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="go"></param>
        public void EnterPool(GameObject go)
        {
            foreach (List<GameObject> list in poolsDict.Values)
            {
                if (list.Contains(go) && go.activeSelf)
                {
                    go.SetActive(false);
                }
            }
        }

        /// <summary>
        /// ���ٳ���
        /// </summary>
        /// <param name="name"></param>
        public void ClearPool(string name)
        {
            if (poolsDict.ContainsKey(name))
            {
                foreach (GameObject go in poolsDict[name])
                {
                    Destroy(go);
                }
                poolsDict.Remove(name);
            }
        }
    }
}
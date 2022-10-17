using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
namespace TitanX
{
    public class UIManger : SingletonGetMono<UIManger>
    {


        private Transform parentCanvas;
        private Dictionary<string, UIBase> uis = new Dictionary<string, UIBase>();

        public Transform GetParentCanvas
        {
            get
            {
                if (parentCanvas == null)
                {
                    parentCanvas = GetComponent<Transform>();
                }
                return parentCanvas;
            }
        }

        public void ShowUI(string UiName, params object[] dialogArgs)
        {
            if (!uis.ContainsKey(UiName))
            {
                GameObject go = LoadUiRes(UiName);
                go.transform.SetParent(GetParentCanvas);
                UIBase pb = go.GetComponent<UIBase>();
                go.transform.localPosition(0).localScale(1).localEulerAngles(0);
                if (pb == null)
                {
                    Type mType = Type.GetType(UiName.ToString());
                    pb = go.AddComponent(mType) as UIBase;
                    pb.FindObj();
                    pb.AddEvent();
                }
                uis.Add(UiName, pb);
                pb.Init(dialogArgs);

            }
        }
        public void CloseUI(string UiName)
        {
            if (uis.ContainsKey(UiName))
            {
                uis[UiName].OnDeath();

                ObjectPool.Instance.EnterPool(uis[UiName].gameObject);
                uis.Remove(UiName);
            }
        }
        public void DestroyUI(string UiName)
        {
            if (uis.ContainsKey(UiName))
            {
                var ui = uis[UiName];
                ui.OnDeath();
                Destroy(ui.gameObject);
                uis.Remove(UiName);
            }
        }
        private GameObject LoadUiRes(string name)
        {
            GameObject go = ObjectPool.Instance.OutPool(name);
            if (go == null)
            {
                go = ResourceManger.Instance.CreatObject(String.Format("UI/{0}", name));
                go.name = name;
            }
            return go;
        }
    }
}

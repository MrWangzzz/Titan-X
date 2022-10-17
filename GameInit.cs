using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    public  class Titan:MonoBehaviour
    {
        /// <summary>
        /// ��ʼ����ܹ���
        /// </summary>
        public static void Init()
        {
            InitUiModeule();
        }
        private static void InitUiModeule() 
        {
            GameObject ui = ResourceManger.Instance.CreateObjectInRes<GameObject>("TUI_Canvas");
            GameObject iui =Instantiate(ui);
            iui.name = "TUI_Canvas";
            iui.GetComponent<Canvas>().worldCamera = Camera.main;
        }
        
    }
}

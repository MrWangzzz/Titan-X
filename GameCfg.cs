using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    public class GameCfg : GameCfgBase
    {
     

        public void Start()
        {
            Titan.Init();
        }
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) 
            {
                ISceneManger.Instance.LoadMap("Map0");
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                //ResourceManger.Instance.CreatObjectSync(String.Format("UI/{0}", "UI_Load"), (success, obj) => {

                //    DebugEX.Log(success, obj.name);

                //});

                // UIManger.Instance.ShowUI("UI_Load");
                DebugEX.LogError(ConfigManger.Instance.Readjson<tests>("tests").id);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                UIManger.Instance.CloseUI("UI_Load");
            }
        }
    }
}

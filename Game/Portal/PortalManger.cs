using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    public class PortalManger : Singleton<PortalManger>
    {
        public Dictionary<int, PortalBase> NowScencePortal = new Dictionary<int, PortalBase>();



        public void LoadPortalInScene(int id, PortalBase portal) 
        {

        }

        public void UnloadPortalInScene() 
        {
            NowScencePortal.Clear();
            DebugEX.Log("卸载当前场景的传送门");
        }
}
}

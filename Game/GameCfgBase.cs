using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    public class GameCfgBase : SingletonGetMono<GameCfgBase>
    {
        [Header("是否使用AB包资源")]
        public bool isLoadAb;
        public override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
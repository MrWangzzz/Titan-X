using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    public class GameCfgBase : SingletonGetMono<GameCfgBase>
    {
        [Header("�Ƿ�ʹ��AB����Դ")]
        public bool isLoadAb;
        public override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
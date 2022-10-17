using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    /// <summary>
    /// 战斗逻辑基类
    /// </summary>
    public class BattleLogic
    {

        /// <summary>
        /// 开始时调用
        /// </summary>
        public virtual void Start() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        ///// <summary>
        ///// 出生时
        ///// </summary>
        //public virtual void OnEnemyBorn() { }
        ///// <summary>
        ///// 死亡时
        ///// </summary>
        //public virtual void OnEnemyDead() { }
        ///// <summary>
        ///// 玩家死亡
        ///// </summary>
        //public virtual void OnPlayerDead() { }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    public class AtackAction : MonoBehaviour
    {
        public DamageType DamageType;   //伤害类型
        public DmgSource DmgSource; //伤害来源
        /// <summary>
        /// 目标
        /// </summary>
        public UnitMono Target;

        /// <summary>
        /// 所有者
        /// </summary>
        public UnitMono Owner;

        /// <summary>
        /// 生命周期
        /// </summary>
        public float LifeTime;

        public void Update()
        {
            if (LifeTime > 0)
            {
                LifeTime -= Time.deltaTime;
            }
            else
            {
                OnDeath();
            }
        }


        private void OnDeath()
        {

        }





    }
    public class AtackActionFactory
    {
        /// <summary>
        /// 创建一个攻击行为
        /// </summary>
        /// <param name="Owner"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static AtackAction CreatAtack(UnitMono Owner, UnitMono target)
        {
            AtackAction atack = new AtackAction();
            atack.Target = target;
            atack.Owner = Owner;
            return atack;
        }
        // private void 
    }
}
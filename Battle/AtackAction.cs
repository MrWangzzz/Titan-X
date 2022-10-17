using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    public class AtackAction : MonoBehaviour
    {
        public DamageType DamageType;   //�˺�����
        public DmgSource DmgSource; //�˺���Դ
        /// <summary>
        /// Ŀ��
        /// </summary>
        public UnitMono Target;

        /// <summary>
        /// ������
        /// </summary>
        public UnitMono Owner;

        /// <summary>
        /// ��������
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
        /// ����һ��������Ϊ
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    public abstract class UIBase : MonoBehaviour
    {

        /// <summary>
        /// �����ʼ��(��ֹ����ע���¼�)
        /// </summary>
        /// <param name="dialogArgs"></param>
        internal abstract void Init(params object[] dialogArgs);
        /// <summary>
        /// ע���¼�
        /// </summary>
        internal virtual void AddEvent()
        {

        }
        internal virtual void FindObj()
        {

        }
        /// <summary>
        /// ����ʱִ��
        /// </summary>
        internal virtual void OnDeath()
        {

        }

        internal virtual void Close()
        {
            UIManger.Instance.CloseUI(name);
        }
        internal virtual void DestroyUI()
        {
            UIManger.Instance.DestroyUI(name);
        }

    }

}
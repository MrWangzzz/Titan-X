using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX
{
    public abstract class UIBase : MonoBehaviour
    {

        /// <summary>
        /// 界面初始化(禁止用来注册事件)
        /// </summary>
        /// <param name="dialogArgs"></param>
        internal abstract void Init(params object[] dialogArgs);
        /// <summary>
        /// 注册事件
        /// </summary>
        internal virtual void AddEvent()
        {

        }
        internal virtual void FindObj()
        {

        }
        /// <summary>
        /// 销毁时执行
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
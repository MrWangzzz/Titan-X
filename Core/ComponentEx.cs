using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentEx 
{
    /// <summary>
    /// 自身位置信息
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="selfComponent">该物体</param>
    /// <param name="xyz"></param>
    /// <returns> Vector3.one *xyz </returns>
    public static T localPosition<T>(this T selfComponent, float xyz) where T : Component
    {
        selfComponent.transform.localPosition = Vector3.one * xyz;
        return selfComponent;
    }
    /// <summary>
    /// 自身缩放信息
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="selfComponent">该物体</param>
    /// <param name="xyz"></param>
    /// <returns> Vector3.one * xyz </returns>
    public static T localScale<T>(this T selfComponent, float xyz) where T : Component
    {
        selfComponent.transform.localScale = Vector3.one * xyz;
        return selfComponent;
    }
    /// <summary>
    /// 自身角度信息
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="selfComponent">该物体</param>
    /// <param name="xyz"></param>
    /// <returns>  Vector3.one *xyz </returns>
    public static T localEulerAngles<T>(this T selfComponent, float xyz) where T : Component
    {
        selfComponent.transform.localEulerAngles = Vector3.one * xyz;
        return selfComponent;
    }
}

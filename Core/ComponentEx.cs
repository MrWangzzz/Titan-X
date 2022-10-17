using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentEx 
{
    /// <summary>
    /// ����λ����Ϣ
    /// </summary>
    /// <typeparam name="T">����</typeparam>
    /// <param name="selfComponent">������</param>
    /// <param name="xyz"></param>
    /// <returns> Vector3.one *xyz </returns>
    public static T localPosition<T>(this T selfComponent, float xyz) where T : Component
    {
        selfComponent.transform.localPosition = Vector3.one * xyz;
        return selfComponent;
    }
    /// <summary>
    /// ����������Ϣ
    /// </summary>
    /// <typeparam name="T">����</typeparam>
    /// <param name="selfComponent">������</param>
    /// <param name="xyz"></param>
    /// <returns> Vector3.one * xyz </returns>
    public static T localScale<T>(this T selfComponent, float xyz) where T : Component
    {
        selfComponent.transform.localScale = Vector3.one * xyz;
        return selfComponent;
    }
    /// <summary>
    /// ����Ƕ���Ϣ
    /// </summary>
    /// <typeparam name="T">����</typeparam>
    /// <param name="selfComponent">������</param>
    /// <param name="xyz"></param>
    /// <returns>  Vector3.one *xyz </returns>
    public static T localEulerAngles<T>(this T selfComponent, float xyz) where T : Component
    {
        selfComponent.transform.localEulerAngles = Vector3.one * xyz;
        return selfComponent;
    }
}

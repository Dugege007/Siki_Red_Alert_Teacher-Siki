using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工具
 * 创建时间：
 */

public static class UnityTool
{
    public static GameObject FindChild(GameObject parent, string childName)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        Transform child = null;
        bool isFind = false;
        foreach (Transform c in children)
        {
            if (c.name == childName)
            {
                if (isFind)
                {
                    Debug.LogWarning("在游戏物体" + parent + "下存在不止一个子物体：" + childName);
                }
                isFind = true;
                child = c;
                break;
            }
        }

        if (!isFind)
        {
            Debug.LogError("未在" + parent.name + "物体中找到子物体：" + childName);
            return null;
        }
        return child.gameObject;
    }

    public static void Attach(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
        child.transform.localRotation = Quaternion.identity;
    }
}
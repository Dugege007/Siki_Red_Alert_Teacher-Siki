using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：UI工具
 * 创建时间：
 */

public static class UITool
{
    public static T FindChildComponent<T>(GameObject parent, string childName)
    {
        GameObject uiGO = UnityTool.FindChild(parent, childName);
        if (uiGO == null)
            Debug.LogError("在游戏物体" + parent.name + "查找不到" + childName);

        return uiGO.GetComponent<T>();
    }
}
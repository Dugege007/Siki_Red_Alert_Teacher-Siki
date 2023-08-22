using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：策略模式
 * 角色属性变更策略
 * 
 * 创建时间：
 */

public interface IAttrStrategy
{
    int GetExtraHPValue(int lv);
    int GetDmgDescValue(int lv);
    int GetCritDmg(float critRate);
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：策略模式
 * 士兵攻击属性
 * 
 * 创建时间：
 */

public class SoldierAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(float critRate)
    {
        return 0;
    }

    public int GetDmgDescValue(int lv)
    {
        return (lv - 1) * 2;
    }

    public int GetExtraHPValue(int lv)
    {
        return (lv - 1) * 10;
    }
}
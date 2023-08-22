using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：策略模式
 * 敌人攻击属性策略
 * 
 * 创建时间：
 */

public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(float critRate)
    {
        if (Random.Range(0, 1f) <= critRate)
            return (int)(10 * Random.Range(0.5f, 1f));
        return 0;
    }

    public int GetDmgDescValue(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetExtraHPValue(int lv)
    {
        return (lv - 1) * 10;
    }
}
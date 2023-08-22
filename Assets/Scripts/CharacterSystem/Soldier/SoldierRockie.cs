using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式 模板方法模式
 * 下士
 * 
 * 创建时间：
 */

public class SoldierRockie : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("RookieDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("RockieDead");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式 模板方法模式
 * 中士
 * 
 * 创建时间：
 */

public class SoldierSergeant : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("SergeantDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("SergeantieDead");
    }
}
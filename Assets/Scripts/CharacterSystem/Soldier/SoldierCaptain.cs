using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式 模板方法模式
 * 上尉
 * 
 * 创建时间：
 */

public class SoldierCaptain : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("CaptainDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("CaptainDead");
    }
}
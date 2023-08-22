using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式 模板方法模式
 * 山精敌人
 * 
 * 创建时间：
 */

public class EnemyTroll : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("TrollHitEffect");
    }
}
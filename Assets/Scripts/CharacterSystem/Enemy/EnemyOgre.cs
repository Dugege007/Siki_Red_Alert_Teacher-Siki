using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式 模板方法模式
 * 食人魔敌人
 * 
 * 创建时间：
 */

public class EnemyOgre : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}
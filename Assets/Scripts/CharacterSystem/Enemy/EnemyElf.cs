using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式 模板方法模式
 * 精灵敌人
 * 
 * 创建时间：
 */

public class EnemyElf : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}
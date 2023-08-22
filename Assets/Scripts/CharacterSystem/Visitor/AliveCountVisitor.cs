using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：访问者模式
 * 存活数量访问者
 * 
 * 创建时间：
 */

public class AliveCountVisitor : ICharacterVisitor
{
    public int EnemyCount { get; private set; }
    public int SoldierCount { get; private set; }

    public override void VisitEnemy(IEnemy enemy)
    {
        if (enemy.IsDead == false)
            EnemyCount++;
    }

    public override void VisitSoldier(ISoldier soldier)
    {
        if (soldier.IsDead == false)
            SoldierCount++;
    }

    public void Reset()
    {
        EnemyCount = 0;
        SoldierCount = 0;
    }
}
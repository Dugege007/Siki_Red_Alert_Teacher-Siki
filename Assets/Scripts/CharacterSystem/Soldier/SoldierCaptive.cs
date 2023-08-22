using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：适配器模式
 * 俘兵
 * 
 * 创建时间：
 */

public class SoldierCaptive : ISoldier
{
    private IEnemy mEnemy;

    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;
        //TODO 对俘兵属性进行适配
        ICharacterAttr attr = new ISoldierAttr(enemy.Attr.Strategy, 1, enemy.Attr.BaseAttr);

        Attr = attr;
        GameObj = mEnemy.GameObj;
        Weapon = mEnemy.Weapon;
    }

    protected override void PlayEffect()
    {
        mEnemy.PlayEffect();
    }

    protected override void PlaySound()
    {
        //DONOTHING
        return;
    }
}
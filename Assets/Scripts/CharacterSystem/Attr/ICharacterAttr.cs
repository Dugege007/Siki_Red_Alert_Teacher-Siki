using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式 策略模式
 * 角色属性接口
 * 
 * 创建时间：
 */

public class ICharacterAttr
{
    protected CharacterBaseAttr mBaseAttr;
    protected int mCurrentHP;
    protected int mLv;
    protected int mDmgDesc;  // 伤害减免
    // 增加的最大血量 抵御的伤害值 暴击增加的伤害 使用策略模式
    protected IAttrStrategy mStrategy;

    public CharacterBaseAttr BaseAttr { get { return mBaseAttr; } }
    public int CritValue { get { return mStrategy.GetCritDmg(mBaseAttr.CritRate); } }
    public int CurrentHP { get { return mCurrentHP; } }
    public IAttrStrategy Strategy { get { return mStrategy; } }

    public ICharacterAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr)
    {
        mLv = lv;
        mStrategy = strategy;
        mBaseAttr = baseAttr;
        mDmgDesc = mStrategy.GetDmgDescValue(mLv);
        mCurrentHP = baseAttr.MaxHP + mStrategy.GetExtraHPValue(mLv);
        // 在构造方法中传入固定值的属性
    }

    public void TakeDamage(int damage)
    {
        damage -= mDmgDesc;

        if (damage < 5)
            damage = 5;

        mCurrentHP -= damage;
    }
}
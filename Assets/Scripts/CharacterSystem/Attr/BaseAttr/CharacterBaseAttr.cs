using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：享元模式
 * 角色基本属性
 * 
 * 创建时间：
 */

public class CharacterBaseAttr
{
    protected string mName;
    protected int mMaxHP;
    protected float mMoveSpeed;
    protected string mIconSprite;
    protected string mPrefabName;
    protected float mCritRate;  // 暴击率

    public string Name { get { return mName; } }
    public int MaxHP { get { return mMaxHP; } }
    public float MoveSpeed { get { return mMoveSpeed; } }
    public string IconSprite { get { return mIconSprite; } }
    public string PrefabName { get { return mPrefabName; } }
    public float CritRate { get { return mCritRate; } }

    public CharacterBaseAttr(string name, int maxHP, float moveSpeed, string iconSprite, string prefabName, float critRate)
    {
        mName = name;
        mMaxHP = maxHP;
        mMoveSpeed = moveSpeed;
        mIconSprite = iconSprite;
        mPrefabName = prefabName;
        mCritRate = critRate;
    }
}
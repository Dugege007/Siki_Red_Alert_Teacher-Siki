using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：建造者模式
 * 角色建造者的抽象基类
 * 
 * 创建时间：
 */

public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter;
    protected System.Type mType;
    protected WeaponType mWeaponType;
    protected Vector3 mSpawnPosition;
    protected int mLv;

    protected string mPrefabName = "";

    public ICharacterBuilder(ICharacter character, System.Type t, WeaponType weaponType, Vector3 spawnPos, int lv)
    {
        mCharacter = character;
        mType = t;
        mWeaponType = weaponType;
        mSpawnPosition = spawnPos;
        mLv = lv;
    }

    public abstract void AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
    public abstract void AddInCharacterSystem();
    public abstract ICharacter GetResult();
}
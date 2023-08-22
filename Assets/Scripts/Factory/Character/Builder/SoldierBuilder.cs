using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：建造者模式
 * 建造士兵
 * 
 * 创建时间：
 */

public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPos, int lv) : base(character, t, weaponType, spawnPos, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(mType);
        mPrefabName = baseAttr.PrefabName;
        ICharacterAttr attr = new ISoldierAttr(new SoldierAttrStrategy(), mLv, baseAttr);
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {
        // 创建角色的游戏物体
        // 加载 实例化
        GameObject characterGO = FactoryManager.AssetFactory.LoadSoldier(mPrefabName);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.GameObj = characterGO;
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddSoldier(mCharacter as ISoldier);
    }

    public override void AddWeapon()
    {
        // 添加武器
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(mWeaponType);
        mCharacter.Weapon = weapon;
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}
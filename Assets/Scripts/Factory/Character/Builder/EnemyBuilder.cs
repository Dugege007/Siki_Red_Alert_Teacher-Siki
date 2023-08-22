using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：建造者模式
 * 建造敌人
 * 
 * 创建时间：
 */

public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPos, int lv) : base(character, t, weaponType, spawnPos, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(mType);
        mPrefabName = baseAttr.PrefabName;
        ICharacterAttr attr = new IEnemyAttr(new SoldierAttrStrategy(), mLv, baseAttr);
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {
        GameObject characterGO = FactoryManager.AssetFactory.LoadEnemy(mPrefabName);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.GameObj = characterGO;
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddEnemy(mCharacter as IEnemy);
    }

    public override void AddWeapon()
    {
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(mWeaponType);
        mCharacter.Weapon = weapon;
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工厂模式 享元模式
 * 角色属性工厂实现类
 * 
 * 创建时间：
 */

public class AttrFactory : IAttrFactory
{
    private Dictionary<Type, CharacterBaseAttr> mCharacterBaseAttrDict = new Dictionary<Type, CharacterBaseAttr>();
    private Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttrDict = new Dictionary<WeaponType, WeaponBaseAttr>();

    public AttrFactory()
    {
        InitCharacterBaseAttr();
        InitWeaponBaseAttr();
    }

    private void InitCharacterBaseAttr()
    {
        mCharacterBaseAttrDict = new Dictionary<Type, CharacterBaseAttr>
        {
            { typeof(SoldierRockie), new CharacterBaseAttr("下士", 80, 2.5f, "RockieIcon", "Soldier2", 0) },
            { typeof(SoldierSergeant), new CharacterBaseAttr("中士", 90, 2.8f, "SergeantIcon", "Soldier3", 0.1f) },
            { typeof(SoldierCaptain), new CharacterBaseAttr("上尉", 100, 3f, "CaptainIcon", "Soldier1", 0.2f) },
            { typeof(EnemyElf), new CharacterBaseAttr("小精灵", 100, 3f, "ElfIcon", "Enemy1", 0) },
            { typeof(EnemyOgre), new CharacterBaseAttr("怪物", 120, 3.2f, "OgreIcon", "Enemy2", 0.1f) },
            { typeof(EnemyTroll), new CharacterBaseAttr("巨魔", 150, 3.5f, "TrollIcon", "Enemy3", 0) }
        };
    }

    private void InitWeaponBaseAttr()
    {
        mWeaponBaseAttrDict = new Dictionary<WeaponType, WeaponBaseAttr>
        {
            { WeaponType.Gun, new WeaponBaseAttr("手枪", 20, 5f, "WeaponGun") },
            { WeaponType.Rifle, new WeaponBaseAttr("来福枪", 30, 7f, "WeaponRifle") },
            { WeaponType.Rocket, new WeaponBaseAttr("火箭炮", 40, 10f, "WeaponRocket") },
        };
    }

    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if (mCharacterBaseAttrDict.ContainsKey(t) == false)
        {
            Debug.LogError("无法根据类型" + t + "得到角色基础属性(GetCharacterBaseAttr)");
            return null;
        }
        return mCharacterBaseAttrDict[t];
    }

    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType)
    {
        if (mWeaponBaseAttrDict.ContainsKey(weaponType) == false)
        {
            Debug.LogError("无法根据类型" + weaponType + "得到角色基础属性(GetWeaponBaseAttr)");
            return null;
        }
        return mWeaponBaseAttrDict[weaponType];
    }
}
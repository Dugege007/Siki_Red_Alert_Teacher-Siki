using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工厂模式
 * 实现创建武器
 * 
 * 创建时间：
 */

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        WeaponBaseAttr baseAttr = FactoryManager.AttrFactory.GetWeaponBaseAttr(weaponType);
        GameObject weaponGO = FactoryManager.AssetFactory.LoadWeapon(baseAttr.AssetName);

        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(baseAttr, weaponGO);
                break;
            case WeaponType.Rifle:
                weapon = new WeaponRifle(baseAttr, weaponGO);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(baseAttr, weaponGO);
                break;
        }
        return weapon;
    }
}
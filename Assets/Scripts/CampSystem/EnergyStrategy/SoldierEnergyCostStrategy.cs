using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：策略模式 命令模式
 * 
 * 
 * 创建时间：
 */

public class SoldierEnergyCostStrategy : IEnergyCostStrategy
{
    public override int GetCampUpgradeCost(SoldierType soldierType, int lv)
    {
        int energy = 0;

        switch (soldierType)
        {
            case SoldierType.Rockie:
                energy = 30;
                break;
            case SoldierType.Sergeant:
                energy = 40;
                break;
            case SoldierType.Captain:
                energy = 50;
                break;
            default:
                Debug.LogError("无法获取" + soldierType + "兵营升级所消耗的能朗值");
                break;
        }
        energy += (lv - 1) * 5;
        if (energy > 100)
            energy = 100;

        return energy;
    }

    public override int GetSoldierTrainCost(SoldierType soldierType, int lv)
    {
        int energy = 0;

        switch (soldierType)
        {
            case SoldierType.Rockie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 20;
                break;
            case SoldierType.Captain:
                energy = 30;
                break;
            case SoldierType.Captive:
                energy = 10;
                break;
            default:
                Debug.LogError("无法获取士兵类型" + soldierType + "训练所消耗的能朗值");
                break;
        }
        energy += (lv - 1) * 2;

        return energy;
    }

    public override int GetWeaponUpgradeCost(WeaponType weaponType)
    {
        int energy = 0;

        switch (weaponType)
        {
            case WeaponType.Gun:
                energy = 20;
                break;
            case WeaponType.Rifle:
                energy = 40;
                break;
            case WeaponType.Rocket:
                break;
            default:
                Debug.LogError("无法获取武器类型" + weaponType + "升级所消耗的能朗值");
                break;
        }

        return energy;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：策略模式 命令模式
 * 能量消耗策略
 * 
 * 创建时间：
 */

public abstract class IEnergyCostStrategy
{
    public abstract int GetCampUpgradeCost(SoldierType soldierType, int lv);
    public abstract int GetWeaponUpgradeCost(WeaponType weaponType);
    public abstract int GetSoldierTrainCost(SoldierType soldierType, int lv);
}
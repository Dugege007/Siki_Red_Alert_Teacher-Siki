using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：命令模式
 * 士兵兵营
 * 
 * 创建时间：
 */

public class SoldierCamp : ICamp
{
    private const int MaxLv = 4;
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;

    public override int Lv { get { return mLv; } }
    public override WeaponType WeaponType { get { return mWeaponType; } }

    public override int CampUpgradeEnergyCost
    {
        get
        {
            if (mLv == MaxLv)
                return -1;
            else
                return mCampUpgradeEnergyCost;
        }
    }

    public override int WeaponUpgradeEnergyCost
    {
        get
        {
            if (mWeaponType + 1 == WeaponType.MAX)
                return -1;
            else
                return mWeaponUpgradeEnergyCost;
        }
    }

    public override int TrainEnergyCost { get { return mTrainEnergyCost; } }

    public SoldierCamp(GameObject obj, string name, string icon, SoldierType soldierType, Vector3 musterPos, float trainTime, WeaponType weaponType = WeaponType.Gun, int lv = 1) : base(obj, name, icon, soldierType, musterPos, trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public override void Train()
    {
        //添加训练命令
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType, mWeaponType, mMusterPos, mLv);
        mTrainCommands.Add(cmd);
    }

    protected override void UpdateEnergyCost()
    {
        mCampUpgradeEnergyCost = mEnergyCostStrategy.GetCampUpgradeCost(mSoldierType, mLv);
        mWeaponUpgradeEnergyCost = mEnergyCostStrategy.GetWeaponUpgradeCost(mWeaponType);
        mTrainEnergyCost = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType, mLv);
    }

    public override void UpgradeCamp()
    {
        mLv++;
        UpdateEnergyCost();
    }

    public override void UpgradeWeapon()
    {
        mWeaponType++;
        UpdateEnergyCost();
    }
}
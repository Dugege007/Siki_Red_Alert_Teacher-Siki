using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：命令模式 适配器模式
 * 俘兵营
 * 
 * 创建时间：
 */

public class CaptiveCamp : ICamp
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType = WeaponType.Gun;
    private int mSoldierTrainCost;

    public override int Lv { get { return 1; } }
    public override WeaponType WeaponType { get { return mWeaponType; } }
    public override int CampUpgradeEnergyCost { get { return 0; } }
    public override int WeaponUpgradeEnergyCost { get { return 0; } }
    public override int TrainEnergyCost { get { return mTrainEnergyCost; } }

    public CaptiveCamp(GameObject obj, string name, string icon, EnemyType enemyType, Vector3 musterPos, float trainTime) : base(obj, name, icon, SoldierType.Captive, musterPos, trainTime)
    {
        mEnemyType = enemyType;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public override void Train()
    {
        //添加训练命令
        TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType, mWeaponType, mMusterPos);
        mTrainCommands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        return;
    }

    public override void UpgradeWeapon()
    {
        return;
    }

    protected override void UpdateEnergyCost()
    {
        mTrainEnergyCost = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType, 1);
    }
}
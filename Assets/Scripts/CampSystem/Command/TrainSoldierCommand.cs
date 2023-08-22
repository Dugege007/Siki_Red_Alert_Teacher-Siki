using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：命令模式（命令）
 * 训练士兵的命令
 * 
 * 创建时间：
 */

public class TrainSoldierCommand : ITrainCommand
{
    private SoldierType mSoldierType;
    private WeaponType mWeaponType;
    private Vector3 mSpawnPos;
    private int mLv;

    public TrainSoldierCommand(SoldierType soldierType, WeaponType weaponType, Vector3 spawnPos, int lv)
    {
        mSoldierType = soldierType;
        mWeaponType = weaponType;
        mSpawnPos = spawnPos;
        mLv = lv;
    }

    public override void Execute()
    {
        switch (mSoldierType)
        {
            case SoldierType.Rockie:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierRockie>(mWeaponType, mSpawnPos, mLv);
                break;
            case SoldierType.Sergeant:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierSergeant>(mWeaponType, mSpawnPos, mLv);
                break;
            case SoldierType.Captain:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierCaptain>(mWeaponType, mSpawnPos, mLv);
                break;
            default:
                Debug.LogError("无法根据SoldierType:" + mSoldierType + "创建角色");
                break;
        }
    }
}
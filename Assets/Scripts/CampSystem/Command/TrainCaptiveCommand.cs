using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：命令模式 适配器模式
 * 增加训练俘兵
 * 
 * 创建时间：
 */

public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private Vector3 mSpawnPos;

    public TrainCaptiveCommand(EnemyType enemyType, WeaponType weaponType, Vector3 spawnPos)
    {
        mEnemyType = enemyType;
        mWeaponType = weaponType;
        mSpawnPos = spawnPos;
    }

    public override void Execute()
    {
        IEnemy enemy = null;

        switch (mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(mWeaponType, mSpawnPos) as IEnemy;
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mSpawnPos) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mSpawnPos) as IEnemy;
                break;
            default:
                Debug.LogError("无法根据俘兵:" + mEnemyType + "创建角色");
                return;
        }

        GameFacade.Instance.RemoveEnemy(enemy);
        SoldierCaptive captive = new SoldierCaptive(enemy);
        GameFacade.Instance.AddSoldier(captive);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：责任链模式
 * 正常关卡处理
 * 
 * 创建时间：
 */

public class NormalStageHandler : IStageHandler
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private int mCount;
    private Vector3 mSpawnPos;

    private float mSpawnTime = 1f;
    private float mSpawnTimer = 0;
    private int mSpawnCount = 0;

    public NormalStageHandler(StageSystem stageSystem, int lv, int countToFinish, EnemyType enemyType, WeaponType weaponType, int count) : base(stageSystem, lv, countToFinish)
    {
        mEnemyType = enemyType;
        mWeaponType = weaponType;
        mCount = count;
        mSpawnPos = mStageSystem.GetRandomSpawnPosition();
        mSpawnTimer = mSpawnTime;
    }

    protected override void UpdateStage()
    {
        base.UpdateStage();
        if (mSpawnCount < mCount)
        {
            mSpawnTimer -= Time.deltaTime;
            if (mSpawnTimer <= 0)
            { 
                SpawnEnemy();
                mSpawnTimer = mSpawnTime;
            }
        }
    }

    private void SpawnEnemy()
    {
        mSpawnCount++;
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(mWeaponType, mSpawnPos);
                break;
            case EnemyType.Ogre:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mSpawnPos);
                break;
            case EnemyType.Troll:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mSpawnPos);
                break;
            default:
                Debug.LogError("无法根据EnemyType:" + mEnemyType + "生成敌人");
                break;
        }
    }
}
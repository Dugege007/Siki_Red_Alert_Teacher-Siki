using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：中介者模式 责任链模式
 * 关卡系统
 * 
 * 创建时间：
 */

public class StageSystem : IGameSystem
{
    private int mLv = 1;
    private IStageHandler mRootHandler;
    protected List<Vector3> mSpawnPosList;
    protected List<Vector3> mTargetPosList;
    private int mCountOfEnemyDead = 0;

    public int CountOfEnemyDead { set { mCountOfEnemyDead = value; } }

    public override void Init()
    {
        base.Init();
        InitSpawnPosition();
        InitTargetPosition();
        InitStageChain();
        mFacade.RegisterObserver(GameEventType.EnemyDead, new EnemyDeadObserverStageSystem(this));
    }

    public override void Update()
    {
        base.Update();
        mRootHandler.Handle(mLv);
    }

    private void InitSpawnPosition()
    {
        mSpawnPosList = new List<Vector3>();

        int i = 1;
        while (true)
        {
            GameObject spawnPosGo = GameObject.Find("SpawnPos" + i);

            if (spawnPosGo != null)
            {
                mSpawnPosList.Add(spawnPosGo.transform.position);
                spawnPosGo.SetActive(false);
                i++;
            }
            else break;
        }
    }

    private void InitTargetPosition()
    {
        mTargetPosList = new List<Vector3>();

        int i = 1;
        while (true)
        {
            GameObject targetPosGo = GameObject.Find("TargetPos" + i);

            if (targetPosGo != null)
            {
                mTargetPosList.Add(targetPosGo.transform.position);
                targetPosGo.SetActive(false);
                i++;
            }
            else break;
        }
    }

    public Vector3 GetRandomSpawnPosition()
    {
        return mSpawnPosList[Random.Range(0, mSpawnPosList.Count)];
    }

    public Vector3 GetRandomTargetPosition()
    {
        return mTargetPosList[Random.Range(0, mTargetPosList.Count)];
    }

    private void InitStageChain()
    {
        int lv = 1;
        NormalStageHandler handler1 = new NormalStageHandler(this, lv++, 3, EnemyType.Elf, WeaponType.Gun, 3);
        NormalStageHandler handler2 = new NormalStageHandler(this, lv++, 6, EnemyType.Elf, WeaponType.Rifle, 4);
        NormalStageHandler handler3 = new NormalStageHandler(this, lv++, 10, EnemyType.Ogre, WeaponType.Gun, 5);
        NormalStageHandler handler4 = new NormalStageHandler(this, lv++, 15, EnemyType.Ogre, WeaponType.Rifle, 6);
        NormalStageHandler handler5 = new NormalStageHandler(this, lv++, 20, EnemyType.Elf, WeaponType.Rocket, 5);
        NormalStageHandler handler6 = new NormalStageHandler(this, lv++, 25, EnemyType.Ogre, WeaponType.Rifle, 6);
        NormalStageHandler handler7 = new NormalStageHandler(this, lv++, 32, EnemyType.Ogre, WeaponType.Rocket, 7);
        NormalStageHandler handler8 = new NormalStageHandler(this, lv++, 40, EnemyType.Troll, WeaponType.Gun, 8);
        NormalStageHandler handler9 = new NormalStageHandler(this, lv++, 45, EnemyType.Troll, WeaponType.Rifle, 6);
        NormalStageHandler handler10 = new NormalStageHandler(this, lv++, 50, EnemyType.Troll, WeaponType.Rocket, 8);

        handler1
            .SetNextHandler(handler2)
            .SetNextHandler(handler3)
            .SetNextHandler(handler4)
            .SetNextHandler(handler5)
            .SetNextHandler(handler6)
            .SetNextHandler(handler7)
            .SetNextHandler(handler8)
            .SetNextHandler(handler9)
            .SetNextHandler(handler10);

        mRootHandler = handler1;
    }

    public int GetCountOfEnemyDead()
    {
        return mCountOfEnemyDead;
    }

    public void EnterNextStage()
    {
        mLv++;
        mFacade.NotifySubject(GameEventType.NewStage);
        //Debug.Log("Enter Next Stage" + mLv);
    }
}
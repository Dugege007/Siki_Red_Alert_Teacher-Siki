using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：中介者模式 观察者模式 备忘录模式
 * 成就系统
 * 
 * 创建时间：
 */

public class AchievementSystem : IGameSystem
{
    private int mEnemyDeadCount = 0;
    private int mSoldierDeadCount = 0;
    private int mMaxStage = 1;

    //PlayerPrefs json xml

    public override void Init()
    {
        base.Init();
        mFacade.RegisterObserver(GameEventType.EnemyDead, new EnemyDeadObserverAchievement(this));
        mFacade.RegisterObserver(GameEventType.SoldierDead, new SoldierDeadObserverAchievement(this));
        mFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverAchievement(this));
    }

    public void AddEnemyDeadCount(int number = 1)
    {
        mEnemyDeadCount += number;
        Debug.Log("EnemyDeadCount" + mEnemyDeadCount);
    }

    public void AddSoldierDeadCount(int number = 1)
    {
        mSoldierDeadCount += number;
        Debug.Log("SoldierDeadCount" + mSoldierDeadCount);
    }

    public void SetMaxStage(int stage)
    {
        if (mMaxStage < stage)
            mMaxStage = stage;

        Debug.Log("MaxStage" + mMaxStage);
    }

    #region 此种保存数据的方式破坏了成就系统改的封装
    //private void SaveData()
    //{
    //    PlayerPrefs.SetInt("EnemyDeadCount", mEnemyDeadCount);
    //    PlayerPrefs.SetInt("SoldierDeadCount", mSoldierDeadCount);
    //    PlayerPrefs.SetInt("MaxStage", mMaxStage);
    //}

    //private void LoadData()
    //{
    //    mEnemyDeadCount = PlayerPrefs.GetInt("EnemyDeadCount");
    //    mSoldierDeadCount = PlayerPrefs.GetInt("SoldierDeadCount");
    //    mMaxStage = PlayerPrefs.GetInt("MaxStage");
    //}
    #endregion

    public AchievementMemento CreateMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.EnemyDeadCount = mEnemyDeadCount;
        memento.SoldierDeadCount = mSoldierDeadCount;
        memento.MaxStage = mMaxStage;
        return memento;
    }

    public void SetMemento(AchievementMemento memento)
    {
        mEnemyDeadCount = memento.EnemyDeadCount;
        mSoldierDeadCount = memento.SoldierDeadCount;
        mMaxStage = memento.MaxStage;
    }
}
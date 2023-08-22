using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：备忘录模式
 * 成就系统备忘录
 * 
 * 创建时间：
 */

public class AchievementMemento
{
    private int mEnemyDeadCount = 0;
    private int mSoldierDeadCount = 0;
    private int mMaxStage = 1;

    public int EnemyDeadCount
    {
        get { return mEnemyDeadCount; }
        set { mEnemyDeadCount = value; }
    }
    public int SoldierDeadCount
    {
        get { return mSoldierDeadCount; }
        set { mSoldierDeadCount = value; }
    }
    public int MaxStage
    {
        get { return mMaxStage; }
        set { mMaxStage = value; }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyDeadCount", mEnemyDeadCount);
        PlayerPrefs.SetInt("SoldierDeadCount", mSoldierDeadCount);
        PlayerPrefs.SetInt("MaxStage", mMaxStage);
    }

    public void LoadData()
    {
        mEnemyDeadCount = PlayerPrefs.GetInt("EnemyDeadCount");
        mSoldierDeadCount = PlayerPrefs.GetInt("SoldierDeadCount");
        mMaxStage = PlayerPrefs.GetInt("MaxStage");
    }
}
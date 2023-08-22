using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：观察者模式（观察者）
 * 敌人死亡事件观察者，订阅成就主题
 * 
 * 创建时间：
 */

public class EnemyDeadObserverAchievement : IGameEventObserver
{
    //private EnemyDeadSubject mSubject;
    private AchievementSystem mAchievementSystem;

    public EnemyDeadObserverAchievement(AchievementSystem achievementSystem)
    {
        mAchievementSystem = achievementSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        //mSubject = subject as EnemyDeadSubject;
    }

    public override void Update()
    {
        mAchievementSystem.AddEnemyDeadCount();
    }
}
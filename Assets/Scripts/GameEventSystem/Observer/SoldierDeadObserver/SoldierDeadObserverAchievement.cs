using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：观察者模式（观察者）
 * 士兵死亡事件观察者，订阅成就主题
 * 
 * 创建时间：
 */

public class SoldierDeadObserverAchievement : IGameEventObserver
{
    private AchievementSystem mAchievementSystem;

    public SoldierDeadObserverAchievement(AchievementSystem achievementSystem)
    {
        mAchievementSystem = achievementSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        return;
    }

    public override void Update()
    {
        mAchievementSystem.AddSoldierDeadCount();
    }
}
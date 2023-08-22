using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：观察者模式（观察者）
 * 新关卡事件观察者，订阅成就主题
 * 
 * 创建时间：
 */

public class NewStageObserverAchievement : IGameEventObserver
{
    private NewStageSubject mSubject;
    private AchievementSystem mAchievementSystem;

    public NewStageObserverAchievement(AchievementSystem achievementSystem)
    {
        mAchievementSystem = achievementSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject = subject as NewStageSubject;
    }

    public override void Update()
    {
        mAchievementSystem.SetMaxStage(mSubject.StageCount);
    }
}
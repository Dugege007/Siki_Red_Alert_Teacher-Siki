using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：观察者模式（观察者）
 * 敌人死亡事件观察者，订阅关卡主题
 * 
 * 创建时间：
 */

public class EnemyDeadObserverStageSystem : IGameEventObserver
{
    private EnemyDeadSubject mSubject;
    private StageSystem mStageSystem;

    public EnemyDeadObserverStageSystem(StageSystem stageSystem)
    {
        mStageSystem = stageSystem;
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject = subject as EnemyDeadSubject;
    }

    public override void Update()
    {
        mStageSystem.CountOfEnemyDead = mSubject.DeadCount;
        //Debug.Log("Update:" + mSubject.DeadCount);
    }
}
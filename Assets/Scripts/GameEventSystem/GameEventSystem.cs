using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：中介者模式 观察者模式
 * 游戏事件系统
 * 
 * 创建时间：
 */

public enum GameEventType
{
    Null,
    EnemyDead,
    SoldierDead,
    NewStage
}

public class GameEventSystem : IGameSystem
{
    private Dictionary<GameEventType, IGameEventSubject> mGameEvents = new Dictionary<GameEventType, IGameEventSubject>();

    public override void Init()
    {
        base.Init();
        //InitGameEvents();
    }

    //private void InitGameEvents()
    //{
    //}

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        IGameEventSubject subject = GetGameEventSub(eventType);
        if (subject == null) return;

        subject.RegisterObserver(observer);
        observer.SetSubject(subject);
    }

    public void RemoveObserver(GameEventType eventType,IGameEventObserver observer)
    {
        IGameEventSubject subject = GetGameEventSub(eventType);
        if (subject == null) return;

        subject.RemoveObserver(observer);
        observer.SetSubject(null);
    }

    public void NotifySubject(GameEventType eventType)
    {
        IGameEventSubject subject = GetGameEventSub(eventType);
        if (subject == null) return;

        subject.Notify();
    }

    private IGameEventSubject GetGameEventSub(GameEventType eventType)
    {
        if (mGameEvents.ContainsKey(eventType) == false)
        {
            switch (eventType)
            {
                case GameEventType.Null:
                    break;
                case GameEventType.EnemyDead:
                    mGameEvents.Add(GameEventType.EnemyDead, new EnemyDeadSubject());
                    break;
                case GameEventType.SoldierDead:
                    mGameEvents.Add(GameEventType.SoldierDead, new SoldierDeadSubject());
                    break;
                case GameEventType.NewStage:
                    mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
                    break;
                default:
                    Debug.LogError("没有对应的事件类型" + eventType + "的主题类");
                    return null;
            }
        }

        return mGameEvents[eventType];
    }
}
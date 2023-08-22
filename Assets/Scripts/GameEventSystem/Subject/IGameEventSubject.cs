using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：观察者模式（主题）
 * 游戏事件主题基类
 * 
 * 创建时间：
 */

public class IGameEventSubject
{
    private List<IGameEventObserver> mObservers = new List<IGameEventObserver>();

    public void RegisterObserver(IGameEventObserver observer)
    {
        mObservers.Add(observer);
    }

    public void RemoveObserver(IGameEventObserver observer)
    {
        mObservers.Remove(observer);
    }

    public virtual void Notify()
    {
        foreach (var observer in mObservers)
        {
            observer.Update();
        }
    }
}
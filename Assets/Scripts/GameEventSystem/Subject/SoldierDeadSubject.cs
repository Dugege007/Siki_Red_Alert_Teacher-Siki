using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：观察者模式（主题）
 * 士兵死亡事件
 * 
 * 创建时间：
 */

public class SoldierDeadSubject : IGameEventSubject
{
    private int mDeadCount = 0;
    public int DeadCount { get { return mDeadCount; } }

    public override void Notify()
    {
        mDeadCount++;
        base.Notify();
    }
}
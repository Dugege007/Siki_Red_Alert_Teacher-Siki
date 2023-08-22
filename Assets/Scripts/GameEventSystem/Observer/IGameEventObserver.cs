using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：观察者模式（观察者）
 * 游戏事件观察者基类
 * 
 * 创建时间：
 */

public abstract class IGameEventObserver
{
    public abstract void Update();
    public abstract void SetSubject(IGameEventSubject subject);
}
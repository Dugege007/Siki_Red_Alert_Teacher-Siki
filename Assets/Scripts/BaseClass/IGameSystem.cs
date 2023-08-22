using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：中介者模式
 * 各游戏系统的公共接口
 * 
 * 创建时间：
 */

public abstract class IGameSystem
{
    protected GameFacade mFacade;

    public virtual void Init()
    {
        mFacade = GameFacade.Instance;
    }
    public virtual void Update() { }
    public virtual void Release() { }
}
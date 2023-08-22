using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：观察者模式（主题）
 * 新关卡事件
 * 
 * 创建时间：
 */

public class NewStageSubject : IGameEventSubject
{
    private int mStageCount = 1;
    public int StageCount { get { return mStageCount; } }

    public override void Notify()
    {
        mStageCount++;
        base.Notify();
    }
}
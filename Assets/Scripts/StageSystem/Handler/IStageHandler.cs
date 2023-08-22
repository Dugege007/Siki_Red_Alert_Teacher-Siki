using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：责任链模式
 * 关卡处理基类
 * 
 * 创建时间：
 */

public abstract class IStageHandler
{
    protected int mStageLv;
    private int mCountToFinish;
    protected StageSystem mStageSystem;
    protected IStageHandler mNextHandler;

    public IStageHandler(StageSystem stageSystem, int lv, int countToFinish)
    {
        mStageSystem = stageSystem;
        mStageLv = lv;
        mCountToFinish = countToFinish;
    }

    protected virtual void UpdateStage() { }

    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }

    public void Handle(int stageLv)
    {
        if (mStageLv == stageLv)
        {
            //Debug.Log("当前关卡等级：" + mStageLv + "  Handle输入等级：" + stageLv);
            UpdateStage();
            CheckIsFinished();
        }
        else
        {
            if (mNextHandler != null)
            {
                mNextHandler.Handle(stageLv);
            }
        }
    }

    private void CheckIsFinished()
    {
        if (mStageSystem.GetCountOfEnemyDead() >= mCountToFinish)
        {
            mStageSystem.EnterNextStage();
        }
    }
}
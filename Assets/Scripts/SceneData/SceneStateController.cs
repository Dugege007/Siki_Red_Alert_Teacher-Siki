using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 创建人：杜
 * 功能说明：状态模式（控制器）
 * 用来控制所有场景状态，给游戏入口提供设置状态和更新状态的方法
 * 
 * 创建时间：
 */

public class SceneStateController
{
    private ISceneState mState;
    private AsyncOperation mAO;
    private bool mIsRunStart = false;

    public void SetState(ISceneState state, bool needLoadScene = true)
    {
        if (mState != null)
        {
            // 清理上个场景
            mState.StateEnd();
        }

        mState = state;

        if (needLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunStart = false;
        }
        else
        {
            mState.StateStart();
            mIsRunStart = true;
        }
    }

    public void StateUpdate()
    {
        if (mAO != null && !mAO.isDone) return;

        if (mAO != null && mAO.isDone && !mIsRunStart)
        {
            mIsRunStart = true;
            mState.StateStart();
        }

        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}
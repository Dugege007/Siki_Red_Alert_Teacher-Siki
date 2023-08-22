using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：状态模式（接口）
 * 所有状态的父类，提供一些基本的属性和方法，让状态子类去实现
 * 
 * 创建时间：
 */

public class ISceneState
{
    private string mSceneName;
    protected SceneStateController mController;
    public ISceneState(string sceneName, SceneStateController controller)
    {
        mSceneName = sceneName;
        mController = controller;
    }

    public string SceneName
    {
        get { return mSceneName; }
    }

    // 每次进入到状态时调用
    public virtual void StateStart() { }

    public virtual void StateEnd() { }
    // 每次进入到状态时调用
    public virtual void StateUpdate() { }
}
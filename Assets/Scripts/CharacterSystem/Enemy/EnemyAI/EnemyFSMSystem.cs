using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：状态模式（有限状态机）
 * 管理敌人所有的状态
 * 
 * 创建时间：
 */

public class EnemyFSMSystem
{
    private List<IEnemyState> mStates = new List<IEnemyState>();
    private IEnemyState mCurrentState;
    public IEnemyState CurrentState { get { return mCurrentState; } }

    /// <summary>
    /// 添加状态
    /// </summary>
    /// <param name="state">要添加的状态</param>
    public void AddState(IEnemyState state)
    {
        // 安全校验
        // 检查要添加的状态是否为空
        if (state == null)
        {
            Debug.LogError("要添加的状态为空");
            return;
        }

        // 检查当前状态列表是否为空
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            // 初始化状态
            mCurrentState.DoBeforeEntering();
            return;
        }

        // 检查是否已存在该状态
        foreach (var s in mStates)
        {
            if (s.StateID == state.StateID)
            {
                Debug.LogError("要添加的状态:[" + s.StateID + "] 已存在");
                return;
            }
        }

        // 添加状态
        mStates.Add(state);
    }

    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState s in states) AddState(s);
    }

    /// <summary>
    /// 删除状态
    /// </summary>
    /// <param name="stateID">要删除状态的ID</param>
    public void DeleteState(EnemyStateID stateID)
    {
        // 安全校验
        // 检查要删除的状态ID是否为空
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("要删除的状态ID为空: " + stateID);
            return;
        }

        // 找到该ID的状态，并将其删除
        foreach (var s in mStates)
        {
            if (s.StateID == stateID)
            {
                mStates.Remove(s);
                Debug.Log("状态ID: " + stateID + " 已删除");
                return;
            }
        }

        // 遍历完没有发现这个状态，则报错
        Debug.LogError("要删除的状态ID不存在集合中: " + stateID);
    }

    /// <summary>
    /// 根据转换条件执行转换
    /// </summary>
    /// <param name="trans">要执行的转换条件</param>
    public void PerformTransition(EnemyTransition trans)
    {
        // 安全校验
        // 检查要运行的转换条件是否为空
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("要执行的转换条件为空: " + trans);
            return;
        }

        // 检查下一个状态是否为空
        EnemyStateID nextStateID = mCurrentState.GetOutputState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("在转换条件:[" + trans + "] 下没有对应的转换状态");
            return;
        }

        // 找到下一个状态，并执行相应方法
        foreach (var s in mStates)
        {
            if (s.StateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }
        }
    }
}
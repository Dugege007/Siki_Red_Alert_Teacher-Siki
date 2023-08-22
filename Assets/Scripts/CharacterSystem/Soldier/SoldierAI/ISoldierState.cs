using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：状态模式（有限状态机）
 * 士兵状态基类
 * 
 * 创建时间：
 */

/// <summary>
/// 转换条件
/// </summary>
public enum SoldierTransition
{
    NullTransition = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

/// <summary>
/// 状态
/// </summary>
public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack
}

public abstract class ISoldierState
{
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    protected ICharacter mCharacter;
    protected SoldierFSMSystem mFSMSystem;
    protected SoldierStateID mStateID;
    public SoldierStateID StateID { get { return mStateID; } }

    public ISoldierState(SoldierFSMSystem fsm, ICharacter character)
    {
        mFSMSystem = fsm;
        mCharacter = character;
    }

    public void AddTransition(SoldierTransition trans, SoldierStateID stateID)
    {
        // 安全校验
        // 检查转换状态是否为空
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("SoldierTransition Error: trans 转换条件不能为空");
            return;
        }
        // 检查状态ID是否为空
        if (stateID == SoldierStateID.NullState)
        {
            Debug.LogError("SoldierState Error: stateID 状态ID不能为空");
            return;
        }
        // 检查是否已存在该状态
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error: " + trans + " Key 重复");
            return;
        }

        // 将新状态加入mMap
        mMap.Add(trans, stateID);
    }

    public void DeleteTransition(SoldierTransition trans)
    {
        // 安全校验
        // 检查Key是否存在
        if (!mMap.ContainsKey(trans))
        {
            Debug.LogError("删除转换条件的时候，转换条件:[" + trans + "] 不存在");
            return;
        }

        // 删除该状态
        mMap.Remove(trans);
    }

    public SoldierStateID GetOutputState(SoldierTransition trans)
    {
        if (!mMap.ContainsKey(trans))
        {
            Debug.Log("没有相应的状态，不需要转换");
            return SoldierStateID.NullState;
        }
        else
        {
            return mMap[trans];
        }
    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }

    /// <summary>
    /// 判断在当前状态下是否需要转换到别的状态
    /// </summary>
    public abstract void Reason(List<ICharacter> targets);
    /// <summary>
    /// 要执行的逻辑
    /// </summary>
    public abstract void Act(List<ICharacter> targets);
}
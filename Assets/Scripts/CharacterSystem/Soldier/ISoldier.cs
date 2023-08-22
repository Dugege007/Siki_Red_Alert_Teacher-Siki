using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式 状态模式（有限状态机） 模板方法模式
 * 士兵基类
 * 
 * 创建时间：
 */

public enum SoldierType
{
    Rockie,
    Sergeant,
    Captain,
    Captive
}

public abstract class ISoldier : ICharacter
{
    protected SoldierFSMSystem mFSMSystem;
    public ISoldier() : base()
    {
        // 构造实例时，将其状态转换添加到状态机中
        MakeFSM();
    }

    /// <summary>
    /// 更新状态结果和行动
    /// </summary>
    /// <param name="targets">场上存在的所有敌人</param>
    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        if (mIsDead)
            return;

        mFSMSystem.CurrentState.Reason(targets);
        mFSMSystem.CurrentState.Act(targets);
    }

    private void MakeFSM()
    {
        mFSMSystem = new SoldierFSMSystem();
        SoldierIdleState idleState = new SoldierIdleState(mFSMSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mFSMSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(mFSMSystem, this);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);

        // 添加状态转换
        mFSMSystem.AddState(idleState, chaseState, attackState);
    }

    public override void UnderAttack(int damage)
    {
        if (mIsDead)
            return;

        base.UnderAttack(damage);
        if (mAttr.CurrentHP <= 0)
        {
            PlaySound();
            PlayEffect();
            Dead();
        }
    }

    public override void Dead()
    {
        base.Dead();
        GameFacade.Instance.NotifySubject(GameEventType.SoldierDead);
    }

    protected abstract void PlaySound();
    protected abstract void PlayEffect();

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitSoldier(this);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式 模板方法模式
 * 敌人基类
 * 
 * 创建时间：
 */

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}

public abstract class IEnemy : ICharacter
{
    protected EnemyFSMSystem mFSMSystem;

    public IEnemy()
    {
        MakeFSM();
    }

    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        if (mIsDead)
            return;

        mFSMSystem.CurrentState.Reason(targets);
        mFSMSystem.CurrentState.Act(targets);
    }

    private void MakeFSM()
    {
        mFSMSystem = new EnemyFSMSystem();
        EnemyChaseState chaseState = new EnemyChaseState(mFSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attackState = new EnemyAttackState(mFSMSystem, this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        mFSMSystem.AddState(chaseState, attackState);
    }

    public override void UnderAttack(int damage)
    {
        if (mIsDead) 
            return;

        base.UnderAttack(damage);
        PlayEffect();
        if (mAttr.CurrentHP <= 0)
        {
            Dead();
        }
    }

    public override void Dead()
    {
        base.Dead();
        GameFacade.Instance.NotifySubject(GameEventType.EnemyDead);
        Debug.Log("Enemy Dead");
    }

    public abstract void PlayEffect();

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitEnemy(this);
    }
}
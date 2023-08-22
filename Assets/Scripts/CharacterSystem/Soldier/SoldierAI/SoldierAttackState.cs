using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：状态模式（有限状态机）
 * 士兵 攻击状态
 * 
 * 创建时间：
 */

public class SoldierAttackState : ISoldierState
{
    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = SoldierStateID.Attack;
        mAttackTimer = mAttackTime;
    }

    private float mAttackTime = 1;
    private float mAttackTimer = 1;

    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0) return;

        mAttackTimer += Time.deltaTime;
        if (mAttackTimer >= mAttackTime)
        {
            mCharacter.Attack(targets[0]);
            mCharacter.NavMeshAgent.isStopped = true;
            mAttackTimer = 0;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFSMSystem.PerformTransition(SoldierTransition.NoEnemy);
        }
        else
        {
            float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if (distance > mCharacter.ATKRange)
            {
                mFSMSystem.PerformTransition(SoldierTransition.SeeEnemy);
            }
        }
    }
}
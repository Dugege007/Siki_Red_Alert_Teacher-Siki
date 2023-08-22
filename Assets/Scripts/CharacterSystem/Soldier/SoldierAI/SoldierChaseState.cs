using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：状态模式（有限状态机）
 * 士兵 追击状态
 * 
 * 创建时间：
 */

public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = SoldierStateID.Chase;
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].Position);
            mCharacter.NavMeshAgent.isStopped = false;
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
            if (distance <= mCharacter.ATKRange)
            {
                mFSMSystem.PerformTransition(SoldierTransition.CanAttack);
                //Debug.Log("CanAttack");
            }
        }
    }
}
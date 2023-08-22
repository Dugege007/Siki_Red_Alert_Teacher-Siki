using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：状态模式（有限状态机）
 * 敌人 追击状态
 * 
 * 创建时间：
 */

public class EnemyChaseState : IEnemyState
{
    private Vector3 mFinalPosition;

    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = EnemyStateID.Chase;
    }

    public override void DoBeforeEntering()
    {
        mFinalPosition = GameFacade.Instance.GetFinalPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].Position);
            mCharacter.NavMeshAgent.isStopped = false;
        }
        else
        {
            mCharacter.MoveTo(mFinalPosition);
            mCharacter.NavMeshAgent.isStopped = false;
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            float distance = Vector3.Distance(mCharacter.Position, targets[0].Position);
            if (distance <= mCharacter.ATKRange)
            {
                mFSMSystem.PerformTransition(EnemyTransition.CanAttack);
            }
        }
    }
}
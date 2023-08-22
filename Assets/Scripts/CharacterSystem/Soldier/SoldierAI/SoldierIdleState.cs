using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：状态模式（有限状态机）
 * 士兵 站立状态
 * 
 * 创建时间：
 */

public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = SoldierStateID.Idle;
    }

    public override void Act(List<ICharacter> targets)
    {
        mCharacter.PlayAnimation("stand");
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mFSMSystem.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}
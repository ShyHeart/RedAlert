using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyChaseState:IEnemyState
{
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter c) : base(fsm, c)
    {
        mStateID = EnemyStateID.Chase;
    }
    private Vector3 mTargetPosition;
    public override void DoBeforeEntering()
    {
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            //小于攻击距离的才进行攻击
            float distance = Vector3.Distance(mCharacter.position, targets[0].position);
            if (distance <= mCharacter.atkRange)
            {
                mFSM.PerformTransition(EnemyTransition.CanAttack);
            }
        }
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].position);
        } else
        {
            mCharacter.MoveTo(mTargetPosition);
        }
    }
}

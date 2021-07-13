using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSytem fsm,ICharacter c) : base(fsm,c) {mStateID=SoldierStateID.Idle ;}

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mFsm.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }

    public override void Act(List<ICharacter> targets)
    {
        mCharacter.PlayAnim("stand");
    }


}



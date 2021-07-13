using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SoldierAttackState:ISoldierState
{
    public SoldierAttackState(SoldierFSMSytem fsm,ICharacter c) : base(fsm,c){mStateID=SoldierStateID.Attack;}

    private float mAttackTime = 1;
    private float mAttackTimer = 1;

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFsm.PerformTransition(SoldierTransition.NoEnmey); return;
        }
        //判断敌人是否在攻击范围内
        float distance = Vector3.Distance(mCharacter.position, targets[0].position);
        if (distance > mCharacter.atkRange)
        {
            mFsm.PerformTransition(SoldierTransition.SeeEnemy); 
        }
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0) return;
        mAttackTimer += Time.deltaTime;
        if (mAttackTimer >= mAttackTime)
        {
            mCharacter.Attack(targets[0]);
            mAttackTimer = 0;
        }
    }
}



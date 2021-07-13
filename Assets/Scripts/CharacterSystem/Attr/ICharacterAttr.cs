﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ICharacterAttr
{
    protected string mName;
    protected int mMaxHp;
    protected float mMoveSpeed;

    protected int mCurrentHp;

    protected string mIconSprite;

    protected int mLv;
    protected float mCritRate;//0-1暴击率

    protected int mDmgDescValue;

    public ICharacterAttr(IAttrStrategy strategy)
    {
        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHp = mMaxHp + mStrategy.GetExtraHPValue(mLv);
    }
    //增加的最大血量  抵御的伤害值  暴击增加的伤害 的策略

    protected IAttrStrategy mStrategy;
    public int critValue{get{return mStrategy.GetCritDmg(mCritRate);}}
    //public int dmgDescValue{get{return mStrategy.GetDmgDescValue(mLv);}}
    public int currentHP{get{return mCurrentHp;}}

    public void TakeDmage(int damege)
    {
        damege -= mDmgDescValue;
        if (damege < 5) damege = 5;

        mCurrentHp -= damege;
    }
}
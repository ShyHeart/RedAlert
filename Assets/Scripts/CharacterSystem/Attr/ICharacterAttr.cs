using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ICharacterAttr
{

    protected CharacterBaseAttr mBaseAttr;

    protected int mCurrentHp;
    protected int mLv;
    protected float mCritRate;//0-1暴击率

    protected int mDmgDescValue;

    public ICharacterAttr(IAttrStrategy strategy,int lv, CharacterBaseAttr baseAttr)
    {

        mLv = lv;
        mBaseAttr = baseAttr;
        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHp = baseAttr.maxHP + mStrategy.GetExtraHPValue(mLv);
    }
    //增加的最大血量  抵御的伤害值  暴击增加的伤害 的策略

    protected IAttrStrategy mStrategy;
    public int critValue{get{return mStrategy.GetCritDmg(mBaseAttr.critRate);}}
    public int currentHP { get { return mCurrentHp; } }
    //public int dmgDescValue{get{return mStrategy.GetDmgDescValue(mLv);}}
    public IAttrStrategy strategy { get { return mStrategy; } }
    public CharacterBaseAttr baseAttr { get { return mBaseAttr; } }

    public void TakeDmage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5) damage = 5;

        mCurrentHp -= damage;
    }
}
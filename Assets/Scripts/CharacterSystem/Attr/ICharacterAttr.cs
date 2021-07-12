using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ICharacterAttr
{
    protected string mName;
    protected string mMaxHp;
    protected float mMoveSpeed;

    protected int mCurrentHp;

    protected string mIconSprite;

    protected int mLv;
    protected float mCritRate;//0-1暴击率
    //增加的最大血量  抵御的伤害值  暴击增加的伤害 的策略

    protected IAttrStrategy mStrategy;

}
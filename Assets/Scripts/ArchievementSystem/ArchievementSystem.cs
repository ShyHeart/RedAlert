using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArchievementSystem : IGameSystem
{

    private int mEnemyKilledCount = 0;
    private int mSoldieryKilledCount = 0;
    private int mMaxStageLv = 1;
    public override void Init()
    {
        base.Init();
        mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKillObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.NewStage, new NewStageObserverArchievement(this));
    }
    public void AddEnemyKilledCount(int number = 1)
    {
        mEnemyKilledCount += number;
        //Debug.Log("EnemyKilledCount" + mEnemyKilledCount);
    }
    public void AddSoldierKilledCount(int number = 1)
    {
        mSoldieryKilledCount += number;
        //Debug.Log("SoldierKilledCount" + mSoldieryKilledCount);
    }
    public void SetMaxStageLv(int stageLv)
    {
        if (stageLv > mMaxStageLv)
        {
            mMaxStageLv = stageLv;
        }
        //Debug.Log("MaxStageLv" + mMaxStageLv);
    }
}

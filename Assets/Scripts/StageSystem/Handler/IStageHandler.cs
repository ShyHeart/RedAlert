﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IStageHandler
{
    protected int mLv;//关卡数量
    private int mCountToFinished;
    protected StageSystem mStageSystem;
    protected IStageHandler mNextHandler;

    public IStageHandler(StageSystem stageSystem, int lv, int countToFinished)
    {
        mStageSystem = stageSystem;
        mLv = lv;
        mCountToFinished = countToFinished;
    }

    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }


    public void Handle(int level)
    {
        if (level == mLv)
        {
            UpdateStage();
            CheckIsFinished();//检查关卡是否结束
        } else
        {
            mNextHandler.Handle(level);
        }
    }
    protected virtual void UpdateStage() { }
    private void CheckIsFinished()
    {
        if (mStageSystem.GetCountOfEnemyKilled() >= mCountToFinished)
        {
            mStageSystem.EnterNextStage();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SoldierFSMSytem
{
    private List<ISoldierState> mStates = new List<ISoldierState>();

    private ISoldierState mCurrentState;
    public ISoldierState currentState{get{return mCurrentState;}}

    //参数数组
    public void AddState(params ISoldierState[] states)
    {
        foreach (ISoldierState s in states)
        {
            AddState(s);
        }
    }
    //单个参数
    public void AddState(ISoldierState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空"); return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("要添加的状态ID[" + s.stateID + "]已经添加"); return;
            }
        }
        mStates.Add(state);
    }
    public void DeleteState(SoldierStateID stateID)
    {
        if (stateID == SoldierStateID.NullState)
        {
            Debug.LogError("要删除的状态ID为空" + stateID); return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID == stateID)
            {
                mStates.Remove(s); return;
            }
        }
        Debug.LogError("要删除的StateID不存在集合中:" + stateID);
    }

    /// <summary>
    /// 转换状态
    /// </summary>
    /// <param name="trans">装换条件</param>
    public void PerformTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTansition)
        {
            Debug.LogError("要执行的转换条件为空 ： " + trans); return;
        }
        SoldierStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == SoldierStateID.NullState)
        {
            Debug.LogError("在转换条件 [" + trans + "] 下，没有对应的转换状态"); return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.stateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInfoUI:IBaseUI
{

    private List<GameObject> mHearts;
    private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mCurrentStage;
    private Button mPauseBtn;
    private GameObject mGameOverUI;
    private Button mBackMenuBtn;
    private Text mMessage;
    private Slider mEnergySlider;
    private Text mEnergyText;

    private float mMsgTimer = 0;
    private int mMsgTime = 2;
    private AliveCountVisitor mAliveCountVisitor = new AliveCountVisitor();

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GameStateUI");

        GameObject heart1 = UnityTool.FindChild(mRootUI, "Heart1");
        GameObject heart2 = UnityTool.FindChild(mRootUI, "Heart2");
        GameObject heart3 = UnityTool.FindChild(mRootUI, "Heart3");
        mHearts = new List<GameObject>();
        mHearts.Add(heart1);
        mHearts.Add(heart2);
        mHearts.Add(heart3);
        mSoldierCount = UITool.FindChild<Text>(mRootUI, "SoldierCount");

        mEnemyCount = UITool.FindChild<Text>(mRootUI, "EnemyCount");
        mCurrentStage = UITool.FindChild<Text>(mRootUI, "StageCount");
        mPauseBtn = UITool.FindChild<Button>(mRootUI, "PauseBtn");
        mGameOverUI = UnityTool.FindChild(mRootUI, "GameOver");
        mBackMenuBtn = UITool.FindChild<Button>(mRootUI, "BackMenuBtn");
        mMessage = UITool.FindChild<Text>(mRootUI, "Message");
        mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");
        mEnergyText = UITool.FindChild<Text>(mRootUI, "EnergyText");

        mMessage.text = "";
        mGameOverUI.SetActive(false);
    }
    public override void Update()
    {
        base.Update();
        UpdateAliveCount();
        if (mMsgTimer > 0)
        {
            mMsgTimer -= Time.deltaTime;
            if (mMsgTimer <= 0)
            {
                mMessage.text = "";
            }
        }
    }
    public void ShowMsg(string msg)
    {
        mMessage.text = msg;
        mMsgTimer = mMsgTime;
    }
    public void UpdateEnergySlider(int nowEnergy, int maxEnergy)
    {
        mEnergySlider.value = (float)nowEnergy / maxEnergy;
        mEnergyText.text = "(" + nowEnergy + "/" + maxEnergy + ")";
    }
    public void UpdateAliveCount()
    {
        mAliveCountVisitor.Reset();
        mFacade.RunVisitor(mAliveCountVisitor);
        mSoldierCount.text = mAliveCountVisitor.soldierCount.ToString();
        mEnemyCount.text = mAliveCountVisitor.enemyCount.ToString();
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class IBaseUI
{
    protected GameFacade mFacade;

    public GameObject mRootUI;
    public virtual void Init() {
        mFacade = GameFacade.Instance;
    }
    public virtual void Update() { }
    public virtual void Release() { }


    protected void Show()
    {
        mRootUI.SetActive(true);
    }
    protected void Hide()
    {
        mRootUI.SetActive(false);
    }
}
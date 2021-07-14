
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class ICamp
{
    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;
    protected Vector3 mPosition;//集合点
    protected float mTrainTime;


    public ICamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position,float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
    }

    public virtual void Update() 
    {

    }
    public string name { get { return mName; } }
    public string iconSprite { get { return mIconSprite; } }

    public abstract int lv { get; }
    public abstract WeaponType weaponType { get; }


}

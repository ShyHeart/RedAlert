﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;


public abstract class ICharacter
{
    protected ICharacterAttr mAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudio;
    protected Animation mAnim;
    protected IWeapon mWeapon;

    protected bool mIsKilled = false;
    protected bool mCanDestroy = false;
    protected float mDestroyTimer = 2f;

    public Vector3 position
    {
        get
        {
            if (mGameObject == null)
            {
                Debug.LogError("mGameObject为空"); return Vector3.zero;
            }

            return mGameObject.transform.position;

        }
    }

    public float atkRange { get { return mWeapon.atkRange; } }
    public ICharacterAttr attr { set { mAttr = value; } get { return mAttr; } }
    public bool canDestroy { get { return mCanDestroy; } }
    public bool isKilled { get { return mIsKilled; } }
    public GameObject gameObject
    {
        set
        {
            mGameObject = value;
            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudio = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponentInChildren<Animation>();
        }
        get
        {
            return mGameObject;
        }
    }
    public IWeapon weapon
    {
        set
        {
            mWeapon = value;
            mWeapon.owenr = this;
            //Transform weaponPoint = mGameObject.transform.find TODO
            GameObject child = UnityTool.FindChild(mGameObject, "weapon-point");
            UnityTool.Attach(child, mWeapon.gameobject);
        }
        get
        {
            return mWeapon;
        }
    }

    public void Update()
    {
        if (mIsKilled)
        {
            mDestroyTimer -= Time.deltaTime;
            if (mDestroyTimer <= 0)
            {
                mCanDestroy = true;
            }
            return;
        }

        mWeapon.Update();
    }

    public abstract void UpdateFSMAI(List<ICharacter> targets);
    public abstract void RunVisitor(ICharacterVisitor visitor);
    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.position);
        mGameObject.transform.LookAt(target.position);
        PlayAnim("attack");
        //暴击值和武器的攻击 造成的伤害
        target.UnderAttack(mWeapon.atk+mAttr.critValue);
    }

    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDmage(damage);

        //被攻击的效果 音效 视效  只有敌人有


        //死亡的效果   只有战士有
    }
    public virtual void Killed()
    {
        mIsKilled = true;
        mNavAgent.Stop();

    }

    public void Release()
    {
        GameObject.Destroy(mGameObject);
    }
    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        mNavAgent.SetDestination(targetPosition);
        PlayAnim("move");

    }
    protected void DoPlayEffect(string effectname)
    {
        //加载特效
        GameObject effectGO = FactoryManager.assetFactory.LoadEffect(effectname);
        effectGO.transform.position = position;
        //控制销毁
        effectGO.AddComponent<DestoryForTime>();
    }

    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(soundName);
        mAudio.clip = clip;
        mAudio.Play();
    }

}

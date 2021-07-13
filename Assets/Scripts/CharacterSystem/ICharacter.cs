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

    public IWeapon weapon
    {
        set
        {
            mWeapon = value;
            mWeapon.owenr = this;
            GameObject chid = UnityTool.FindChild(mGameObject, "weapon-point");
            UnityTool.Attach(chid,mWeapon.gameobject);
        }
    }

    public Vector3 position
    {
        get
        {
            if (mGameObject == null)
            {
                Debug.LogError("mGameObject为空");
                return Vector3.zero;
            }

            return mGameObject.transform.position;

        }
    }

    public float atkRange
    {
        get { return mWeapon.atcRange; }
    }

    public ICharacterAttr attr{set{mAttr=value;}}

    public GameObject gameobject
    {
        set
        {
            mGameObject = value;
            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudio = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponentInChildren<Animation>();
        }
    }


    public void Update()
    {
        mWeapon.Update();
    }

    public abstract void UpdateFSMAI(List<ICharacter> targets);
    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.position);
        mGameObject.transform.LookAt(target.position);
        PlayAnim("attack");
        //暴击值和武器的攻击 造成的伤害
        target.UnderAttack(mWeapon.atk+mAttr.critValue);
    }

    public virtual void UnderAttack(int damag)
    {
        mAttr.TakeDmage(damag);

        //被攻击的效果 音效 视效  只有敌人有


        //死亡的效果   只有战士有
    }

    public void Killed()
    {

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

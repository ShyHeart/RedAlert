﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public enum WeaponType
{
    Gun=0,
    Rifle=1,
    Rocket=2,
    MAX
}
public abstract class IWeapon
{
    //protected int atkplusValue;
    protected WeaponBaseAttr mBaseAttr;

    protected GameObject gameObject;
    protected ICharacter Owner;
    protected ParticleSystem _particleSystem;
    protected LineRenderer _line;
    protected Light _light;
    protected AudioSource audio;

    protected float _EffectDisplayTime;


    public float atkRange { get { return mBaseAttr.atkRange; } }
    public int atk{get{return mBaseAttr.atk;}}
    public ICharacter owenr { set { Owner = value; } }

    public GameObject gameobject{get{return gameObject;}}

    public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        this.gameObject = gameObject;
        Transform effect = gameObject.transform.Find("Effect");
        _particleSystem = effect.GetComponent<ParticleSystem>();
        _line = effect.GetComponent<LineRenderer>();
        _light = effect.GetComponent<Light>();
        audio = effect.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (_EffectDisplayTime > 0)
        {
            _EffectDisplayTime -= Time.deltaTime;
            if (_EffectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }


    public void Fire(Vector3 targetPosition)
    {
        //显示枪口特效
        PlayMuzzleEffect();

        //显示子弹轨迹特效
        PlayBulletEffect(targetPosition);

        //设置特效显示时间
        SetEffetDisplayTime();

        //播放声音
        PlaySound();
    }

    protected abstract void SetEffetDisplayTime();

    protected virtual void PlayMuzzleEffect()
    {
        _particleSystem.Stop();
        _particleSystem.Play();
        _light.enabled = true;
    }

    protected abstract void PlayBulletEffect(Vector3 targetPosition);

    protected void DoPlayBulletEffect(float width,Vector3 targetPosition)
    {
        _line.enabled = true;
        _line.startWidth = width; _line.endWidth = width;
        _line.SetPosition(0, gameObject.transform.position);
        _line.SetPosition(1, targetPosition);
    }

    protected abstract void PlaySound();

    protected void DoPlaySound(string clipName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName);
        audio.clip = clip;
        audio.Play();
    }

    private void DisableEffect()
    {
        _line.enabled = false;
        _light.enabled = false;
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    /*public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("显示特效 Rifle");
        Debug.Log("播放声音 Rifle");

        //显示枪口特效
        _particleSystem.Stop();
        _particleSystem.Play();
        _light.enabled = true;

        //显示子弹轨迹特效
        _line.enabled = true;
        _line.startWidth = 0.1f;
        _line.endWidth = 0.1f;
        _line.SetPosition(0, gameObject.transform.position);
        _line.SetPosition(1, targetPosition);

        //播放声音
        string clipName = "RifleShot";
        AudioClip clip = null;
        audio.clip = clip;
        audio.Play();

    }*/
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.1f, targetPosition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }
    protected override void SetEffetDisplayTime()
    {
        _EffectDisplayTime = 0.3f;
    }

    public WeaponRifle(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr , gameObject)
    {
    }
}

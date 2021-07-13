using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class WeaponGun : IWeapon
{
    /*public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("显示特效 Gun");
        Debug.Log("播放声音 Gun");

        //显示枪口特效
        _particleSystem.Stop();
        _particleSystem.Play();
        _light.enabled = true;

        //显示子弹轨迹特效
        _line.enabled = true;
        _line.startWidth = 0.05f;
        _line.endWidth = 0.05f;
        _line.SetPosition(0,gameObject.transform.position);
        _line.SetPosition(1,targetPosition);

        //播放声音
        string clipName = "GunShot";
        AudioClip clip = null;
        audio.clip = clip;
        audio.Play();
    }*/

     
    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.05f, targetPosition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("GunShot");
    }

    protected override void SetEffetDisplayTime()
    {
        _EffectDisplayTime = 0.2f;
    }

    public WeaponGun(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject)
    {
    }
}
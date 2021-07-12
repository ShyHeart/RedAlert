using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class IWeapon
{
    protected int atk;
    protected float atkRange;
    protected int atkplusValue;

    protected GameObject gameObject;
    protected ICharacter Owner;
    protected ParticleSystem _particleSystem;
    protected LineRenderer _line;
    protected Light _light;
    protected AudioSource audio;


    public abstract void Fire(Vector3 targetPosition);
}
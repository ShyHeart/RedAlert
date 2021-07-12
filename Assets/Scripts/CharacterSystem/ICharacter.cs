using System;
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
    protected NavMeshAgent mNavMeshAgent;
    protected AudioSource mAudio;

    protected IWeapon iWeapon;

    public IWeapon weapon
    {
        set { iWeapon = value; }
    }

    public void Attack(Vector3 targetPosition)
    {
        iWeapon.Fire(targetPosition);
    }
}

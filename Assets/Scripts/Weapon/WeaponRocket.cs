using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponRocket:IWeapon
{
    public override void Fire(Vector3 targetPosition)
    {
        Debug.Log("显示特效 Rocket");
        Debug.Log("播放声音 Rocket");

    }

}

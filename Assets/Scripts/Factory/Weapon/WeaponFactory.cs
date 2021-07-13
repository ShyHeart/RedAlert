using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponFactory:IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        string assrtName = "";
        switch (weaponType)
        {
            case WeaponType.Gun:
                assrtName = "WeaponGun";
                break;
            case WeaponType.Rifle:
                assrtName = "WeaponRifle";
                break;
            case WeaponType.Rocket:
                assrtName = "WeaponRocket";
                break;
        }

        GameObject weaponGO = FactoryManager.assetFactory.LoadWeapon(assrtName);

        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(20,5,weaponGO);
                break;
            case WeaponType.Rifle:
                weapon = new WeaponRifle(30, 7, weaponGO);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(40, 8, weaponGO);
                break;
        }

        return weapon;
    }
}

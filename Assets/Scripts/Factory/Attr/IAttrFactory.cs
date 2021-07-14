using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public interface  IAttrFactory
{
    CharacterBaseAttr GetCharacterBaseAttr(Type t );
    WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType);
}

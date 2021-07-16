using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierBuilder:ICharacterBuilder
{

    public SoldierBuilder(ICharacter character, System.Type t, WeaponType weaponType, Vector3 spawnPosition, int lv):base(character,t,weaponType,spawnPosition,lv)
    {}
    public override void AddCharacterAttr()
    {
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mT);
        mPrefabName = baseAttr.prefabName;
        ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), mLv, baseAttr);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        //创建角色物体
        //加载   实例化
        //添加武器
        GameObject characterGO = FactoryManager.assetFactory.LoadSoldier(mPrefabName);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.gameObject = characterGO;
    }

    public override void AddWeapon()
    {
        //添加武器
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddSoldier(mCharacter as  ISoldier);
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }

}

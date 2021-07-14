using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, System.Type t, WeaponType weaponType, Vector3 spawnPosition, int lv)
        : base(character, t, weaponType, spawnPosition, lv)
    { }
    public override void AddCharacterAttr()
    {
        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";
        if (mT == typeof(EnemyElf))
        {
            name = "小精灵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            mPrefabName = "Enemy1";
        }
        else if (mT == typeof(EnemyOgre))
        {
            name = "怪物";
            maxHP = 120;
            moveSpeed = 4;
            iconSprite = "OgreIcon";
            mPrefabName = "Enemy2";

        }
        else if (mT == typeof(EnemyTroll))
        {
            name = "巨魔";
            maxHP = 200;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            mPrefabName = "Enemy3";

        }
        else
        {
            Debug.LogError("类型" + mT + "不属于IEmeny,无法创建敌人");

        }
        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), mLv, name, maxHP, moveSpeed, iconSprite, mPrefabName);
        mCharacter.attr = attr;
    }

    public override void AddGameObject()
    {
        GameObject characterGO = FactoryManager.assetFactory.LoadEnemy(mPrefabName);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.gameobject = characterGO;
    }

    public override void AddWeapon()
    {
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }

}

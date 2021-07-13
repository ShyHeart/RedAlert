using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IAssetFactory
{
    GameObject LoadSoldier(string name);
    GameObject LoadEnemy(string name);
    GameObject LoadWeapon(string name);
    GameObject LoadEffect(string name);
    AudioClip LoadAudioClip(string name);
    Sprite LoadSprite(string name);
}



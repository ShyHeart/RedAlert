using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EnemyAttr:ICharacterAttr
{
    public EnemyAttr(IAttrStrategy strategy,int lv, string name,int maxHP,float moveSpeed,string iconSprite,string PrefabName) : base(strategy,lv, name, maxHP, moveSpeed, iconSprite, PrefabName)
    {
    }
}

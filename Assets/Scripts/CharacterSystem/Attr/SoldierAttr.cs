using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SoldierAttr:ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy,int lv, CharacterBaseAttr baseAttr) 
        : base(strategy,lv, baseAttr)
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SoldierSergeant : ISoldier
{
    protected override void PlaySound()
    {
        DoPlaySound("SergeantDeadEffect");
    }

    protected override void PlayEffect()
    {
        DoPlayEffect("SergeantDeadEffect");
    }
}
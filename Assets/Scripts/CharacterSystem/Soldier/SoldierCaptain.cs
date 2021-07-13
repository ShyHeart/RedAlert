using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SoldierCaptain : ISoldier
{
    protected override void PlaySound()
    {
        DoPlaySound("CaptainDeath");
    }

    protected override void PlayEffect()
    {
        DoPlayEffect("CaptainDeadEffect");
    }
}
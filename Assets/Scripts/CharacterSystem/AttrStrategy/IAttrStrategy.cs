using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IAttrStrategy
{
    //增加的最大血量  抵御的伤害值  暴击增加的伤害

     int GetExtraHPValue(int lv);
     int GetDmgDescValue(int lv);
     int GetCritDmg(float critRate);
}
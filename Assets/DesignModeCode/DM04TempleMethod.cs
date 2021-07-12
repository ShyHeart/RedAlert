using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class DM04TempleMethod:MonoBehaviour
{
    void Start()
    {
        IPeople people = new NorthPeople();
        people.Eat();
    }
}

public abstract class IPeople
{
    public void Eat()
    {
        OrderFoods();
        EatSomething();
        PayBill();
    }

    private void OrderFoods()
    {
        Debug.Log("点餐");
    }

    public virtual void EatSomething()
    {

    }

    private void PayBill()
    {
        Debug.Log("买单");
    }
}

public class NorthPeople:IPeople
{
    public override void EatSomething()
    {
        Debug.Log("我在吃面条");
    }
}

public class SouthPeople : IPeople
{
    public override void EatSomething()
    {
        Debug.Log("我在吃米饭");
    }
}
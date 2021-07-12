using System;
using UnityEngine;

public class DM03Strategy:MonoBehaviour
{
    void Start()
    {
        StrategyContext context = new StrategyContext();
        context.Strategy = new ConcreteStrategyA();
        context.Cal();
    }
}

public class StrategyContext
{
    public IStrategy Strategy;
    public void Cal()
    {
        Strategy.Cal();
    }
}

public interface IStrategy
{
    void Cal();
}

public class ConcreteStrategyA : IStrategy
{
    public void Cal()
    {
         Debug.Log("使用A策略计算");
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Cal()
    {
        Debug.Log("使用B策略计算");
    }
}




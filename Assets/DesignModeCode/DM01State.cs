using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM01State : MonoBehaviour
{
    void Start()
    {
        Context context = new Context();
        context.SetState(new ConcreateStateA(context));

        context.Handle(5);
        context.Handle(20);
        context.Handle(40);
        context.Handle(4);
    }
}

/// <summary>
/// 状态模式原型代码实现
/// </summary>
public class Context
{
    private IState _state;

    //设置Context的状态
    public void SetState(IState state)
    {
        _state = state;
    }

    //只需要调用Context里的Handle方法
    public void Handle(int arg)
    {
        _state.Handle(arg);
    }
}

public interface IState
{
    void Handle(int arg);
}

public class ConcreateStateA : IState
{
    private Context _context;
    //构造方法声明一下Context
    public ConcreateStateA(Context context)
    {
        _context = context;
    }

    public void Handle(int arg)
    {
        if (arg > 10)
        {
            //切换到状态B
            _context.SetState(new ConcreateStateB(_context));
        }

        Debug.Log("当前是A状态处理" + arg);
    }
}
public class ConcreateStateB : IState
{
    private Context _context;
    //构造方法声明一下Context
    public ConcreateStateB(Context context)
    {
        _context = context;
    }

    public void Handle(int arg)
    {
        if (arg <= 10)
        {
            _context.SetState(new ConcreateStateA(_context));
        }

        Debug.Log("当前是B状态处理" + arg);
    }
}

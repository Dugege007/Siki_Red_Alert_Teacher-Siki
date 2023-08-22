using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：状态模式
 * 
 * 创建时间：
 */

public class DM01_State : MonoBehaviour
{
    private void Start()
    {
        Context context = new Context();
        context.SetState(new ConcreteStateA(context));
        context.Handle(5);
        context.Handle(15);
        context.Handle(25);
        context.Handle(35);
    }
}

public class Context
{
    private IState mState;

    public void SetState(IState state)
    {
        mState = state;
    }

    public void Handle(int arg)
    {
        mState.Handle(arg);
    }
}

public interface IState
{
    void Handle(int arg);
}

public class ConcreteStateA : IState
{
    private Context mContext;
    public ConcreteStateA(Context context)
    {
        mContext = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateA" + arg);
        if (arg > 10)
        {
            // 转换到B状态B
            mContext.SetState(new ConcreteStateB(mContext));
        }
    }
}

public class ConcreteStateB : IState
{
    private Context mContext;
    public ConcreteStateB(Context context)
    {
        mContext = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateB" + arg);
        if (arg > 20)
        {
            // 转换到B状态C
            mContext.SetState(new ConcreteStateB(mContext));
        }
    }
}

public class ConcreteStateC : IState
{
    private Context mContext;
    public ConcreteStateC(Context context)
    {
        mContext = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateC" + arg);
        if (arg > 30)
        {
            // 转换到B状态A
            mContext.SetState(new ConcreteStateC(mContext));
        }
    }
}
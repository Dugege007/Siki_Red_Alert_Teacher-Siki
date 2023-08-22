using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：责任链模式
 * 创建时间：
 */

public class DM08_ChainOfResponsibility : MonoBehaviour
{
    // 用户
    private void Start()
    {
        char problem = 'c';

        // 不使用责任链模式
        //switch (problem)
        //{
        //    case 'a':
        //        new DMHandlerA().Handle();
        //        break;
        //    case 'b':
        //        new DMHandlerB().Handle();
        //        break;
        //    default:
        //        break;
        //}

        // 使用责任链模式
        DMHandlerA handlerA = new DMHandlerA();
        DMHandlerB handlerB = new DMHandlerB();
        DMHandlerC handlerC = new DMHandlerC();
        //handlerA.NextHandler = handlerB;
        //handlerB.NextHandler = handlerC;
        handlerA.SetNextHandler(handlerB).SetNextHandler(handlerC); // 太妙了

        handlerA.Handle(problem);
    }
}

public abstract class IDMHandler
{
    protected IDMHandler mNextHandler = null;
    public IDMHandler NextHandler { set { mNextHandler = value; } }

    public virtual void Handle(char problem) { }

    public IDMHandler SetNextHandler(IDMHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }
}

public class DMHandlerA : IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'a')
            Debug.Log("处理完了A问题");
        else
        {
            if (mNextHandler != null)
                mNextHandler.Handle(problem);
        }
    }
}

public class DMHandlerB : IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'b')
            Debug.Log("处理完了B问题");
        else
        {
            if (mNextHandler != null)
                mNextHandler.Handle(problem);
        }
    }
}

public class DMHandlerC : IDMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'c')
            Debug.Log("处理完了C问题");
        else
        {
            if (mNextHandler != null)
                mNextHandler.Handle(problem);
        }
    }
}
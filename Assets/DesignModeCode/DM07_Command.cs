using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：命令模式
 * 
 * 创建时间：
 */

public class DM07_Command : MonoBehaviour
{
    private void Start()
    {
        DMInvoker invoker = new DMInvoker();
        ConcreteCommand1 cmd1 = new ConcreteCommand1(new DMReceiver1());
        invoker.AddCommand(cmd1);

        invoker.ExecuteCommand();
    }
}

/// <summary>
/// 命令调用者
/// </summary>
public class DMInvoker
{
    private List<DMICommand> commands = new List<DMICommand>();

    public void AddCommand(DMICommand cmd)
    {
        commands.Add(cmd);
    }

    public void ExecuteCommand()
    {
        foreach(DMICommand cmd in commands)
        {
            cmd.Execute();
        }
        commands.Clear();
    }
}

/// <summary>
/// 命令基类
/// </summary>
public abstract class DMICommand
{
    public abstract void Execute();
}

/// <summary>
/// 命令实现
/// </summary>
public class ConcreteCommand1 : DMICommand
{
    private DMReceiver1 mReceiver1;
    public ConcreteCommand1(DMReceiver1 receiver1)
    {
        mReceiver1 = receiver1;
    }
    public override void Execute()
    {
        mReceiver1.Action("Command1");
    }
}

/// <summary>
/// 命令接收者
/// </summary>
public class DMReceiver1
{
    public void Action(string cmd)
    {
        Debug.Log("Receiver1执行了命令" + cmd);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：备忘录模式
 * 创建时间：
 */

public class DM10_Memento : MonoBehaviour
{


    private void Start()
    {
        //Originater originater = new Originater();
        //originater.SetState("State01");
        //originater.ShowState();
        //Memento memento = originater.CreateMemento();   // 创建快照
        //originater.SetState("State02");
        //originater.ShowState();
        //originater.SetMemento(memento);                 // 恢复快照

        CareTaker careTaker = new CareTaker();
        Originater originater = new Originater();
        originater.SetState("State01");
        originater.ShowState();
        careTaker.AddMemento("V1", originater.CreateMemento());   // 创建快照
        originater.SetState("State02");
        originater.ShowState();
        careTaker.AddMemento("V2", originater.CreateMemento());   // 创建快照
        originater.SetState("State03");
        originater.ShowState();
        careTaker.AddMemento("V3", originater.CreateMemento());   // 创建快照

        originater.SetMemento(careTaker.GetMemento("V1"));        // 恢复快照
    }
}

public class Originater
{
    private string mState;

    public void SetState(string state)
    {
        mState = state;
    }

    public void ShowState()
    {
        Debug.Log("Originator State: " + mState);
    }

    public Memento CreateMemento()
    {
        Memento memento = new Memento();
        memento.SetState(mState);
        return memento;
    }

    public void SetMemento(Memento memento)
    {
        SetState(memento.GetState());
    }
}

public class Memento
{
    private string mState;

    public void SetState(string state)
    {
        mState = state;
    }

    public string GetState()
    {
        return mState;
    }
}

public class CareTaker
{
    Dictionary<string, Memento> mMementoDict = new Dictionary<string, Memento>();
    public void AddMemento(string key, Memento memento)
    {
        mMementoDict.Add(key, memento);
    }

    public Memento GetMemento(string version)
    {
        if (mMementoDict.ContainsKey(version) == false)
        {
            Debug.LogError("快照字典中不包含Key：" + version);
            return null;
        }
        return mMementoDict[version];
    }
}
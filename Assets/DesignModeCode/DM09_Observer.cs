using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：观察者模式
 * 创建时间：
 */

public class DM09_Observer : MonoBehaviour
{
    private void Start()
    {
        // 非观察者模式
        //WeatherStation weatherStation = new WeatherStation();
        //BillboardA billboardA = new BillboardA();
        //BillboardB billboardB = new BillboardB();
        //BillboardC billboardC = new BillboardC();
        //weatherStation.Update(billboardA, billboardB, billboardC);

        // 观察者模式
        ConcreteSubject1 sub1 = new ConcreteSubject1();

        ConcreteObserver1 ob1 = new ConcreteObserver1(sub1);
        ConcreteObserver2 ob2 = new ConcreteObserver2(sub1);

        sub1.RegisterObserver(ob1);
        sub1.RegisterObserver(ob2);

        sub1.SubjectState = "天气晴朗 26摄氏度";
    }

}

#region 非观察者模式
//public class WeatherStation
//{
//    public void Update(BillboardA a, BillboardB b, BillboardC c)
//    {
//        a.Show();
//        b.Show();
//        c.Show();
//    }
//}

//public class BillboardA
//{
//    public void Show()
//    {
//        Debug.Log("A布告板显示气象信息");
//    }
//}

//public class BillboardB
//{
//    public void Show()
//    {
//        Debug.Log("B布告板显示气象信息");
//    }
//}

//public class BillboardC
//{
//    public void Show()
//    {
//        Debug.Log("C布告板显示气象信息");
//    }
//}
#endregion

public abstract class Subject
{
    List<Observer> mObservers = new List<Observer>();

    public void RegisterObserver(Observer observer)
    {
        mObservers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        mObservers.Remove(observer);
    }

    public void NotifyObserver()
    {
        foreach (Observer observer in mObservers)
        {
            observer.Update();
        }
    }
}

public class ConcreteSubject1 : Subject
{
    private string mSubjectState;
    public string SubjectState
    {
        set
        {
            mSubjectState = value;
            NotifyObserver();
        }
        get { return mSubjectState; }
    }
}

public abstract class Observer
{
    public abstract void Update();
}

public class ConcreteObserver1 : Observer
{
    public ConcreteSubject1 mSub1;

    public ConcreteObserver1(ConcreteSubject1 sub1)
    {
        mSub1 = sub1;
    }

    public override void Update()
    {
        Debug.Log("Observer1 更新显示 " + mSub1.SubjectState);
    }
}

public class ConcreteObserver2 : Observer
{
    public ConcreteSubject1 mSub1;

    public ConcreteObserver2(ConcreteSubject1 sub1)
    {
        mSub1 = sub1;
    }

    public override void Update()
    {
        Debug.Log("Observer2 更新显示 " + mSub1.SubjectState);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：模板方法模式
 * 方便扩展、方便统一调整方法
 * 通常在需要解决某个需要一系列相同步骤才能完成的操作时使用
 * 
 * 创建时间：
 */

public class DM04_TempleMethod : MonoBehaviour
{
    private void Start()
    {
        IPeople people = new SouthPeople();
        people.Eat();
    }
}

public abstract class IPeople
{
    // 模板方法
    public void Eat()
    {
        OrderFoods();
        EatSomething();
        PayBill();
    }

    private void OrderFoods()
    {
        Debug.Log("点菜");
    }

    protected virtual void EatSomething()
    {
        Debug.Log("吃东西");
    }

    private void PayBill()
    {
        Debug.Log("买单");
    }
}

public class NorthPeople : IPeople
{
    protected override void EatSomething()
    {
        Debug.Log("我在吃面条");
    }
}

public class SouthPeople : IPeople
{
    protected override void EatSomething()
    {
        Debug.Log("我在吃米饭");
    }
}
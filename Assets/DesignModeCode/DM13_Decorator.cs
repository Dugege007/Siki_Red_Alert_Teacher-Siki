using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：装饰模式
 * 尽量少用，可能需要创建很多类，使项目变得臃肿
 * 
 * 创建时间：
 */

public class DM13_Decorator : MonoBehaviour
{
    private void Start()
    {
        Coffee coffee = new Espresso();
        coffee = coffee.AddDecorator(new Mocha());

        coffee = coffee.AddDecorator(new Whip());

        Debug.Log(coffee.Cost());
        Debug.Log(coffee.Capacity());
    }
}

public abstract class Coffee
{
    public abstract double Cost();
    public abstract double Capacity();
    public Coffee AddDecorator(Decorator decorator)
    {
        decorator.Coffee = this;
        return decorator;
    }
}

public class Espresso : Coffee
{
    public override double Capacity()
    {
        return 1;
    }

    public override double Cost()
    {
        return 2.5;
    }
}

public class Decaf : Coffee
{
    public override double Capacity()
    {
        return 1.5;
    }

    public override double Cost()
    {
        return 2;
    }
}

// 装饰基类
public class Decorator : Coffee
{
    protected Coffee mCoffee;
    public Coffee Coffee { get { return mCoffee; } set { mCoffee = value; } }

    public override double Capacity()
    {
        return mCoffee.Capacity();
    }

    public override double Cost()
    {
        return mCoffee.Cost();
    }

    //public Decorator(Coffee coffee)
    //{
    //    mCoffee = coffee;
    //}
}

// 装饰类 摩卡
public class Mocha : Decorator
{
    //public Mocha(Coffee coffee) : base(coffee)
    //{
    //}

    public override double Cost()
    {
        return mCoffee.Cost() + 0.1;
    }

    public override double Capacity()
    {
        return base.Capacity() + 0.2;
    }
}

// 装饰类 牛奶
public class Whip : Decorator
{
    //public Whip(Coffee coffee) : base(coffee)
    //{
    //}

    public override double Cost()
    {
        return mCoffee.Cost() + 0.2;
    }

    public override double Capacity()
    {
        return base.Capacity() + 0.3;
    }
}
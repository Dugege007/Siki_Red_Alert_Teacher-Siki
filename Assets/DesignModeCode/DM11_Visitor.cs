using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：访问者模式
 * 创建时间：
 */

public class DM11_Visitor : MonoBehaviour
{
    private void Start()
    {
        DMShapeContainer container = new DMShapeContainer();
        DMSphere sphere1 = new DMSphere();
        DMCylinder cylinder1 = new DMCylinder();
        DMCube cube1 = new DMCube();
        DMCube cube2 = new DMCube();

        container.AddShape(sphere1);
        container.AddShape(cylinder1);
        container.AddShape(cube1);
        container.AddShape(cube2);

        // 这样获取container中的图形总数还是可以的，但是如果想获取某个图形的个数，就需要修改DMShapeContainer了，不符合设计原则
        //int count = container.GetShapeCount();
        //int cubeCount = container.GetCubeCount();

        // 使用访问者模式
        // 访问者模式的好处是，如果想获取某个图形的个数，只需要增加一个访问者类，不需要修改DMShapeContainer
        AmountVisitor amountVisitor = new AmountVisitor();
        container.RunVisitor(amountVisitor);
        int amount = amountVisitor.amount;
        Debug.Log("图形总数：" + amount);

        CubeAmountVisitor cubeAmountVisitor = new CubeAmountVisitor();
        container.RunVisitor(cubeAmountVisitor);
        int cubeAmount = cubeAmountVisitor.amount;
        Debug.Log("Cube总数：" + cubeAmount);

        EdgeVisitor edgeVisitor = new EdgeVisitor();
        container.RunVisitor(edgeVisitor);
        int edgeAmount = edgeVisitor.amount;
        Debug.Log("图形总边数：" + edgeAmount);
    }
}

// 图形容器
public class DMShapeContainer
{
    private List<IDMShape> mShapes = new List<IDMShape>();

    public void AddShape(IDMShape shape)
    {
        mShapes.Add(shape);
    }

    #region 使用访问者模式之前
    //public int GetShapeCount()
    //{
    //    return mShapes.Count;
    //}

    //// 获取Cube的个数
    //public int GetCubeCount()
    //{
    //    int count = 0;
    //    foreach (var shape in mShapes)
    //    {
    //        if (shape.GetType() == typeof(DMCube))
    //            count++;
    //    }
    //    return count;
    //}

    //// 获取总体积
    //public int GetVolume()
    //{
    //    int temp = 0;
    //    foreach (var shape in mShapes)
    //    {
    //        temp += shape.GetVolume();
    //    }
    //    return temp;
    //}
    #endregion

    public void RunVisitor(IShapeVisitor visitor)
    {
        foreach (var shape in mShapes)
        {
            shape.RunVictor(visitor);
        }
    }
}

// 图形基类
public abstract class IDMShape
{
    public abstract int GetVolume();

    public abstract void RunVictor(IShapeVisitor visitor);
}

// 球体
public class DMSphere : IDMShape
{
    public override int GetVolume()
    {
        return 10;
    }

    public override void RunVictor(IShapeVisitor visitor)
    {
        visitor.VisitSphere(this);
    }
}

// 圆柱体
public class DMCylinder : IDMShape
{
    public override int GetVolume()
    {
        return 20;
    }

    public override void RunVictor(IShapeVisitor visitor)
    {
        visitor.VisitCylinder(this);
    }
}

// 立方体
public class DMCube : IDMShape
{
    public override int GetVolume()
    {
        return 30;
    }

    public override void RunVictor(IShapeVisitor visitor)
    {
        visitor.VisitCube(this);
    }
}

// 访问者基类
public abstract class IShapeVisitor
{
    public abstract void VisitSphere(DMSphere sphere);
    public abstract void VisitCylinder(DMCylinder cylinder);
    public abstract void VisitCube(DMCube cube);
}

// 访问图形总数
public class AmountVisitor : IShapeVisitor
{
    public int amount = 0;

    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        amount++;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        amount++;
    }
}

// 访问Cube总数
public class CubeAmountVisitor : IShapeVisitor
{
    public int amount = 0;

    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        return;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        return;
    }
}

// 访问总边数
public class EdgeVisitor : IShapeVisitor
{
    public int amount = 0;

    public override void VisitCube(DMCube cube)
    {
        amount += 12;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        amount += 2;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        amount += 0;
    }
}
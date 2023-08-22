using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式（核心：将抽象与实现分离，使二者可以独立变化）
 * 实现用一个渲染器绘制一个物体
 * 
 * 创建时间：
 */

public class DM02_Bridge : MonoBehaviour
{
    private void Start()
    {
        // 桥接模式演示
        //IRenderEngine renderEngine = new DirectX();

        //Sphere sphere = new Sphere(renderEngine);
        //Cube cube = new Cube(renderEngine);
        //Capsule capsule = new Capsule(renderEngine);
        //sphere.Draw();
        //cube.Draw();
        //capsule.Draw();

        ICharacter character = new SoldierCaptain();
        //WeaponGun gun = new WeaponGun();
        //character.mWeaponGun = gun;

        //WeaponRifle rifle= new WeaponRifle();
        //character.mWeaponRifle = rifle;

        //WeaponRocket rocket= new WeaponRocket();
        //character.mWeaponRocket = rocket;

        //character.Weapon = new WeaponGun();
        //character.Attack(Vector3.one);
    }
}

public class IShape
{
    public string name;
    public IRenderEngine mRenderEngine;
    public IShape(IRenderEngine renderEngine)
    {
        renderEngine = mRenderEngine;
    }

    public void Draw()
    {
        mRenderEngine.Render(name);
    }
}

public class Sphere : IShape
{
    public Sphere(IRenderEngine re) : base(re)
    {
        name = "Sphere";
    }
}

public class Cube : IShape
{
    public Cube(IRenderEngine re) : base(re)
    {
        name = "Cube";
    }
}

public class Capsule : IShape
{
    public Capsule(IRenderEngine re) : base(re)
    {
        name = "Capsule";
    }
}

public abstract class IRenderEngine
{
    public abstract void Render(string name);
}

public class OpenGL : IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log(name + " OpenGL 绘制完成");
    }
}

public class DirectX : IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log(name + " DirectX 绘制完成");
    }
}

public class SuperRender : IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log(name + " SuperRender 绘制完成");
    }
}
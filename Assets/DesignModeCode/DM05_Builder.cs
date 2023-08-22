using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：建造者模式
 * 创建时间：
 */

public class DM05_Builder : MonoBehaviour
{
    private void Start()
    {
        IBuilder fatBuilder = new FatPersonBuilder();
        IBuilder thinBuilder = new FatPersonBuilder();

        Person fatPerson = Director.Construct(fatBuilder);
        fatPerson.Show();

        Person thinPerson = Director.Construct(thinBuilder);
        thinPerson.Show();
    }
}

public class Person
{
    List<string> parts = new List<string>();

    public void AddPart(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        foreach (var p in parts)
        {
            Debug.Log(p);
        }
    }
}

public class FatPerson : Person
{

}

public class ThinPerson : Person
{

}

public interface IBuilder
{
    void AddHead();
    void AddBody();
    void AddFeet();
    void AddHands();

    Person GetResult();
}

public class FatPersonBuilder : IBuilder
{
    private Person person;

    public FatPersonBuilder()
    {
        person = new FatPerson();
    }

    public void AddBody()
    {
        person.AddPart("胖人身");
    }

    public void AddHands()
    {
        person.AddPart("胖人脚");
    }

    public void AddFeet()
    {
        person.AddPart("胖人手");
    }

    public void AddHead()
    {
        person.AddPart("胖人头");
    }

    public Person GetResult()
    {
        return person;
    }
}

public class ThinPersonBuilder : IBuilder
{
    private Person person;

    public ThinPersonBuilder()
    {
        person = new ThinPerson();
    }

    public void AddBody()
    {
        person.AddPart("瘦人身");
    }

    public void AddHands()
    {
        person.AddPart("瘦人脚");
    }

    public void AddFeet()
    {
        person.AddPart("瘦人手");
    }

    public void AddHead()
    {
        person.AddPart("瘦人头");
    }

    public Person GetResult()
    {
        return person;
    }
}

public class Director
{
    public static Person Construct(IBuilder builder)
    {
        builder.AddHead();
        builder.AddBody();
        builder.AddHands();
        builder.AddFeet();

        return builder.GetResult();
    }
}
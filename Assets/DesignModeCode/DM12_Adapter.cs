using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：适配器模式
 * 创建时间：
 */

public class DM12_Adapter : MonoBehaviour
{
    private void Start()
    {
        // 未使用适配器模式
        //StandardInterface standardInterface = new StandardImplementA();

        // 使用适配器模式
        Adapter adapter = new Adapter(new NewPlugin());
        StandardInterface standardInterface = adapter;

        standardInterface.Request();
    }
}

public interface StandardInterface
{
    void Request();
}

public class StandardImplementA : StandardInterface
{
    public void Request()
    {
        Debug.Log("使用标准方法实现请求");
    }
}

public class Adapter : StandardInterface
{
    private NewPlugin newPlugin = new NewPlugin();

    public Adapter(NewPlugin p)
    {
        newPlugin = p;
    }

    public void Request()
    {
        newPlugin.SpecificRequest();
    }
}

public class NewPlugin
{
    public void SpecificRequest()
    {
        Debug.Log("使用特殊的插件方法实现请求");
    }
}
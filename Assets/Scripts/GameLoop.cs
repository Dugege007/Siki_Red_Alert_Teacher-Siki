using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：游戏入口
 * 创建时间：2023年4月3日17:43:58
 */

public class GameLoop : MonoBehaviour
{
    private SceneStateController controller = null;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        controller = new SceneStateController();
        controller.SetState(new StartState(controller), false);
    }

    private void Update()
    {
        if (controller != null)
        {
            controller.StateUpdate();
        }
    }
}
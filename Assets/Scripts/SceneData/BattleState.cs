using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：状态模式
 * 用于战斗场景状态
 * 
 * 创建时间：
 */

public class BattleState : ISceneState
{
    public BattleState(SceneStateController controller) : base("03 BattleScene", controller)
    {

    }

    // 兵营 关卡 角色管理 行动力 成就系统
    // 外观模式
    private GameFacade mFacade;

    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }

    public override void StateUpdate()
    {
        if (GameFacade.Instance.IsGameOver)
        {
            mController.SetState(new MainMenuState(mController));
        }

        GameFacade.Instance.Update();
    }
}
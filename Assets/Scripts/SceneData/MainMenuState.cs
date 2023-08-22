using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 创建人：杜
 * 功能说明：状态模式
 * 主菜单状态
 * 
 * 创建时间：
 */

public class MainMenuState : ISceneState
{
    public MainMenuState(SceneStateController controller) : base("02 MainMenuScene", controller)
    {

    }



    public override void StateStart()
    {
        GameObject.Find("StartBuutton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        mController.SetState(new BattleState(mController));
    }
}
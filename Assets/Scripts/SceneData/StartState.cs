using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 创建人：杜
 * 功能说明：状态模式
 * 开始状态
 * 
 * 创建时间：
 */

public class StartState : ISceneState
{
    public StartState(SceneStateController controller) : base("01 StartScene", controller)
    {

    }

    private Image mLogo;
    private float mSmoothingSpeed = 1;
    private float mWaitTime = 2f;

    public override void StateStart()
    {
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
    }

    public override void StateUpdate()
    {
        mLogo.color = Color.Lerp(mLogo.color, Color.black, mSmoothingSpeed * Time.deltaTime);
        mWaitTime -= Time.deltaTime;
        if (mWaitTime <= 0)
        {
            mController.SetState(new MainMenuState(mController));
        }
    }
}
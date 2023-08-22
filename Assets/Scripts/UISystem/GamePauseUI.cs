using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 创建人：杜
 * 功能说明：游戏暂停UI
 * 创建时间：
 */

public class GamePauseUI : IBaseUI
{
    private Text mCurrentState;
    private Button mContinueBtn;
    private Button mBackToMenuBtn;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");

        mCurrentState = UITool.FindChildComponent<Text>(mRootUI, "CurrentState");
        mContinueBtn = UITool.FindChildComponent<Button>(mRootUI, "ContinueBtn");
        mBackToMenuBtn = UITool.FindChildComponent<Button>(mRootUI, "BackToMenuBtn");

        Hide();
    }
}
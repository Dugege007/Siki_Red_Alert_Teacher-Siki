using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 创建人：杜
 * 功能说明：士兵信息UI
 * 创建时间：
 */

public class SoldierInfoUI : IBaseUI
{
    private Image mSoldierIcon;
    private Text mSoldierLevel;
    private Text mHPNum;
    private Text mATKNum;
    private Text mATKRange;
    private Text mATKSpeed;
    private Text mMoveSpeed;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");

        mSoldierIcon = UITool.FindChildComponent<Image>(mRootUI, "SoldierIcon");
        mSoldierLevel = UITool.FindChildComponent<Text>(mRootUI, "SoldierLevel");
        mHPNum = UITool.FindChildComponent<Text>(mRootUI, "HPNum");
        mATKNum = UITool.FindChildComponent<Text>(mRootUI, "ATKNum");
        mATKRange = UITool.FindChildComponent<Text>(mRootUI, "ATKRange");
        mATKSpeed = UITool.FindChildComponent<Text>(mRootUI, "ATKSpeed");
        mMoveSpeed = UITool.FindChildComponent<Text>(mRootUI, "MoveSpeed");

        Hide();
    }
}
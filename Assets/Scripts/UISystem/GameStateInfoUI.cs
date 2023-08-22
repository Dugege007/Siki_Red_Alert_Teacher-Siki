using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 创建人：杜
 * 功能说明：游戏状态UI管理
 * 创建时间：
 */

public class GameStateInfoUI : IBaseUI
{
    private List<GameObject> mHearts = new List<GameObject>();
    private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mStageCount;
    private Button mPauseBtn;
    private GameObject mGameOverPanel;
    private Button mBackToMenuBtn;

    private AliveCountVisitor mAliveCountVisitor;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GameStateUI");

        for (int i = 1; i < 3; i++)
        {
            mHearts.Add(UnityTool.FindChild(mRootUI, "Heart" + i));
        }
        mSoldierCount = UITool.FindChildComponent<Text>(mRootUI, "SoldierCount");
        mEnemyCount = UITool.FindChildComponent<Text>(mRootUI, "EnemyCount");
        mStageCount = UITool.FindChildComponent<Text>(mRootUI, "StageCount");
        mPauseBtn = UITool.FindChildComponent<Button>(mRootUI, "PauseBtn");
        mGameOverPanel = UnityTool.FindChild(mRootUI, "GameOverPanel");
        mBackToMenuBtn = UITool.FindChildComponent<Button>(mRootUI, "BackToMenuBtn");
        mAliveCountVisitor = new AliveCountVisitor();

        Show();
        mGameOverPanel.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
        UpdateAliveCount();
    }

    public void UpdateAliveCount()
    {
        mAliveCountVisitor.Reset();
        mFacade.RunVisitor(mAliveCountVisitor);
        mSoldierCount.text = mAliveCountVisitor.SoldierCount.ToString();
        mEnemyCount.text = mAliveCountVisitor.EnemyCount.ToString();
    }
}
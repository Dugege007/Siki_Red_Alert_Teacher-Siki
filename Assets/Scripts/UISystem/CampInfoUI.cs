using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 创建人：杜
 * 功能说明：命令模式
 * 兵营UI
 * 
 * 创建时间：
 */

public class CampInfoUI : IBaseUI
{
    private ICamp mCamp;

    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLevel;
    private Text mWeaponLevel;
    private Button mCampUpgradeBtn;
    private Button mWeaponUpgradeBtn;
    private Button mTrainBtn;
    private Text mTrainBtnText;
    private Button mCancelTrainBtn;
    private Text mAliveCount;
    private Text mTrainCount;
    private Text mTrainTime;

    private Slider mEnergySlider;
    private Text mEnergyText;
    private Text mMessage;

    private float mMsgTimer = 0;
    private float mMsgTime = 2;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");

        mCampIcon = UITool.FindChildComponent<Image>(mRootUI, "CaptainCampIcon");
        mCampName = UITool.FindChildComponent<Text>(mRootUI, "CampName");
        mCampLevel = UITool.FindChildComponent<Text>(mRootUI, "CampLevel");
        mCampUpgradeBtn = UITool.FindChildComponent<Button>(mRootUI, "CampUpgradeBtn");
        mWeaponLevel = UITool.FindChildComponent<Text>(mRootUI, "WeaponLevel");
        mWeaponUpgradeBtn = UITool.FindChildComponent<Button>(mRootUI, "WeaponUpgradeBtn");
        mTrainBtn = UITool.FindChildComponent<Button>(mRootUI, "TrainBtn");
        mTrainBtnText = UITool.FindChildComponent<Text>(mRootUI, "TrainBtnText");
        mCancelTrainBtn = UITool.FindChildComponent<Button>(mRootUI, "CancelTrainBtn");
        mAliveCount = UITool.FindChildComponent<Text>(mRootUI, "AliveCount");
        mTrainCount = UITool.FindChildComponent<Text>(mRootUI, "TrainCount");
        mTrainTime = UITool.FindChildComponent<Text>(mRootUI, "TrainTime");

        mEnergySlider = UITool.FindChildComponent<Slider>(mRootUI, "EnergySlider");
        mEnergyText = UITool.FindChildComponent<Text>(mRootUI, "EnergyText");
        mMessage = UITool.FindChildComponent<Text>(mRootUI, "Message");

        mTrainBtn.onClick.AddListener(OnTrainBtnClick);
        mCancelTrainBtn.onClick.AddListener(OnCancelTrainBtnClick);

        mCampUpgradeBtn.onClick.AddListener(OnCampUpgradeClick);
        mWeaponUpgradeBtn.onClick.AddListener(OnWeaponUpgradeClick);

        mMessage.text = "";

        Hide();
    }

    public override void Update()
    {
        base.Update();
        ShowTrainingInfo();
        if (mMsgTimer > 0)
        {
            mMsgTimer -= Time.deltaTime;
            if (mMsgTimer <= 0)
                mMessage.text = "";
        }
    }

    public void ShowCampInfo(ICamp camp)
    {
        Show();
        //Debug.Log(camp.IconSprite);
        mCamp = camp;
        int energy = mCamp.TrainEnergyCost;
        mCampIcon.sprite = FactoryManager.AssetFactory.LoadSprite(camp.IconSprite);
        mCampName.text = camp.Name;
        mCampLevel.text = camp.Lv.ToString();
        ShowWeaponLevel(camp.WeaponType);
        mTrainBtnText.text = "训练\r\n" + energy + "点能量";
        ShowTrainingInfo();
    }

    private void ShowTrainingInfo()
    {
        if (mCamp != null)
        {
            mTrainCount.text = mCamp.TrainCount.ToString();

            if (mCamp.TrainCount == 0)
                mCancelTrainBtn.interactable = false;
            else
            {
                mCancelTrainBtn.interactable = true;
                mTrainTime.text = mCamp.TrainTimer.ToString("0.##");
            }
        }
    }

    private void ShowWeaponLevel(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Gun:
                mWeaponLevel.text = "手枪";
                break;
            case WeaponType.Rifle:
                mWeaponLevel.text = "来福枪";
                break;
            case WeaponType.Rocket:
                mWeaponLevel.text = "火箭炮";
                break;
            case WeaponType.MAX:
                break;
            default:
                break;
        }
    }

    private void OnTrainBtnClick()
    {
        int energy = mCamp.TrainEnergyCost;
        if (mFacade.TakeEnergy(energy))
            mCamp.Train();
        else
            mFacade.ShowMsg("能量不足，升级需要" + energy + "，请等待能量恢复");
    }

    private void OnCancelTrainBtnClick()
    {
        mFacade.RecycleEnergy(mCamp.TrainEnergyCost);
        mCamp.CancelTrainCommand();
    }

    private void OnCampUpgradeClick()
    {
        int energy = mCamp.CampUpgradeEnergyCost;
        if (energy < 0)
        {
            mFacade.ShowMsg("兵营已经达到最大等级");
            return;
        }

        if (mFacade.TakeEnergy(energy))
        {
            mCamp.UpgradeCamp();
            ShowCampInfo(mCamp);
        }
        else
        {
            mFacade.ShowMsg("能量不足，升级需要" + energy + "，请等待能量恢复");
        }
    }

    private void OnWeaponUpgradeClick()
    {
        int energy = mCamp.WeaponUpgradeEnergyCost;
        if (energy < 0)
        {
            mFacade.ShowMsg("武器已经达到最大等级");
            return;
        }

        if (mFacade.TakeEnergy(energy))
        {
            mCamp.UpgradeWeapon();
            ShowCampInfo(mCamp);
        }
        else
        {
            mFacade.ShowMsg("能量不足，升级需要" + energy + "，请等待能量恢复");
        }
    }

    public void ShowMsg(string msg)
    {
        mMessage.text = msg;
        mMsgTimer = mMsgTime;
    }

    public void UpdateEnergySlider(float currentEnergy, float maxEnergy)
    {
        mEnergySlider.value = currentEnergy;
        mEnergyText.text = currentEnergy.ToString("0.0") + " / " + maxEnergy.ToString("0");
    }
}
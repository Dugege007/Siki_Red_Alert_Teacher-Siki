using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：命令模式
 * 兵营接口
 * 
 * 创建时间：
 */

public abstract class ICamp
{
    protected GameObject mGameObj;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;
    protected Vector3 mMusterPos;
    protected float mTrainTime;
    private float mTrainTimer = 0;

    protected List<ITrainCommand> mTrainCommands;
    protected IEnergyCostStrategy mEnergyCostStrategy;
    protected int mCampUpgradeEnergyCost;
    protected int mWeaponUpgradeEnergyCost;
    protected int mTrainEnergyCost;

    public string Name { get { return mName; } }
    public string IconSprite { get { return mIconSprite; } }
    public abstract int Lv { get; }
    public abstract WeaponType WeaponType { get; }
    public int TrainCount { get { return mTrainCommands.Count; } }
    public float TrainTimer { get { return mTrainTimer; } }
    public abstract int CampUpgradeEnergyCost { get; }
    public abstract int WeaponUpgradeEnergyCost { get; }
    public abstract int TrainEnergyCost { get; }

    public ICamp(GameObject obj, string name, string icon, SoldierType soldierType, Vector3 musterPos, float trainTime)
    {
        mGameObj = obj;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mMusterPos = musterPos;
        mTrainTime = trainTime;
        mTrainTimer = mTrainTime;

        mTrainCommands = new List<ITrainCommand>();
    }

    public abstract void Train();
    protected abstract void UpdateEnergyCost();
    public abstract void UpgradeCamp();
    public abstract void UpgradeWeapon();

    public virtual void Update()
    {
        UpdateCommand();
    }

    private void UpdateCommand()
    {
        if (mTrainCommands.Count == 0)
            return;

        mTrainTimer -= Time.deltaTime;
        if (mTrainTimer < 0)
        {
            mTrainCommands[0].Execute();
            mTrainCommands.RemoveAt(0);
            mTrainTimer = mTrainTime;
        }
    }

    public void CancelTrainCommand()
    {
        if (mTrainCommands.Count > 0)
        {
            mTrainCommands.RemoveAt(mTrainCommands.Count - 1);
            if (mTrainCommands.Count == 0)
                mTrainTimer = mTrainTime;
        }
    }
}
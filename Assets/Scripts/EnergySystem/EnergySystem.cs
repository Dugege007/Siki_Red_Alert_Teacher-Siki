using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：中介者模式
 * 能量系统
 * 
 * 创建时间：
 */

public class EnergySystem : IGameSystem
{
    private const float MaxEnergy = 100f;
    private float mCurrentEnergy;
    private float mRecoverSpeed = 5f;

    public override void Init()
    {
        base.Init();
        mCurrentEnergy = MaxEnergy;
    }

    public override void Update()
    {
        base.Update();
        mFacade.UpdateEnergySlider(mCurrentEnergy, MaxEnergy);
        if (mCurrentEnergy >= MaxEnergy)
            return;

        mCurrentEnergy += mRecoverSpeed * Time.deltaTime;
        mCurrentEnergy = Mathf.Clamp(mCurrentEnergy, 0, MaxEnergy);
    }

    public bool TakeEnergy(int value)
    {
        if (mCurrentEnergy >= value)
        {
            mCurrentEnergy -= value;
            return true;
        }
        return false;
    }

    public void RecycleEnergy(int value)
    {
        mCurrentEnergy += value;
        mCurrentEnergy = Mathf.Clamp(mCurrentEnergy, 0, MaxEnergy);
    }
}
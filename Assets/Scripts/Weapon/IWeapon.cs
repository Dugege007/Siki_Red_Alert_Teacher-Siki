using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式
 * 武器基类
 * 
 * 创建时间：
 */

public enum WeaponType
{
    Gun = 0,
    Rifle = 1,
    Rocket = 2,
    MAX
}

public abstract class IWeapon
{
    protected WeaponBaseAttr mBaseAttr;
    protected GameObject mGameObject;
    protected ICharacter mOwner;
    protected ParticleSystem mParticle;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;

    protected float mEffectDisplayTime = 0.2f;

    public int ATK { get { return mBaseAttr.ATK; } }
    public float ATKRange { get { return mBaseAttr.ATKRange; } }
    public ICharacter Owner { set { mOwner = value; } }
    public GameObject GameObj { get { return mGameObject; } }

    public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;

        Transform effect = mGameObject.transform.Find("Effect");
        mParticle = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if (mEffectDisplayTime < 0)
            {
                StopEffect();
            }
        }
    }

    public void Fire(Vector3 targetPos)
    {
        // 显示枪口特效
        PlayMuzzleEffect();

        // 显示子弹轨迹特效
        PlayBullerEffect(targetPos);

        // 特效显示时间
        SetEffectDisplayTime();

        // 播放声音
        PlaySound();
    }

    protected abstract void SetEffectDisplayTime();
    protected virtual void PlayMuzzleEffect()
    {
        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;
    }

    protected abstract void PlayBullerEffect(Vector3 targetPos);

    protected void DoPlayBullerEffect(float width, Vector3 targetPos)
    {
        mLine.enabled = true;
        mLine.startWidth = width;
        mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPos);
    }

    protected abstract void PlaySound();

    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(soundName);
        mAudio.clip = clip;
        mAudio.Play();
    }

    private void StopEffect()
    {
        mLine.enabled = false;
        mLight.enabled = false;
    }
}
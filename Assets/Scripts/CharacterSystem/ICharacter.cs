using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * 创建人：杜
 * 功能说明：桥接模式 中介者模式 模板方法模式 观察者模式
 * 角色基类；每个角色的AI组件想要获取其他组件的功能都通过ICharacter进行中转
 * 
 * 创建时间：
 */

public abstract class ICharacter
{
    protected ICharacterAttr mAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavMeshAgent;
    protected AudioSource mAudioSource;
    protected Animation mAnimation;
    protected IWeapon mWeapon;
    //public WeaponGun mWeaponGun;
    //public WeaponRifle mWeaponRifle;
    //public WeaponRocket mWeaponRocket;
    // 实际上这里三行代码已经违反了设计原则，可以提取出三个武器的接口，使用桥接模式调用接口来实现三个武器的功能即可

    protected bool mIsDead = false;
    protected bool mCanDestroy = false;
    protected float mDesttoyTime = 3;

    public Vector3 Position
    {
        get
        {
            if (mGameObject == null)
                Debug.LogError("mGameObject 为空");
            return mGameObject.transform.position;
        }
    }
    public NavMeshAgent NavMeshAgent { get { return mNavMeshAgent; } }
    public float ATKRange { get { return mWeapon.ATKRange; } }
    public ICharacterAttr Attr { get { return mAttr; } set { mAttr = value; } }
    public bool IsDead { get { return mIsDead; } }
    public bool CanDestroy { get { return mCanDestroy; } }
    public GameObject GameObj
    {
        get { return mGameObject; }
        set
        {
            mGameObject = value;
            mNavMeshAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudioSource = mGameObject.GetComponent<AudioSource>();
            mAnimation = mGameObject.GetComponentInChildren<Animation>();
        }
    }
    public IWeapon Weapon
    {
        get { return mWeapon; }
        set
        {
            mWeapon = value;
            mWeapon.Owner = this;
            GameObject child = UnityTool.FindChild(mGameObject, "weapon-point");
            UnityTool.Attach(child, mWeapon.GameObj);
        }
    }

    public void Update()
    {
        if (mIsDead)
        {
            mDesttoyTime -= Time.deltaTime;
            if (mDesttoyTime < 0)
                mCanDestroy = true;
            return;
        }

        mWeapon.Update();
    }

    public abstract void UpdateFSMAI(List<ICharacter> targets);
    public abstract void RunVisitor(ICharacterVisitor visitor);

    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.Position);
        mGameObject.transform.LookAt(target.Position);
        PlayAnimation("attack");
        target.UnderAttack(mWeapon.ATK + mAttr.CritValue);
    }

    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);
    }

    public virtual void Dead()
    {
        mIsDead = true;
        mNavMeshAgent.isStopped = true;

    }

    public void Release()
    {
        GameObject.Destroy(mGameObject);
    }

    public void PlayAnimation(string animName)
    {
        mAnimation.CrossFade(animName);
    }

    public void MoveTo(Vector3 targetPos)
    {
        mNavMeshAgent.SetDestination(targetPos);
        PlayAnimation("move");
    }

    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(soundName);
        mAudioSource.clip = clip;
        mAudioSource.Play();
    }

    protected void DoPlayEffect(string effectName)
    {
        // 第一步加载特效
        GameObject effectGO = FactoryManager.AssetFactory.LoadEffect(effectName);
        effectGO.transform.position = Position;
        // 控制销毁
        effectGO.AddComponent<DestoryForTime>();
    }
}
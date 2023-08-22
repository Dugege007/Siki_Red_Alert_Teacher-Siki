using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式
 * 武器 火箭
 * 
 * 创建时间：
 */

public class WeaponRocket : IWeapon
{
    public WeaponRocket(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
    {
    }

    protected override void PlayBullerEffect(Vector3 targetPos)
    {
        DoPlayBullerEffect(0.1f, targetPos);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RocketShot");
    }

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.4f;
    }
}
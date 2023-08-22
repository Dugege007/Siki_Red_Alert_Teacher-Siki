using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式
 * 武器 步枪
 * 
 * 创建时间：
 */

public class WeaponRifle : IWeapon
{
    public WeaponRifle(WeaponBaseAttr baseAttr, GameObject gameObject) : base(baseAttr, gameObject)
    {
    }

    protected override void PlayBullerEffect(Vector3 targetPos)
    {
        DoPlayBullerEffect(0.1f, targetPos);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.3f;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工厂模式
 * 武器工厂接口
 * 
 * 创建时间：
 */

public interface IWeaponFactory
{
    IWeapon CreateWeapon(WeaponType weaponType);
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工厂模式 享元模式
 * 角色属性工厂
 * 
 * 创建时间：
 */

public interface IAttrFactory
{
    CharacterBaseAttr GetCharacterBaseAttr(Type t);
    WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType);
}
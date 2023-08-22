using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工厂方法模式
 * 生产角色的接口
 * 
 * 创建时间：
 */

public interface ICharacterFactory
{
    ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new();
}
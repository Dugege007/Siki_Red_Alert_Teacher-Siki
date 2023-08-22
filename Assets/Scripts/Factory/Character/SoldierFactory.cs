using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工厂方法模式
 * 提供生产士兵的方法
 * 
 * 创建时间：
 */

public class SoldierFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();
        ICharacterBuilder builder = new SoldierBuilder(character, typeof(T), weaponType, spawnPosition, lv);

        return CharacterBuilderDirector.Construct(builder);
    }
}
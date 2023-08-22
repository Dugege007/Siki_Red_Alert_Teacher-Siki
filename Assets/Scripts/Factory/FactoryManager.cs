using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工厂模式
 * 工厂管理器
 * 
 * 创建时间：
 */

public static class FactoryManager
{
    private static IAssetsFactory mAssetFactory = null;
    private static ICharacterFactory mSoldierFactory = null;
    private static ICharacterFactory mEnemyFactory = null;
    private static IWeaponFactory mWeaponFactory = null;
    private static IAttrFactory mAttrFactory = null;

    public static IAssetsFactory AssetFactory
    {
        get
        {
            if (mAssetFactory == null)
                mAssetFactory = new ResourcesAssetFactory();
            return mAssetFactory;
        }
    }

    public static ICharacterFactory SoldierFactory
    {
        get
        {
            if (mSoldierFactory == null)
                mSoldierFactory = new SoldierFactory();
            return mSoldierFactory;
        }
    }

    public static ICharacterFactory EnemyFactory
    {
        get
        {
            if (mEnemyFactory == null)
                mEnemyFactory = new EnemyFactory();
            return mEnemyFactory;
        }
    }

    public static IWeaponFactory WeaponFactory
    {
        get
        {
            if (mWeaponFactory == null)
                mWeaponFactory = new WeaponFactory();
            return mWeaponFactory;
        }
    }

    public static IAttrFactory AttrFactory
    {
        get
        {
            if (mAttrFactory == null)
                mAttrFactory = new AttrFactory();
            return mAttrFactory;
        }
    }
}
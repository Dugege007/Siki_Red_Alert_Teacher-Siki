using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 武器基本属性
 * 
 * 创建时间：
 */

public class WeaponBaseAttr
{
    protected string mName;
    protected int mATK;
    protected float mATKRange;
    protected string mAssetName;

    public WeaponBaseAttr(string name, int atk, float atkRange, string assetName)
    {
        mName = name;
        mATK = atk;
        mATKRange = atkRange;
        mAssetName = assetName;
    }

    public string Name { get { return mName; } }
    public int ATK { get { return mATK; } }
    public float ATKRange { get { return mATKRange; } }
    public string AssetName { get {  return mAssetName; } }
}
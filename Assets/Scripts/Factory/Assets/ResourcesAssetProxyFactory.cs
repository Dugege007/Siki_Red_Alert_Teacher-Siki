using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：代理模式
 * 新增资源工厂
 * 需要使用代理模式测试性能的话，可以直接将 FactoryManager 中 AssetFactory 属性的 ResourcesAssetFactory 修改为 ResourcesAssetProxyFactory
 * 
 * 创建时间：
 */

public class ResourcesAssetProxyFactory : IAssetsFactory
{
    // 被代理工厂
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory();
    // 缓存
    private Dictionary<string, GameObject> mSoldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEnemys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mWeapons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEffects = new Dictionary<string, GameObject>();
    private Dictionary<string, Sprite> mSprites = new Dictionary<string, Sprite>();
    private Dictionary<string, AudioClip> mAudioClips = new Dictionary<string, AudioClip>();

    public AudioClip LoadAudioClip(string name)
    {
        if (mAudioClips.ContainsKey(name))
            return mAudioClips[name];
        else
        {
            AudioClip audio = mAssetFactory.LoadAudioClip(name);
            mAudioClips.Add(name, audio);
            return audio;
        }
    }

    public GameObject LoadEffect(string name)
    {
        return LoadGameObjectAsset(mEffects, ResourcesAssetFactory.EffectPath, name);
    }

    public GameObject LoadEnemy(string name)
    {
        return LoadGameObjectAsset(mEnemys, ResourcesAssetFactory.EnemyPath, name);
    }

    public GameObject LoadSoldier(string name)
    {
        return LoadGameObjectAsset(mSoldiers, ResourcesAssetFactory.SoldierPath, name);

        //if (mSoldiers.ContainsKey(name))
        //    return Object.Instantiate(mSoldiers[name]);
        //else
        //{
        //    GameObject asset = mAssetFactory.LoadAssets(ResourcesAssetFactory.SoldierPath + name) as GameObject;
        //    mSoldiers.Add(name, asset);
        //    return Object.Instantiate(asset);
        //}
    }

    public Sprite LoadSprite(string name)
    {
        if (mSprites.ContainsKey(name))
            return mSprites[name];
        else
        {
            Sprite icon = mAssetFactory.LoadSprite(name);
            mSprites.Add(name, icon);
            return icon;
        }
    }

    public GameObject LoadWeapon(string name)
    {
        return LoadGameObjectAsset(mWeapons, ResourcesAssetFactory.WeaponPath, name);
    }

    private GameObject LoadGameObjectAsset(Dictionary<string, GameObject> dict, string path, string name)
    {
        if (dict.ContainsKey(name))
            return Object.Instantiate(dict[name]);
        else
        {
            GameObject asset = mAssetFactory.LoadAssets(path + name) as GameObject;
            dict.Add(name, asset);
            return Object.Instantiate(asset);
        }
    }
}
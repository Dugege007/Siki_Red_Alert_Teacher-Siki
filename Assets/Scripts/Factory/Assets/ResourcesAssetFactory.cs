using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工厂模式 代理模式
 * 资源工厂
 * 
 * 创建时间：
 */

public class ResourcesAssetFactory : IAssetsFactory
{
    public const string SoldierPath = "Characters/Soldier/";
    public const string EnemyPath = "Characters/Enemy/";
    public const string WeaponPath = "Weapons/";
    public const string EffectPath = "Effects/";
    public const string AudioPath = "Audios/";
    public const string SpritePath = "Sprites/";

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load<AudioClip>(AudioPath + name);
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }

    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoldierPath + name);
    }

    public Sprite LoadSprite(string name)
    {
        return Resources.Load<Sprite>(SpritePath + name);
    }

    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }

    public GameObject InstantiateGameObject(string path)
    {
        GameObject obj = Resources.Load<GameObject>(path);

        if (obj == null)
        {
            Debug.LogError("无法加载资源路径：" + path);
            return null;
        }

        return Object.Instantiate(obj);
    }

    public Object LoadAssets(string path)
    {
        Object obj = Resources.Load<Object>(path);

        if (obj == null)
        {
            Debug.LogError("无法加载资源路径：" + path);
            return null;
        }

        return obj;
    }
}
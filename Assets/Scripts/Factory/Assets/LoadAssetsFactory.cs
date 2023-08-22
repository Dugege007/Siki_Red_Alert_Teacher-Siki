using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：抽象工厂模式
 * 加载资源
 * 
 * 创建时间：
 */

public class LoadAssetsFactory : IAssetsFactory
{
    private const string SoldierPath = "Characters/Soldier/";
    private const string EnemyPath = "Characters/Enemy/";
    private const string WeaponPath = "Weapons/";
    private const string EffectPath = "Effects/";
    private const string AudioPath = "Audios/";
    private const string SpritePath = "Sprites/";

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

    private GameObject InstantiateGameObject(string path)
    {
        Object obj = Resources.Load<GameObject>(path);
        if (obj == null)
        {
            Debug.LogError("无法加载资源路径：" + path);
            return null;
        }
        return Object.Instantiate(obj) as GameObject;
    }

    private Object LoadAssets(string path)
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
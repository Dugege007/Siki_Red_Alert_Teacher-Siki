using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：工厂模式
 * 资源工厂接口
 * 
 * 创建时间：
 */

public interface IAssetsFactory
{
    GameObject LoadSoldier(string name);
    GameObject LoadEnemy(string name);
    GameObject LoadWeapon(string name);
    GameObject LoadEffect(string name);
    AudioClip LoadAudioClip(string name);
    Sprite LoadSprite(string name);
}
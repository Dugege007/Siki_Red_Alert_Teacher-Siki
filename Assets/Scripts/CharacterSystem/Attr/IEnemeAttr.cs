using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式
 * 敌人属性
 * 
 * 创建时间：
 */

public class IEnemyAttr : ICharacterAttr
{
    public IEnemyAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr) : base(strategy, lv, baseAttr) { }
}
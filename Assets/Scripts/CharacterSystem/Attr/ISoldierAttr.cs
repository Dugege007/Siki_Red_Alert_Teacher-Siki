using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：桥接模式
 * 士兵属性
 * 
 * 创建时间：
 */

public class ISoldierAttr : ICharacterAttr
{
    public ISoldierAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr) : base(strategy, lv, baseAttr) { }
}
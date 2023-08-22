using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：访问者模式
 * 角色功能访问者
 * 
 * 创建时间：
 */

public abstract class ICharacterVisitor
{
    public abstract void VisitEnemy(IEnemy enemy);
    public abstract void VisitSoldier(ISoldier soldier);
}
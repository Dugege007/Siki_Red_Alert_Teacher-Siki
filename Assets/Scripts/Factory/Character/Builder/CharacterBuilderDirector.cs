using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：建造者模式
 * 角色创建的指导类
 * 
 * 创建时间：
 */

public class CharacterBuilderDirector
{
    public static ICharacter Construct(ICharacterBuilder builder)
    {
        builder.AddCharacterAttr();
        builder.AddGameObject();
        builder.AddWeapon();
        builder.AddInCharacterSystem();
        return builder.GetResult();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：中介者模式
 * 角色系统
 * 
 * 创建时间：
 */

public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mEnemys = new List<ICharacter>();
    private List<ICharacter> mSoldiers = new List<ICharacter>();

    public void AddEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }

    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }

    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }

    public override void Update()
    {
        UpdateEnemy();
        UpdateSoldier();

        RemoveCharacterIfIsDead(mEnemys);
        RemoveCharacterIfIsDead(mSoldiers);
    }

    private void UpdateEnemy()
    {
        foreach (var e in mEnemys)
        {
            e.Update();
            e.UpdateFSMAI(mSoldiers);
        }
    }

    private void UpdateSoldier()
    {
        foreach (var e in mSoldiers)
        {
            e.Update();
            e.UpdateFSMAI(mEnemys);
        }
    }

    private void RemoveCharacterIfIsDead(List<ICharacter> characters)
    {
        List<ICharacter> canRemove = new List<ICharacter>();

        foreach (var character in characters)
        {
            if (character.CanDestroy)
            {
                canRemove.Add(character);
            }
        }

        foreach (var character in canRemove)
        {
            character.Release();
            characters.Remove(character);
        }
    }

    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach (var e in mEnemys)
        {
            e.RunVisitor(visitor);
        }
        foreach (var s in mSoldiers)
        {
            s.RunVisitor(visitor);
        }
    }
}
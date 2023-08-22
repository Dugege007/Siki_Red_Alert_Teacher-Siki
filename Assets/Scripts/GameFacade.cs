using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：外观模式 单例模式 中介者模式（中介者） 观察者模式 备忘录模式
 * 用在战斗场景中
 * 
 * 创建时间：
 */

public class GameFacade
{
    private static GameFacade mInstance = new GameFacade();
    private bool mIsGameOver = false;
    public static GameFacade Instance { get { return mInstance; } }
    public bool IsGameOver { get { return mIsGameOver; } set { mIsGameOver = value; } }
    private GameFacade() { }

    private AchievementSystem mAchievementSystem;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;

    private CampInfoUI mCampInfoUI;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;

    public void Init()
    {
        mAchievementSystem = new AchievementSystem();
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mAchievementSystem.Init();
        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();

        LoadMemento();
    }

    public void Update()
    {
        mAchievementSystem.Update();
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnergySystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }

    public void Release()
    {
        mAchievementSystem.Release();
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnergySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();

        SaveMemento();
    }

    public Vector3 GetFinalPosition()
    {
        return mStageSystem.GetRandomTargetPosition();
    }

    public void ShowCampInfoUI(ICamp camp)
    {
        mCampInfoUI.ShowCampInfo(camp);
    }

    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSystem.AddSoldier(soldier);
    }

    public void AddEnemy(IEnemy enemy)
    {
        mCharacterSystem.AddEnemy(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        mCharacterSystem.RemoveEnemy(enemy);
    }

    public bool TakeEnergy(int value)
    {
        return mEnergySystem.TakeEnergy(value);
    }

    public void RecycleEnergy(int value)
    {
        mEnergySystem.RecycleEnergy(value);
    }

    public void ShowMsg(string msg)
    {
        mCampInfoUI.ShowMsg(msg);
    }

    public void UpdateEnergySlider(float currentEnergy, float maxEnergy)
    {
        mCampInfoUI.UpdateEnergySlider(currentEnergy, maxEnergy);
    }

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RegisterObserver(eventType, observer);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RemoveObserver(eventType, observer);
    }

    public void NotifySubject(GameEventType eventType)
    {
        mGameEventSystem.NotifySubject(eventType);
    }

    private void LoadMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        mAchievementSystem.SetMemento(memento);
    }

    private void SaveMemento()
    {
        AchievementMemento memento = mAchievementSystem.CreateMemento();
        memento.SaveData();
    }

    public void RunVisitor(ICharacterVisitor visitor)
    {
        mCharacterSystem.RunVisitor(visitor);
    }
}
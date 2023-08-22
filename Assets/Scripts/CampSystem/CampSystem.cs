using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：中介者模式 命令模式 适配器模式
 * 兵营系统
 * 
 * 创建时间：
 */

public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();
    private Dictionary<EnemyType,CaptiveCamp> mCaptiveCamps=new Dictionary<EnemyType, CaptiveCamp>();

    public override void Init()
    {
        base.Init();

        InitCamp(SoldierType.Rockie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);
        InitCamp(EnemyType.Elf);
    }

    public override void Update()
    {
        foreach (SoldierCamp camp in mSoldierCamps.Values)
        {
            camp.Update();
        }

        foreach (CaptiveCamp camp in mCaptiveCamps.Values)
        {
            camp.Update();
        }
    }

    private void InitCamp(SoldierType soldierType)
    {
        GameObject obj = null;
        string objName = "";
        string name = "";
        string icon = "";
        Vector3 musterPos = Vector3.zero;
        float trainTime = 0;

        switch (soldierType)
        {
            case SoldierType.Rockie:
                objName = "SoldierCamp_Rockie";
                name = "新兵营";
                icon = "RookieCamp";
                musterPos = new Vector3(0, 0, 0);
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                objName = "SoldierCamp_Sergeant";
                name = "中士营";
                icon = "SergeantCamp";
                musterPos = new Vector3(0, 0, 0);
                trainTime = 5;
                break;
            case SoldierType.Captain:
                objName = "SoldierCamp_Captain";
                name = "上尉营";
                icon = "CaptainCamp";
                musterPos = new Vector3(0, 0, 0);
                trainTime = 8;
                break;
            default:
                Debug.LogError("无法根据战士类型" + soldierType + "初始化");
                break;
        }

        obj = GameObject.Find(objName);
        musterPos = UnityTool.FindChild(obj, "TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(obj, name, icon, soldierType, musterPos, trainTime);
        obj.AddComponent<CampOnClick>().Camp = camp;

        mSoldierCamps.Add(soldierType, camp);
    }

    private void InitCamp(EnemyType enemyType)
    {
        GameObject obj = null;
        string objName = "";
        string name = "";
        string icon = "";
        Vector3 musterPos = Vector3.zero;
        float trainTime = 0;

        switch (enemyType)
        {
            case EnemyType.Elf:
                objName = "CaptiveCamp_Elf";
                name = "俘兵营";
                icon = "CaptiveCamp";
                musterPos = new Vector3(0, 0, 0);
                trainTime = 3;
                break;
            case EnemyType.Ogre:
                break;
            case EnemyType.Troll:
                break;
            default:
                Debug.LogError("无法根据俘兵类型" + enemyType + "初始化");
                break;
        }

        obj = GameObject.Find(objName);
        musterPos = UnityTool.FindChild(obj, "TrainPoint").transform.position;
        CaptiveCamp camp = new CaptiveCamp(obj, name, icon, enemyType, musterPos, trainTime);
        obj.AddComponent<CampOnClick>().Camp = camp;

        mCaptiveCamps.Add(enemyType, camp);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * UI基类
 * 
 * 创建时间：
 */

public abstract class IBaseUI
{
    protected GameFacade mFacade;

    public GameObject mRootUI;

    public virtual void Init()
    {
        mFacade = GameFacade.Instance;
    }

    public virtual void Update() { }
    public virtual void Release() { }

    protected void Show()
    {
        mRootUI.SetActive(true);
    }

    protected void Hide()
    {
        mRootUI.SetActive(false);
    }
}
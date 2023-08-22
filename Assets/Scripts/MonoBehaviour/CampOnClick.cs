using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：
 * 创建时间：
 */

public class CampOnClick : MonoBehaviour
{
    private ICamp mCamp;
    public ICamp Camp { set { mCamp = value; } }

    private void OnMouseUpAsButton()
    {
        GameFacade.Instance.ShowCampInfoUI(mCamp);
    }
}
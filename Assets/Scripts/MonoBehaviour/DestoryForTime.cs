using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 创建人：杜
 * 功能说明：自动销毁物体
 * 创建时间：
 */

public class DestoryForTime : MonoBehaviour
{
    public float time = 1f;

    private void Start()
    {
        Invoke("DestroySelf", time);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
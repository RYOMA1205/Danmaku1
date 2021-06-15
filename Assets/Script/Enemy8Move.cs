using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8Move : MonoBehaviour
{
    // 4章の4で作成
    private float angle;

    void Update()
    {
        angle += Time.deltaTime * 2;

        transform.position = new Vector3(
            // X軸
            Mathf.Sin(angle) * 12,

            // Y軸
            transform.position.y,

            // Z軸
            Mathf.Sin(angle * 2) * 2);
    }
}

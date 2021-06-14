using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX2Move : MonoBehaviour
{
    // 4章の1で作成
    [Range(0, 50)]

    public float moveDistance;

    private Vector3 pos;

    private bool isReturn = false;

    void Update()
    {
        pos = transform.position;

        if (pos.z < 0 && isReturn == false)
        {
            transform.Translate(-moveDistance * Time.deltaTime, 0, moveDistance * Time.deltaTime, Space.World);
        }
        else
        {
            isReturn = true;

            transform.Translate(-moveDistance * Time.deltaTime, 0, -moveDistance * Time.deltaTime, Space.World);
        }
    }
}

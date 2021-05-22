using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.2f;

    // 3個目で追加
    private Vector3 pos;

    void Update()
    {
        float moveH = Input.GetAxis("Horizontal") * moveSpeed;

        float moveV = Input.GetAxis("Vertical") * moveSpeed;

        transform.Translate(moveH, 0, moveV);

        // 3個目で追加
        MoveClamp();
    }

    // 3個目で追加
    void MoveClamp()
    {
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -10, 10);

        pos.z = Mathf.Clamp(pos.z, -10, 10);

        transform.position = pos;
    }
}

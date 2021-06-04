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
        // 9で改良(下記の2行をコメントアウトする)
        //float moveH = Input.GetAxis("Horizontal") * moveSpeed;

        //float moveV = Input.GetAxis("Vertical") * moveSpeed;

        // 9で改良(下記の2行を追加する)
        float moveH = -Input.GetAxis("Mouse X") * moveSpeed;

        float moveV = -Input.GetAxis("Mouse Y") * moveSpeed;

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

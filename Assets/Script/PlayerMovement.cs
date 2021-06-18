using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.2f;

    // 3個目で追加
    private Vector3 pos;

    // 4章の9で修正
    void Update()
    {
        // PCでも動きを確認できる様にします(テクニック)
        if (Application.isEditor)
        {
            // 9で改良(下記の2行をコメントアウトする)
            // 4章の9でコメントアウト解除
            float moveH = Input.GetAxis("Horizontal") * moveSpeed;

            float moveV = Input.GetAxis("Vertical") * moveSpeed;

            // 9で改良(下記の2行を追加する)
            // 4章の9でコメントアウト
            // float moveH = -Input.GetAxis("Mouse X") * moveSpeed;
            // float moveV = -Input.GetAxis("Mouse Y") * moveSpeed;

            transform.Translate(moveH, 0, moveV);

            // 3個目で追加
            MoveClamp();
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                float MoveH = -touch.deltaPosition.x * Time.deltaTime * moveSpeed;

                float MoveV = -touch.deltaPosition.y * Time.deltaTime * moveSpeed;

                transform.Translate(MoveH, 0, MoveV);

                MoveClamp();
            }
        }
    }

    // 3個目で追加
    void MoveClamp()
    {
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -20, 20);

        pos.z = Mathf.Clamp(pos.z, -10, 10);

        transform.position = pos;
    }
}

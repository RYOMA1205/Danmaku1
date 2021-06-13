using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyXMove : MonoBehaviour
{
    // 4章の1で作成
    [Range(0, 50)]

    public float moveDistance;

    private Vector3 pos;

    private bool isReturn = false;

    void Update()
    {
        pos = transform.position;

        if (pos.z > 0 && isReturn == false)
        {
            // Translate(x軸, y軸, z軸)
            // x軸がプラス　→方向のベクトル
            // z軸がマイナス　↓方向のベクトル
            // この2つのベクトルを合成すると「↘︎」方向のベクトルになる(→　+　↓　= ↘︎)
            transform.Translate(moveDistance * Time.deltaTime, 0, -moveDistance * Time.deltaTime, Space.World);
            Debug.Log("右下移動");
        }
        // pos.zが1以下になった時、進行方向を変化させる
        else
        {
            // x軸がプラス　→方向のベクトル
            // z軸がマイナス　↑方向のベクトル
            // この2つのベクトルを合成すると「↗︎」方向のベクトルになる(→　+　↑　=　↗︎)
            transform.Translate(moveDistance * Time.deltaTime, 0, moveDistance * Time.deltaTime, Space.World);
            Debug.Log("右上移動");
        }
    }
}

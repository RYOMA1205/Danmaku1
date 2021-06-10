using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // 2で作成
    // Rangeは範囲を決める属性
    [Range(0, 10)]

    public float moveDistance;

    void Update()
    {
        // (ポイント)
        // 「Space.World」を設定すると「ワールド座標」が基準になる　
        // 書かない場合にはオブジェクトの座標が基準になる　
        // オブジェクトを基準にした場合、それが回転すると真っ直ぐに移動しなくなるので注意
        transform.Translate(0, 0, -moveDistance * Time.deltaTime, Space.World);
    }
}

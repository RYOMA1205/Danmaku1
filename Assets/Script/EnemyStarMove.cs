using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarMove : MonoBehaviour
{
    // 軌跡を画面に表示したい場合にはオブジェクトに
    // 「Trail Renderer」コンポーネントを付ける
    // 5で作成
    public float speed;

    public float plusAngle;

    public float intervalTime;

    private Rigidbody rb;

    private float timeCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        // もしもタイムカウントが指定した時間を経過したら‥
        if (timeCount > intervalTime)
        {
            // (1)いったん速度を0にする(ポイント)
            rb.velocity = Vector3.zero;

            // (2)指定した角度だけ方向を転換する
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + plusAngle, 0);

            // (3)方向転換が完了したら再び加速させる
            rb.AddForce(transform.forward * speed);

            // (4)タイムカウントを0に戻す(リセットする)
            timeCount = 0;
        }
    }
}

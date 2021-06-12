using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissile : MonoBehaviour
{
    // 11で追加
    public GameObject enemyMissilePrefab;

    public float missileSpeed;

    private int timeCount = 0;

    // 9で追加
    public float stopTimer = 10;

    void Update()
    {
        timeCount += 1;

        // 9で追加
        // タイマーを進める
        stopTimer -= Time.deltaTime;

        // 9で追加
        // タイマーが0未満になったら「0」で止める
        if (stopTimer < 0)
        {
            stopTimer = 0;
        }

        // 9で追加
        print("攻撃開始まであと" + stopTimer + "秒");

        // 「％」と｢==」の意味を復習しましょう!(ポイント)
        // 9で追加
        // タイマーが0以下になったら敵が攻撃を開始する
        if (timeCount % 80 == 0　&& stopTimer <= 0)
        {
            // 敵のミサイルを生成する
            GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

            Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody>();

            // ミサイルを飛ばす方向を決める。
            //『forward』は「z軸」方向をさす(ポイント)
            enemyMissileRb.AddForce(transform.forward * missileSpeed);

            // 3秒後に敵のミサイルを削除する
            Destroy(enemyMissile, 3.0f);
        }
    }

    // 9で追加
    // タイマーの時間を増加させるメソッド
    public void AddStopTimer(float amount)
    {
        stopTimer += amount;
    }
}

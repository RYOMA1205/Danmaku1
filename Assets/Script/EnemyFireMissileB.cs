using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissileB : MonoBehaviour
{
    // 5で作成
    public GameObject enemyMissilePrefab;

    public float speed;

    private int timeCount;

    void Update()
    {
        timeCount += 1;

        // 発射間隔を短くする
        // 「％」と「==」の意味を復習しましょう(ポイント)
        if (timeCount % 5 == 0)
        {
            GameObject missile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);
            Rigidbody missileRb = missile.GetComponent<Rigidbody>();
            missileRb.AddForce(transform.forward * speed);

            // 10秒後に敵のミサイルを削除する
            Destroy(missile, 10f);
        }

        // 6で追加
        // timeCountが500になった時、このオブジェクトにRotateスクリプトを付加する
        // 同時にRotation Yに90を設定する
        if (timeCount == 500)
        {
            this.gameObject.AddComponent<Rotate>().pos = new Vector3(0, 90, 0);
        }
    }
}

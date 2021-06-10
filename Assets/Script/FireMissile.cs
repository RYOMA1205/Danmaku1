using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour
{
    // 変数の定義(データを入れるための箱を作成する)
    public GameObject missilePrefab;

    public float missileSpeed;

    public AudioClip fireSound;

    // 1で追加(長押し連射)
    private int timeCount;

    // 4で追加(弾切れ発生)
    private int maxPower = 100;

    private int shotPower;

    // ４で追加(弾切れ発生)
    private void Start()
    {
        shotPower = maxPower;
    }

    void Update()
    {
        // 1で追加(長押し連射)
        timeCount += 1;

            // 1で追加(長押し連射)
            // 「5」の部分の数字を変えると「連射の感覚」を変更することができます(ポイント)
            // 「％」と「==」の意味合いを復習する
            //「GetButtonDown」を「GetBuutton」に変更する(ポイント)
            // 「GetBuuton」は「押している間」という意味
            if (Input.GetButton("Jump"))
            {
                // 4で追加(弾切れ発生)
                // ここのロジックをよく復習すること(重要ポイント)
                if (shotPower <= 0)
                {
                    return;
                }

                // 4で追加(弾切れ発生)
                shotPower -= 1;

                if (Input.GetButton("Jump"))
                {
                    // プレハブからミサイルオブジェクトを作成し、それをmissileという名前の箱に入れる
                    GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

                    Rigidbody missileRb = missile.GetComponent<Rigidbody>();

                    missileRb.AddForce(transform.forward * missileSpeed);

                    AudioSource.PlayClipAtPoint(fireSound, transform.position);

                    // 発射したミサイルを2秒後に破壊(削除する)
                    Destroy(missile, 2.0f);
                }
            }
    }
}

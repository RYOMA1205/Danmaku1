using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour
{
    // 変数の定義(データを入れるための箱を作成する)
    public GameObject missilePrefab;

    public float missileSpeed;

    public AudioClip fireSound;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
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

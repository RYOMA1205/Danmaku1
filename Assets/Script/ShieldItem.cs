using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    // 14で作成
    public GameObject effectPrefab;

    public AudioClip getSound;

    public GameObject shieldPrefab;

    private GameObject player;

    private Vector3 pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            // エフェクトと効果音を発生させる
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            Destroy(effect, 0.5f);

            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            // プレイヤーの位置情報を取得する
            player = GameObject.FindWithTag("Player");

            pos = player.transform.position;

            // プレイヤーの側面の位置に2枚の防御シールドを発生させる
            GameObject shieldA = Instantiate(shieldPrefab, new Vector3(pos.x - 0.5f, pos.y, pos.z), Quaternion.identity);

            GameObject shieldB = Instantiate(shieldPrefab, new Vector3(pos.x + 0.5f, pos.y, pos.z), Quaternion.identity);

            // 発生させた防御シールドをプレイヤーの子供に設定する(親子関係)
            // 親子関係にすることで一緒に動くようになる
            shieldA.transform.SetParent(player.transform);

            shieldB.transform.SetParent(player.transform);

            // 発生させた防御シールドを5秒後に消滅させる
            Destroy(shieldA, 5);

            Destroy(shieldB, 5);

            // アイテムを破壊する
            Destroy(gameObject);
        }
    }

}

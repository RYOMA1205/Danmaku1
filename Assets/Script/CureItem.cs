using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureItem : MonoBehaviour
{
    // 11で作成
    public GameObject effectPrefab;

    public AudioClip getSound;

    public PlayerHealth playerHealth;

    private int reward = 3;

    void Start()
    {
        // 「Player」についている「PlayerHealth」スクリプトにアクセスする
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーのミサイルで破壊するとHPが回復する
        if (other.gameObject.CompareTag("Missile"))
        {
            // エフェクトを発生させる
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            Destroy(effect, 0.5f);

            // 効果音を出す
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            // アイテムを画面から消す(破壊する)
            Destroy(this.gameObject);

            // プレイヤーのHPを自分が指定した量だけ回復させる
            playerHealth.AddHP(reward);
        }
    }

}

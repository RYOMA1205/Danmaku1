using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1UpItem : MonoBehaviour
{
    // 12で作成
    public GameObject effectPrefab;

    public AudioClip getSound;

    private PlayerHealth playerHealth;

    private int reward = 1;

    void Start()
    {
        // 「Player」についている「PlayerHealth」スクリプトにアクセスする
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // エフェクトを発生させる
        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

        Destroy(effect, 0.5f);

        // 効果音を出す
        AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

        // アイテムを画面から消す(破壊する)
        Destroy(this.gameObject);

        // プレイヤーの残機を１つ回復させる
        playerHealth.Player1Up(reward);
    }
}

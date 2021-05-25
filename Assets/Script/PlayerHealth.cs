using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // 手順12で追加
    public GameObject effectPrefab;

    public AudioClip damageSound;

    public AudioClip destroySound;

    public int playerHP;

    // 13で追加
    private Slider playerHPSlider;

    // 14で追加
    // 配列の定義(「複数のデータ」を入れることのできる「仕切り」付きの箱を作る)
    public GameObject[] playerIcons;

    // 14で追加
    // プレイヤーが破壊された回数のデータを入れる箱
    public int destroyCount = 0;

    // 13で追加
    private void Start()
    {
        playerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();

        playerHPSlider.maxValue = playerHP;

        playerHPSlider.value = playerHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyMissile"))
        {
            playerHP -= 1;

            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);

            // 13で追加
            playerHPSlider.value = playerHP;

            Destroy(other.gameObject);

            if (playerHP == 0)
            {
                // 14で追加
                // HPが0になったら破壊された回数を１つ増加させる
                destroyCount += 1;

                // 14で追加
                // 命令ブロック(メソッド)を呼び出す
                UpdatePlayerIcons();

                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                Destroy(effect, 1.0f);

                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);

                // プレイヤーを破壊するのではなく、非アクティブ状態にする(ポイント)
                this.gameObject.SetActive(false);

                // 16で追加
                // 破壊された回数によって場合分けを行います
                if (destroyCount < 5)
                {
                    // 15で追加
                    // リトライの命令ブロックを1秒後に呼び出す
                    Invoke("Retry", 1.0f);
                }
                else
                {
                    // ゲームオーバーシーンに遷移する
                    // (ポイント)GameOverはシーンの名前と一言一句全て同じにする
                    SceneManager.LoadScene("GameOVer");
                }
                
            }
        }
    }

    // 14で追加
    // プレイヤーの残機数を表示する命令ブロック(メソッド)
    void UpdatePlayerIcons()
    {
        // for文(繰り返し文)‥まずは基本形を覚える
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (destroyCount <= i)
            {
                playerIcons[i].SetActive(true);
            }
            else
            {
                playerIcons[i].SetActive(false);
            }
        }
    }

    // 15で追加
    // ゲームリトライに関する命令ブロック
    void Retry()
    {
        this.gameObject.SetActive(true);

        // ここの数値は自身で設定しているプレイヤーのHP数にすること
        playerHP = 5;

        playerHPSlider.value = playerHP;
    }
}

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
    // 23で変更
    public static int destroyCount = 0;

    // 8で追加(無敵)
    public bool isMuteki = false;

    // 24で追加
    private ScoreManager scoreManager;

    // 13で追加
    private void Start()
    {
        // 24で追加(ScoreLabelオブジェクトに付いているScoreManagerスクリプトにアクセスする)
        scoreManager = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();

        // 23で追加
        UpdatePlayerIcons();

        playerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();

        playerHPSlider.maxValue = playerHP;

        playerHPSlider.value = playerHP;
    }

    // (条件分を3で追加)
    // 『|| other.gameObject.CompareTag("Enemy") && isMuteki == false』を条件に追加する
    // ||は「または」の意味(条件Aまたは条件Bのどちらかが成立したとき)
    private void OnTriggerEnter(Collider other)
    {
        // 8で追加(無敵)
        // 条件文の中に「&&　isMuteki == false」を追加
        if (other.gameObject.CompareTag("EnemyMissile") && isMuteki == false || other.gameObject.CompareTag("Enemy") && isMuteki == false)
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
                    // 24で追加(ゲームオーバーになったら残機数をリセットする)
                    destroyCount = 0;

                    // 24で追加(ゲームオーバーになったらスコアをリセットする)
                    scoreManager.ScoreReset();

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

        // 8で追加(無敵)
        isMuteki = true;
        Invoke("MutekiOff", 2.0f);
    }

    // 8で追加(無敵)
    void MutekiOff()
    {
        isMuteki = false;
    }

    // 11で追加(HP回復アイテム)
    // 「public」を付けること(ポイント)
    public void AddHP(int amount)
    {
        // 「amount」分だけHPを回復させる
        playerHP += amount;

        // 最大HP以上には回復しないようにする
        if (playerHP > 5)
        {
            playerHP = 5;
        }

        // HPスライダー
        playerHPSlider.value = playerHP;
    }

    // 12で追加(自機1UPアイテム)
    // 「public」を付けること(ポイント)
    public void Player1Up(int amount)
    {
        // amount分だけ自機の残機を回復させる
        // (考え方)破壊された回数(「destroyCount」)をamount分だけ減少させる
        destroyCount -= amount;

        // 最大残機数を超えないようにする(破壊された回数が0未満にならないようにする)
        if (destroyCount < 0)
        {
            destroyCount = 0;
        }

        // 残機数を表示するアイコンを復活させる
        UpdatePlayerIcons();
    }
}

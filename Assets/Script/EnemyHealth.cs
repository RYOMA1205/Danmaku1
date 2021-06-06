using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    // 9でスクリプト作成
    public GameObject effectPrefab;

    public AudioClip destroySound;

    public int enemyHP;

    // 10で追加
    // 7でpublic修飾子に変更
    public Slider slider;

    // 19で追加(スコア)
    public int scoreValue;

    private ScoreManager sm;

    // 15で追加(アイテム出現)
    // 「配列」(ポイント)
    // 16で改良(ランダム出現)
    public GameObject[] itemPrefab;

    // 21で追加(ステージクリア)
    public int nextSceneNumber;

    public AudioClip clearSound;

    // 10で追加
    private void Start()
    {
        // (ポイント)GameObject.Find("○○")の使い方を覚えよう。名前でオブジェクトを指定できる
        //slider = GameObject.Find("EnemyHPSlider").GetComponent<Slider>();

        // スライダーの最大値の設定
        slider.maxValue = enemyHP;

        // スライダーの現在地の設定
        slider.value = enemyHP;

        // 19で追加(スコア)
        // 「ScoreLabel」オブジェクトについている
        // 「ScoreManager」スクリプトにアクセスして取得する(ポイント)
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかった相手に「Missile」というタグ(Tag)がついてたら
        if (other.gameObject.CompareTag("Missile"))
        {
            // エフェクトを発生させる
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            // 0.5秒後にエフェクトを消す
            Destroy(effect, 0.5f);

            // 敵のHPを1つずつ減少させる
            enemyHP -= 1;

            // 10で追加
            // この一行を追加しないとスライダーバーの目盛りが変化しない
            slider.value = enemyHP;

            // ミサイルを削除する
            Destroy(other.gameObject);

            // 敵のHPが0になったら敵オブジェクトを破壊する
            if (enemyHP == 0)
            {
                // 21で変更(ステージクリア)
                // ↓下記の1行を「//」で「コメントアウト」にする(重要ポイント)
                // 親オブジェクトを破壊する(ポイント;この使い方を覚えよう!)
                // Destroy(transform.root.gameObject);

                // 21で追加(ステージクリア)
                // 親オブジェクトを非表示にする
                transform.root.gameObject.SetActive(false);

                // 破壊の効果音を出す
                AudioSource.PlayClipAtPoint(destroySound, transform.position);

                // 19で追加(スコア)
                // 敵を破壊した瞬間にスコアを加算するメソッドを呼び出す
                // 引数には「scoreValue」を入れる
                sm.AddScore(scoreValue);

                // 16で追加(ランダム出現)
                // ランダムメソッドの活用(ポイント)
                GameObject dropItem = itemPrefab[Random.Range(0, itemPrefab.Length)];

                // 15で追加(アイテム出現)
                // 敵を破壊した瞬間=敵のHPが0になった瞬間にアイテムプレハブを実体化させる
                // 16で改良(ランダム出現)
                // ランダムに選んだアイテムを実体化する
                Instantiate(dropItem, transform.position, Quaternion.identity);

                // 21で追加(ステージクリア)
                // (条件)親オブジェクトに「Boss」というTagがついていたならば(ポイント)
                if (this.gameObject.transform.root.CompareTag("Boss"))
                {
                    // クリア音を鳴らす
                    AudioSource.PlayClipAtPoint(clearSound, Camera.main.transform.position);

                    // 1秒後にシーン遷移のメソッドを実行する
                    Invoke("GoNextStage", 1);
                }
            }
        }
    }

    // 21で追加(ステージクリア)
    // シーン遷移のメソッド
    void GoNextStage()
    {
        SceneManager.LoadScene(nextSceneNumber);
    }
}

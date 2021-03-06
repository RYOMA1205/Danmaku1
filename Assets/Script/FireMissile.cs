using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // 5で追加(パワー量の表示)
    private Slider powerSlider;

    // 6で追加(発射パワーの回復)
    // 発射パワーが回復するまでに要する時間(定数)
    // constは読み取り専用のため一度決めたら上書きできない
    const int RecoveryTime = 10;

    // 発射パワー回復までの残り時間
    private int counter;

    // 8で追加(発射パワーの表示)
    private Slider waitTimeSlider;

    // ４で追加(弾切れ発生)
    private void Start()
    {
        shotPower = maxPower;

        // 5で追加(パワー量の表示)
        powerSlider = GameObject.Find("PowerSlider").GetComponent<Slider>();

        powerSlider.maxValue = maxPower;

        powerSlider.value = shotPower;

        // 8で追加(発射パワーの表示)
        waitTimeSlider = GameObject.Find("WaitTimeSlider").GetComponent<Slider>();

        waitTimeSlider.maxValue = RecoveryTime;

        waitTimeSlider.value = RecoveryTime;
    }

    // 4章の8で修正
    // どの様な仕組みで「手動発射→自動発射」に変更できるのか確認する
    void Update()
    {
        Shot();
    }

    private void Shot()
    {
        // 6で追加(発射パワーの回復)
        if (shotPower <= 0 && counter <= 0)
        {
            // 条件の内容をおさえる(ポイント)
            // コルーチンを作動させる
            StartCoroutine(RecoverPower());
        }
        // 1で追加(長押し連射)
        timeCount += 1;

        // 1で追加(長押し連射)
        // 「5」の部分の数字を変えると「連射の感覚」を変更することができます(ポイント)
        // 「％」と「==」の意味合いを復習する
        //「GetButtonDown」を「GetBuutton」に変更する(ポイント)
        // 「GetBuuton」は「押している間」という意味
        if (timeCount % 2 == 0)
        {
            // 4で追加(弾切れ発生)
            // ここのロジックをよく復習すること(重要ポイント)
            if (shotPower <= 0)
            {
                return;
            }

            // 4で追加(弾切れ発生)
            shotPower -= 1;

            // 5で追加(パワー量の表示)
            // なぜこの位置にコードを記述するのか、そのロジックの流れをおさえること(ポイント)
            powerSlider.value = shotPower;


            // プレハブからミサイルオブジェクトを作成し、それをmissileという名前の箱に入れる
            GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

            Rigidbody missileRb = missile.GetComponent<Rigidbody>();

            missileRb.AddForce(transform.forward * missileSpeed);

            AudioSource.PlayClipAtPoint(fireSound, transform.position);

            // 発射したミサイルを2秒後に破壊(削除する)
            Destroy(missile, 2.0f);
        }
    }

    // 6で追加(発射パワーの回復)
    // コルーチン
    // voidとかの代わり(戻り値)、IEnumeratorを用いると
    // yieldを利用して一時中断の処理(コルーチン)ができる様になる
    IEnumerator RecoverPower()
    {
        // パワー回復までに必要な時間をセット
        counter = RecoveryTime;

        // 1秒ずつカウントを進める
        while (counter > 0)
        {
            // WaitForSeconds()でカッコ内の秒数待つ
            yield return new WaitForSeconds(1.0f);

            counter -= 1;

            // 8で追加
            waitTimeSlider.value = counter;

            print("全回復までの残り時間" + counter + "秒");
        }

        // (ポイント)
        // while内の処理が行われている間は、ここのコードは実行されない
        // whileの処理が終了 = 残り時間が0になった時にコードが実行される
        // 発射パワーをマックス状態にする
        shotPower = maxPower;

        powerSlider.value = shotPower;

        // 8で追加(発射パワーの表示)
        // 待機時間が終了したら待機ゲージを最初の状態に戻す
        waitTimeSlider.value = RecoveryTime;
    }

    // 7で追加(発射パワーのリセット)
    // プレイヤーが破壊された時、この命令ブロックが呼ばれて実行される様にする(ポイント)
    public void ResetPower()
    {
        shotPower = maxPower;

        powerSlider.value = shotPower;

        counter = 0;

        // 8で追加(発射パワーの表示)
        // プレイヤーが破壊されたら待機ゲージを最初の状態に戻す
        waitTimeSlider.value = RecoveryTime;
    }
}

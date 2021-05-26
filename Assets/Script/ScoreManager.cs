using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 19で作成
    private int score = 0;

    private Text scoreLabel;

    void Start()
    {
        // 「Text」コンポーネントにアクセスして取得する(ポイント)
        scoreLabel = this.gameObject.GetComponent<Text>();

        scoreLabel.text = "Score" + score;
    }

    // スコアを加算する(命令ブロック)
    // 「public」をつけて外部からこのメソッドにアクセスできるようにする(重要ポイント)
    public void AddScore(int amount)
    {
        // 「amount」に入ってくる数値分を加算していく
        score += amount;
        scoreLabel.text = "Score" + score;
    }
    
}

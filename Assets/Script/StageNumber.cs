using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageNumber : MonoBehaviour
{
    // 18で作成
    private Text stageNumberText;

    void Start()
    {
        // 「Text」コンポーネントにアクセスして取得する
        stageNumberText = this.gameObject.GetComponent<Text>();

        // 17で追加
        // 現在のシーンの名前を取得してtextプロパティにセットする(ポイント)
        stageNumberText = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        stageNumberText.color = Color.Lerp(stageNumberText.color, new Color(1, 1, 1, 0), 0.5f * Time.deltaTime);
    }
}

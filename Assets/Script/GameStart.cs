using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // 22で作成
    // 先頭に「public」をつけること(ポイント)
    public void OnGAMESTARTButtonClicked()
    {
        SceneManager.LoadScene("Stage1");
    }
}

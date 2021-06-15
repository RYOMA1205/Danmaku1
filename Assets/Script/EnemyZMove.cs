using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZMove : MonoBehaviour
{
    // 4章の3で作成
    [Range(0, 50)]

    public float moveDistance;

    [Range(0, 2)]

    // ターンまでの時間
    public float turnSpeed;

    public bool isTurn = false;

    private int num;

    private void Start()
    {
        StartCoroutine(SwitchNum());
    }

    void Update()
    {
        // 発想のポイント
        // -(マイナス)を掛けると、方向が逆になる性質を利用する
        // numの箱の中には「1」と「-1」が交互に入るようになっている
        transform.Translate(moveDistance * Time.deltaTime * num, 0, -moveDistance * Time.deltaTime, Space.World);
    }

    IEnumerator SwitchNum()
    {
        while (this.gameObject != null)
        {
            if (isTurn == false)
            {
                num = 1;

                yield return new WaitForSeconds(turnSpeed);

                isTurn = true;
            }
            else
            {
                num = -1;

                yield return new WaitForSeconds(turnSpeed);

                isTurn = false;
            }
        }
    }
}

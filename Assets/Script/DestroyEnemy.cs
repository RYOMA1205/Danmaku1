using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    // (ポイント)
    // ①「Is Trigger」にチェックを入れる
    // ②EnemyCに「Enemy」のタグを付ける
    // 3で作成

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}

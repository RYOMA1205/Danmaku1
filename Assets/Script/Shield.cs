using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // 14で作成
    public AudioClip getSound;

    // ぶつかってくる敵のミサイルを破壊する
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyMissile"))
        {
            Destroy(other.gameObject);

            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);
        }
    }
}

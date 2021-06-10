using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    // 2で作成
    public GameObject effectPrefab;

    public AudioClip destroySound;

    // ここでは敵の破壊の「基本形」を紹介しています
    // ここからさらに「発展形」を考えてみましょう
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Missile"))
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position);

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            Destroy(effect, 0.5f);

            Destroy(gameObject);

            Destroy(other.gameObject);
        }
    }
}

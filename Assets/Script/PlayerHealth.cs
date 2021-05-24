using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // 手順12で追加
    public GameObject effectPrefab;

    public AudioClip damageSound;

    public AudioClip destroySound;

    public int playerHP;

    // 13で追加
    private Slider playerHPSlider;

    // 13で追加
    private void Start()
    {
        playerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();

        playerHPSlider.maxValue = playerHP;

        playerHPSlider.value = playerHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyMissile"))
        {
            playerHP -= 1;

            AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);

            // 13で追加
            playerHPSlider.value = playerHP;

            Destroy(other.gameObject);

            if (playerHP == 0)
            {
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

                Destroy(effect, 1.0f);

                AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);

                // プレイヤーを破壊するのではなく、非アクティブ状態にする(ポイント)
                this.gameObject.SetActive(false);
            }
        }
    }

}

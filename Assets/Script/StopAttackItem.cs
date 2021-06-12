using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttackItem : MonoBehaviour
{
    // 9で作成
    public GameObject[] targets;

    void Update()
    {
        // 「EnemyFireMissile」プレハブに「EnemyFireMissile」のタグを付けてください(ポイント)
        targets = GameObject.FindGameObjectsWithTag("EnemyFireMissile");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Missile")
        {
            Destroy(other.gameObject);

            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].GetComponent<EnemyFireMissile>().AddStopTimer(10.0f);
            }

            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGene2 : MonoBehaviour
{
    // 4章の1で作成
    public GameObject enemyPrefab;

    public int geneAmount;

    [Range(0, 1.5f)]

    public float waitTime;
    
    void Start()
    {
        StartCoroutine(GeneEnemy());
    }

    IEnumerator GeneEnemy()
    {
        for (int i = 0; i < geneAmount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            Destroy(enemy, 15.0f);

            yield return new WaitForSeconds(waitTime);
        }
    }
}

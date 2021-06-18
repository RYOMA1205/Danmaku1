using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Go : MonoBehaviour
{
    // 4章の6で作成
    public float startSpeed_Min = 60;

    public float startSpeed_Max = 300;

    public float nextSpeed;

    private Rigidbody rb;

    private GameObject target;

    private float timeCount = 0;

    // 弾が生成後、何秒後に停止するか
    public float stopTime = 3;

    private float stopTimeCount = 0;

    // 弾が停止後、何秒後に動き出すか
    private float nextStartTime = 2;

    private bool stopKey = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(-transform.forward * Random.Range(startSpeed_Min, startSpeed_Max));

        target = GameObject.Find("Player");
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= stopTime && stopKey == false)
        {
            stopTimeCount += Time.deltaTime;

            // 弾の速度を0にする　=　たまを停止させる
            rb.velocity = Vector3.zero;

            // 弾の色を変える
            GetComponent<MeshRenderer>().material.color = Color.white;

            if (stopTimeCount >= nextStartTime)
            {
                this.gameObject.transform.LookAt(target.transform.position);

                rb.AddForce(transform.forward * nextSpeed);

                stopKey = true;
            }
        }
    }
}

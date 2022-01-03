using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BC : MonoBehaviour

{

    //要被生成的怪物物件
    public GameObject ball_0;
    public GameObject ball_1;
    public GameObject ball_2;
    public GameObject ball_3;
    public GameObject ball_4;
    public GameObject ball_5;
    public GameObject ball_6;
    public GameObject ball_7;

    void Start()

    {

        //執行生成怪物程式碼(每秒一次)

        InvokeRepeating("BallCreater", 1, 1);

    }

    public void BallCreater()

    {

        int BallNum;

        //隨機決定要生成幾個怪物(0-2個隨機)

        BallNum = Random.Range(0, 3);

        //開始生成怪物

        for (int i = 0; i < BallNum; i++)

        {

            //宣告生成的X座標

            float y;

            //產生隨機的X座標(-6到5之間)

            y = Random.Range(-6, 6);

            //生成怪物

            Instantiate(ball_1, new Vector3(2.8f, y, 0), Quaternion.identity);

        }

    }

}
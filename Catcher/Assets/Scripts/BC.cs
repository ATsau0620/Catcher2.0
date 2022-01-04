using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BC : MonoBehaviour

{

    //要被生成的怪物物件
    public GameObject[] ballprefabs;
    public int ballIndex;

    void Start()

    {

        //執行生成怪物程式碼(每秒一次)

        InvokeRepeating("BallCreater", 0.5f, 1);

    }

    public void BallCreater()

    {

        int BallNum;

        //隨機決定要生成幾個怪物(0-2個隨機)

        BallNum = Random.Range(1, 3);

        //開始生成怪物

        for (int i = 0; i < BallNum; i++)

        {

            //生成球球

            ballIndex = Random.Range(0, ballprefabs.Length);
            Instantiate(ballprefabs[ballIndex], new Vector3(0, Random.Range(-4,3), 0), 
                ballprefabs[ballIndex].transform.rotation);

        }

       
    }
    void Update()
    {

    }
}
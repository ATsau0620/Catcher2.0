using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BC : MonoBehaviour

{

    //要被生成的怪物物件
    public GameObject[] ballprefabs;
    public int ballIndex;
    public PlayerCtr pc;
    public Camera camera;


    [Header("檢查地板尺寸與位移")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    void Start()

    {

        //執行生成怪物程式碼(每秒一次)

        InvokeRepeating("BallCreater", 0.5f, 1);
        pc = GetComponent <PlayerCtr>();
        camera = GetComponent<Camera>();
    }

    public void BallCreater()

    {

        int BallNum;

        //隨機決定要生成幾個球(1-3個隨機)

        BallNum = Random.Range(1, 4);

        //開始生成球

        for (int i = 0; i < BallNum; i++)

        {

            //生成球球

            ballIndex = Random.Range(0, ballprefabs.Length);
            Instantiate(ballprefabs[ballIndex], new Vector3(7, Random.Range(-4,3), 0), 
                ballprefabs[ballIndex].transform.rotation);

        }

       
    }
 
    private void OnDrawGizmos()
    {
        // 1.決定圖示顏色
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // 2.決定繪製圖形
        // transform.position 此物件的世界座標
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }

}
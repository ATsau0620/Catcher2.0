using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BC : MonoBehaviour

{

    //�n�Q�ͦ����Ǫ�����
    public GameObject[] ballprefabs;
    public int ballIndex;

    void Start()

    {

        //����ͦ��Ǫ��{���X(�C��@��)

        InvokeRepeating("BallCreater", 0.5f, 1);

    }

    public void BallCreater()

    {

        int BallNum;

        //�H���M�w�n�ͦ��X�өǪ�(0-2���H��)

        BallNum = Random.Range(1, 3);

        //�}�l�ͦ��Ǫ�

        for (int i = 0; i < BallNum; i++)

        {

            //�ͦ��y�y

            ballIndex = Random.Range(0, ballprefabs.Length);
            Instantiate(ballprefabs[ballIndex], new Vector3(0, Random.Range(-4,3), 0), 
                ballprefabs[ballIndex].transform.rotation);

        }

       
    }
    void Update()
    {

    }
}
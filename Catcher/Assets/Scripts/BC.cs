using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BC : MonoBehaviour

{

    //�n�Q�ͦ����Ǫ�����
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

        //����ͦ��Ǫ��{���X(�C��@��)

        InvokeRepeating("BallCreater", 1, 1);

    }

    public void BallCreater()

    {

        int BallNum;

        //�H���M�w�n�ͦ��X�өǪ�(0-2���H��)

        BallNum = Random.Range(0, 3);

        //�}�l�ͦ��Ǫ�

        for (int i = 0; i < BallNum; i++)

        {

            //�ŧi�ͦ���X�y��

            float y;

            //�����H����X�y��(-6��5����)

            y = Random.Range(-6, 6);

            //�ͦ��Ǫ�

            Instantiate(ball_1, new Vector3(2.8f, y, 0), Quaternion.identity);

        }

    }

}
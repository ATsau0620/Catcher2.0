using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour

{ 
    void Update()

    {

        //�Ǫ�����V�U����

        this.transform.position += new Vector3(0, -0.05f, 0);

    }

    //�p�G�Q�F��I��

    private void OnTriggerEnter2D(Collider2D collision)

    {


        //�p�G�Q���a����

        if (collision.name == "�گ�")

        {
            ScoreCode.Score = ScoreCode.Score + 10;

            //����Ǫ����`

            BallDie();

        }

        

if (collision.name == "Wall_4")

        {

            //�Ǫ�����

            Destroy(this.gameObject);

        }

    }


    //�z���������Ǫ�����

    public void BallDie()

    {

        //�Ǫ�����

        Destroy(this.gameObject);

    }

 
}


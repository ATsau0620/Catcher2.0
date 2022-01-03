using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour

{ 
    void Update()

    {

        //怪物持續向下移動

        this.transform.position += new Vector3(0, -0.05f, 0);

    }

    //如果被東西碰到

    private void OnTriggerEnter2D(Collider2D collision)

    {


        //如果被玩家打到

        if (collision.name == "啊草")

        {
            ScoreCode.Score = ScoreCode.Score + 10;

            //執行怪物死亡

            BallDie();

        }

        

if (collision.name == "Wall_4")

        {

            //怪物消失

            Destroy(this.gameObject);

        }

    }


    //爆炸完畢讓怪物消失

    public void BallDie()

    {

        //怪物消失

        Destroy(this.gameObject);

    }

 
}


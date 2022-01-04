using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour

    
{
    [Header("移動速度"), Range(0, 500)]
    public float speed = 3.5f;

    void Update()

    {


        //球持續向左移動

        this.transform.position += new Vector3(-0.05f,0, 0);

    }

    //如果被東西碰到

    private void OnTriggerEnter2D(Collider2D collision)

    {


        //如果被玩家打到

        if (collision.name == "啊草")

        {
            ScoreCode.Score = ScoreCode.Score + 10;

            //執行球消失

            Destroy(this.gameObject);

        }



    }
 
}


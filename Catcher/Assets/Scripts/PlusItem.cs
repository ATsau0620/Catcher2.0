   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 可收集寶物＋【產生特效】＋【產生音效】
/// </summary>
public class PlusItem : MonoBehaviour
{
    
    [Header("移動速度"), Range(0, 500)]
    public float speed = 3.5f;

    void Update()

    {


        //怪物持續向下移動

        this.transform.position += new Vector3(-0.05f,0, 0);

    }

    //如果被東西碰到

    private void OnTriggerEnter2D(Collider2D collision)

    {

        //Instantiate(pickE, gameObject.transform.position, Quaternion.identity);


        PlayerCtr pc = collision.GetComponent<PlayerCtr>();
        print("碰到的東西是:" + pc);
        pc.ChangeHealth(-1);
        Destroy(gameObject);


        //pc.PlaySound(audioClip);

        //如果被玩家打到

        if (collision.name == "啊草")

        {
       

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
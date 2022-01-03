   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 可收集寶物＋【產生特效】＋【產生音效】
/// </summary>
public class PlusItem : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(pickE, gameObject.transform.position, Quaternion.identity);


        PlayerCtr pc = collision.GetComponent<PlayerCtr>();
        print("碰到的東西是:" + pc);
        pc.ChangeHealth(-1);
        Destroy(gameObject);


        //pc.PlaySound(audioClip);


    }

 
}
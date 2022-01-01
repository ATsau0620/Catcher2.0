   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 可收集寶物＋【產生特效】＋【產生音效】
/// </summary>
public class PlusItem : MonoBehaviour
{
    //public ParticleSystem pickEffectP;
    public GameObject PI;

    //【產生音效 1】
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //pickEffectP.Play();

        //【產生特效】
        Instantiate(PI, gameObject.transform.position, Quaternion.identity);

        PlayerCtr PC = collision.GetComponent<PlayerCtr>();
        print("碰到的東西是：" + PC);
        //PC.ChangeHealth(1);************定義改健康

        //【產生音效 2】
        //PC.PlaySound(audioClip);************定義音效

        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Destroy(gameObject);
    }
}
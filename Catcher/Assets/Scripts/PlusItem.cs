   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �i�����_���ϡi���ͯS�ġj�ϡi���ͭ��ġj
/// </summary>
public class PlusItem : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(pickE, gameObject.transform.position, Quaternion.identity);


        PlayerCtr pc = collision.GetComponent<PlayerCtr>();
        print("�I�쪺�F��O:" + pc);
        pc.ChangeHealth(-1);
        Destroy(gameObject);


        //pc.PlaySound(audioClip);


    }

 
}
   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �i�����_���ϡi���ͯS�ġj�ϡi���ͭ��ġj
/// </summary>
public class PlusItem : MonoBehaviour
{
    //public ParticleSystem pickEffectP;
    public GameObject PI;

    //�i���ͭ��� 1�j
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //pickEffectP.Play();

        //�i���ͯS�ġj
        Instantiate(PI, gameObject.transform.position, Quaternion.identity);

        PlayerCtr PC = collision.GetComponent<PlayerCtr>();
        print("�I�쪺�F��O�G" + PC);
        //PC.ChangeHealth(1);************�w�q�ﰷ�d

        //�i���ͭ��� 2�j
        //PC.PlaySound(audioClip);************�w�q����

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
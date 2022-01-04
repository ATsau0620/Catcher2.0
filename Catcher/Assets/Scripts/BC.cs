using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BC : MonoBehaviour

{

    //�n�Q�ͦ����Ǫ�����
    public GameObject[] ballprefabs;
    public int ballIndex;
    public PlayerCtr pc;

    [Header("�ˬd�a�O�ؤo�P�첾")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    void Start()

    {

        //����ͦ��Ǫ��{���X(�C��@��)

        InvokeRepeating("BallCreater", 0.5f, 1);
        pc = GetComponent <PlayerCtr>();
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
            Instantiate(ballprefabs[ballIndex], new Vector3(pc.transform.position.x + 14, Random.Range(-4,3), 0), 
                ballprefabs[ballIndex].transform.rotation);

        }

       
    }
 
    private void OnDrawGizmos()
    {
        // 1.�M�w�ϥ��C��
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // 2.�M�wø�s�ϧ�
        // transform.position �����󪺥@�ɮy��
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }

}
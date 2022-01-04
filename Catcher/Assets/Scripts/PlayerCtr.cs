using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{public float moveSpeed;


    #region 欄位:公開
    [Header("移動速度"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float jump = 300;
    [Header("檢查地板尺寸與位移")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canJumpLayer;
    [Header("動畫參數 : 走路與跳躍")]
    public string parameterWalk = "開始遊戲";
    public string paramterJump = "跳躍開關";
    [Header("二段跳")]
    private int extraJumps;
    public int extraJumpsValue;
    [Header("檢測")]
    public bool talking;


    int HeartNum = 3;
    public GameObject Heart01;
    public GameObject Heart02;
    public GameObject Heart03;



    //【血量控制1/4】
    [Header("最高血量")]
    public int maxHealth = 5;

    [Header("當前血量"), Range(0, 5)]      //在檢查器內的輔助顯示+可調動 
    //private int currentHelth;           //定義當前血量(不顯示)     
    public int currentHealth;             //定義當前血量(顯示在檢查器)


    #endregion

    #region  欄位:私人
    private Animator ani;
    /// <summary>
    /// 鋼體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;
    private DS ds;
    private BC bc;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        ds = GetComponent<DS>();

        //【血量控制2/4】
        currentHealth = maxHealth;
        print("啊草當前血量為:" + currentHealth);


        //audioSource = GetComponent<AudioSource>

    }

    private void Update()
    {
        CheckGround();
        Jamp();
        
        if(isGround == true)
        {
            extraJumps = extraJumpsValue;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps >0 )
        {
            rig.velocity = Vector2.up * jump;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0 && isGround == true)
        {
            rig.velocity = Vector2.up * jump;
        }

       //if (talking == true)
        {
            //Vector2 PlayerCtr = transform.position;
           // PlayerCtr.x = moveSpeed;
            //moveSpeed = 0;
           // transform.position = PlayerCtr;
        }
       //else if (talking == false)
        
        {
           // Vector2 PlayerCtr = transform.position;
           //PlayerCtr.x = PlayerCtr.x + moveSpeed;
           // transform.position = PlayerCtr;
        }







     }

    private void FixedUpdate()
    {
        //【血量控制4 / 4】
        if (currentHealth == 0)
        {
            Application.LoadLevel("Week12_Health-2_damage");

        }
    }

    //【血量控制3/4】
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
          //  PlaySound(playerHit);
        }

        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        print("啊草 當前血量 :" + currentHealth);


    }


    //將私人欄位顯示在屬性版上
    [SerializeField]


    private bool isGround;
    #endregion


    private void OnDrawGizmos()
    {
        // 1.決定圖示顏色
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // 2.決定繪製圖形
        // transform.position 此物件的世界座標
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }



    private void CheckGround()
    {
        //碰撞資訊 = 2D 物理,覆蓋圖層(中心點,半徑,圖層)
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);

        //print("碰到的物件名稱:" + hit.name);

        isGround = hit;

        ani.SetBool(paramterJump, !isGround);

    }
    private void Jamp()
    {
        //如果角色在地板上 並且 按下指定按鍵
        if (isGround && Input.GetKeyDown(keyjump))
        {
            //剛體,添加推力(二維向量)
            rig.AddForce(new Vector2(0, jump));
        }

    }

    //檢測對話結束與否
    private void CheckTalking()
    {


    }

    //下面這個函式是當玩家碰撞到其他物體時會執行

    private void OnTriggerEnter2D(Collider2D collision)

    {

        //如果碰到球時，扣一顆愛心

        if (collision.tag == "damge")

        {

            //刪除球

            Destroy(collision.gameObject);



            //愛心數量-1

            HeartNum = HeartNum - 1;



            //根據愛心數量，顯示愛心圖案

            if (HeartNum == 2) //如果還有兩顆愛心

            {

                //讓第一顆愛心隱藏

                Heart01.SetActive(false);

            }

            else if (HeartNum == 1) //如果還有一顆愛心

            {

                //讓第二顆愛心隱藏

                Heart02.SetActive(false);

            }

            else if (HeartNum == 0) //如果沒有愛心

            {

                //讓第三顆愛心隱藏

                Heart03.SetActive(false);

            }

        }

    }

}

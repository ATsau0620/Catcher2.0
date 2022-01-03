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


    #endregion

    #region  欄位:私人
    private Animator ani;
    /// <summary>
    /// 鋼體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        extraJumps = extraJumpsValue; 
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

}

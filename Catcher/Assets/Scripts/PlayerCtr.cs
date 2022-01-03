using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{public float moveSpeed;


    #region ���:���}
    [Header("���ʳt��"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("���D����"), Range(0, 1500)]
    public float jump = 300;
    [Header("�ˬd�a�O�ؤo�P�첾")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canJumpLayer;
    [Header("�ʵe�Ѽ� : �����P���D")]
    public string parameterWalk = "�}�l�C��";
    public string paramterJump = "���D�}��";
    [Header("�G�q��")]
    private int extraJumps;
    public int extraJumpsValue;
    [Header("�˴�")]
    public bool talking;

    #endregion

    #region  ���:�p�H
    private Animator ani;
    /// <summary>
    /// ���餸�� Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;
    private DS ds;
    

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        ds = GetComponent<DS>();
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
            //Vector2 PlayerCtr = transform.position;
           // PlayerCtr.x = PlayerCtr.x + moveSpeed;
            //transform.position = PlayerCtr;
        }
     }


    //�N�p�H�����ܦb�ݩʪ��W
    [SerializeField]


    private bool isGround;
    #endregion


    private void OnDrawGizmos()
    {
        // 1.�M�w�ϥ��C��
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // 2.�M�wø�s�ϧ�
        // transform.position �����󪺥@�ɮy��
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }



    private void CheckGround()
    {
        //�I����T = 2D ���z,�л\�ϼh(�����I,�b�|,�ϼh)
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);

        //print("�I�쪺����W��:" + hit.name);

        isGround = hit;

        ani.SetBool(paramterJump, !isGround);

    }
    private void Jamp()
    {
        //�p�G����b�a�O�W �åB ���U���w����
        if (isGround && Input.GetKeyDown(keyjump))
        {
            //����,�K�[���O(�G���V�q)
            rig.AddForce(new Vector2(0, jump));
        }

    }

    //�˴���ܵ����P�_
    private void CheckTalking()
    {


    }


    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    public Transform respawnPosition;
    public ParticleSystem hitParticle;

    public int health
    {
        get { return currentHealth; }
    }

    int currentHealth;
    float invincibleTimer;
    bool isInvincible;

    Animator animator; //�����V?
    Vector2 lookDirection = new Vector2(1, 0);

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ================= HEALTH ====================�����C��?
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }


    // ===================== HEALTH ==================
    public void PMHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            animator.SetTrigger("Hit");
            //audioSource.PlayOneShot(hitSound); ���n��*************

            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (currentHealth == 0)
            Respawn();

        UIHealthBar.Instance.SetValue(currentHealth / (float)maxHealth);
    }

    void Respawn()
    {
        PMHealth(maxHealth);
        transform.position = respawnPosition.position;
    }
}

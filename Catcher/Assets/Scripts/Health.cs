using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
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

    Animator animator; //面對方向?
    Vector2 lookDirection = new Vector2(1, 0);

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // ================= HEALTH ====================結束遊戲?
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
            //audioSource.PlayOneShot(hitSound); 掛聲音*************

            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (currentHealth == 0)
            Respawn();

        //UIHealthBar.Instance.SetValue(currentHealth / (float)maxHealth);************
    }

    void Respawn()
    {
        PMHealth(maxHealth);
        transform.position = respawnPosition.position;
    }
}
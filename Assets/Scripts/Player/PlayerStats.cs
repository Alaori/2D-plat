using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public bool canTakeDamage = true;

    private Animator anim;
    private PlayerMove pMove;
    private PlayerAttackControl pAttackControl;

    private Image healthUI;
    // Start is called before the first frame update
    void Start()
    {
        // health = maxHealth;
        health = PlayerPrefs.GetFloat("HealthKey", maxHealth);
        anim = GetComponentInParent<Animator>();
        pMove = GetComponentInParent<PlayerMove>();
        pAttackControl = GetComponentInParent<PlayerAttackControl>();
        healthUI = GameObject.FindGameObjectWithTag("HealthUI").GetComponent<Image>();
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage == true)
        {
            health = health - damage;
            anim.SetBool("Damage", true);
            pMove.playerControl = false;
            UpdateHealthUI();
            pAttackControl.ResetAttack();
            if (health <= 0)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponentInParent<GetInput>().DisableControls();
                PlayerPrefs.SetFloat("HealthKey", maxHealth);
                GameManager.ManagerRestartLevel();
            }
            StartCoroutine(DamagePrevention());
        }
    }
    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            pMove.playerControl = true;
            canTakeDamage = true;
            anim.SetBool("Damage", false);
        }
        else if (health <=0)
        {    
            anim.SetBool("Death", true);
        }
    }
    public void UpdateHealthUI()
    {
        healthUI.fillAmount = health /maxHealth;
    }
    public void GainHealth(float healAmount)
    {
        health += healAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthUI();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("HealthKey");
    }
}


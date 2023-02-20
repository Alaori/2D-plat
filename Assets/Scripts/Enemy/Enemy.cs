using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    protected Rigidbody2D rb2D;
    protected Animator anim;

    // Start is called before the first frame update

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {

        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        HurtAnim();
        if (health <= 0)
        {
            DeathAnim();
        }
    }

    public virtual void HurtAnim()
    { 
    
    }
    public virtual void DeathAnim()
    {

    }

}

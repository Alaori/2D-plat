using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{
    public float speed;
    private int direction = -1;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask layerCheck;

    private bool groundDetected;
    private bool wallDetected;

    public float radius;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
 //   void Update()
  //  {
        
   // }

    private void FixedUpdate()
    {
        Flip();
        rb2D.velocity = new Vector2(direction * speed, rb2D.velocity.y);
       
    }

    private void Flip()
    {
       groundDetected = Physics2D.OverlapCircle(groundCheck.position, radius, layerCheck);
       wallDetected = Physics2D.OverlapCircle(wallCheck.position, radius, layerCheck);
        
        if ((wallDetected==true) ||( groundDetected == false))
            {
                direction *= -1;
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
                    Gizmos.DrawWireSphere(wallCheck.position, radius);

    }

    public override void HurtAnim()
    {
        anim.SetTrigger("Hurt");
    }
    public override void DeathAnim()
    {
        anim.SetTrigger("Death");
        speed = 0;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponentInChildren<PolygonCollider2D>().enabled = false;
        rb2D.gravityScale = 0;
    }
}

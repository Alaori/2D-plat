using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private int direction = 1;
    public float jumpForce; 
    private Animator anim;

    public float rayLength;
    public LayerMask groundLayer;
    public Transform rightPoint;
    public Transform leftPoint;
    public bool grounded = true;
   // private bool doubleJump = true;
    public int totalJumps = 2;
    private int resetJumpNumber;
    public bool knockback = false;
    public bool playerControl = true;

    private GetInput getInput;
    private Rigidbody2D rb2D;
    public bool onLadder;
    public float climbSpeed;
    public float climbSpeedHorizontal;
    private float climbGravity;

    // Start is called before the first frame update
    void Start()
    {
        getInput = GetComponent<GetInput>();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        resetJumpNumber = totalJumps;
        climbGravity = rb2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorValue();
    }
    private void FixedUpdate()
    {
        CheckGrounded();
        if ((knockback == true)||(playerControl ==false))
        {
            return;
        }
        Move();
        PlayerJump();
    }

      private void Move()
    {
        Flip();
        rb2D.velocity = new Vector2(speed * getInput.valueX, rb2D.velocity.y);
        if (onLadder)
        {
            rb2D.gravityScale = 0;
            rb2D.velocity = new Vector2(climbSpeedHorizontal * getInput.valueX, climbSpeed * getInput.valueY);
            if(rb2D.velocity.y ==0)
            {

                anim.enabled = false;
            }
            else
            {

                anim.enabled = true;
            }
        }
    }
    public void ExitLadder()
    {
        rb2D.gravityScale = climbGravity;
        onLadder = false;
        anim.enabled = true;
    }
    private void Flip()
    {
        if (getInput.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }
 
    private void SetAnimatorValue()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        anim.SetFloat("Vspeed", rb2D.velocity.y);
        anim.SetBool("Grounded", grounded);

       
        anim.SetBool("Climb", onLadder);
    }
    private void PlayerJump()
    {
        if (getInput.jumpInupt == true)
        {
            if ((grounded == true)||(onLadder==true))
            {
                ExitLadder();
                rb2D.velocity = new Vector2(getInput.valueX * speed, jumpForce);
             //   doubleJump = true;
            }
            else if (totalJumps>0)
            {
                ExitLadder();
                rb2D.velocity = new Vector2(getInput.valueX * speed, jumpForce);
               // doubleJump = false;
                totalJumps -= 1;
              

            }
        }
        getInput.jumpInupt = false;
    }
    private void CheckGrounded()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightCheckHit = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);
        if ((leftCheckHit == true)||(rightCheckHit == true))
        {
            Debug.Log("Grounded is ="  +grounded);
            grounded = true;
           // doubleJump = false;
            totalJumps = resetJumpNumber;
        }
        else
        {
            grounded = false;
        }
    }
    public IEnumerator KnockBack(float forceX, float forceY, float duration, Transform player)
    {
        int knockbackDirection;
        if (transform.position.x < player.position.x)
        {
            knockbackDirection = -1;
        }
        else
        {
            knockbackDirection = 1;
        }
        knockback = true;
        rb2D.velocity = Vector2.zero;
        Vector2 force = new Vector2(knockbackDirection * forceX, forceY);
        rb2D.AddForce(force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        knockback = false;
        rb2D.velocity = Vector2.zero;

    }
}

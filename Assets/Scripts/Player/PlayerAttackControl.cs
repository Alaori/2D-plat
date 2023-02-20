using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl : MonoBehaviour
{
    private PlayerMove pMove;
    private GetInput getInput;
    private Animator anim;
    public PolygonCollider2D polyCollider2D;
    public bool attackStart = false;
    public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        pMove = GetComponent<PlayerMove>();
        getInput = GetComponent<GetInput>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (getInput.tryAttack)
        {
            if((attackStart == true)||(pMove.playerControl == false)||(pMove.knockback == true)||(pMove.onLadder == true))
            {
                return;
            }    
            anim.SetBool("Attack", true);
            
            attackStart = true;
        }
        
    }
    public void ResetAttack()
    {
        anim.SetBool("Attack", false) ;
        getInput.tryAttack = false;
        attackStart = false;
        polyCollider2D.enabled = false;
        source.Stop();
    }

    public void ActivateAttack()
    {
        polyCollider2D.enabled = true;
        source.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAttack : EnemyAttack
{
    PlayerMove pMove;
    public float forceX;
    public float forceY;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void SpecialAttack()
    {
        pMove =pStats.GetComponentInParent<PlayerMove>();
        StartCoroutine(pMove.KnockBack(forceX,forceY,duration, transform.parent));
    }
}

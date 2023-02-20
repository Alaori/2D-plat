using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerStats>().TakeDamage(damage);
        PlayerMove pMove = collision.GetComponentInParent<PlayerMove>();
        StartCoroutine(pMove.KnockBack(forceX,forceY,duration,transform));
    }

}

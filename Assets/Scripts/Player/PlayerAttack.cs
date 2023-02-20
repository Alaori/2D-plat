using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage;
    private int enemyLayer;
    private int destructibleLayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        destructibleLayer = LayerMask.NameToLayer("Destructible");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            collision.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        if (collision.gameObject.layer == destructibleLayer)
        {
            collision.GetComponent<DestructibleObject>().TakeHit();

        }
    }
}

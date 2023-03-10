using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount;
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
        if(collision.CompareTag("Player"))
        {
            
            PlayerStats pStats = collision.GetComponentInChildren<PlayerStats>();
            if (pStats.health == pStats.maxHealth)
            {
                return;
            }
            pStats.GainHealth(healAmount);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemControl : MonoBehaviour
{
    public GameObject gemParticle;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.AddGem(this);   
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Collectibles>().GemCollected();
            GetComponent<AudioSource>().Play(); 
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Instantiate(gemParticle, transform.position, transform.rotation);
            GameManager.RemoveGem(this);
        }
    }
}

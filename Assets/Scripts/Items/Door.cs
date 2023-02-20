using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    public int loadLevel;
    public Sprite unlockedDoorSprite;
    private BoxCollider2D boxCollider2D;
       // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
        GameManager.SetDoor(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxCollider2D.enabled = false;
            collision.GetComponent<GetInput>().DisableControls();
            PlayerStats pStats = collision.GetComponentInChildren<PlayerStats>();
            PlayerPrefs.SetFloat("HealthKey", pStats.health);
            Collectibles collect = collision.GetComponent<Collectibles>();
            PlayerPrefs.SetInt("GemNumber", collect.gemNumber);
            GameManager.ManagerLoadLevel(loadLevel);
        }
    }
    public void UnlockDoor()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedDoorSprite;
        boxCollider2D.enabled = true;

    }
}

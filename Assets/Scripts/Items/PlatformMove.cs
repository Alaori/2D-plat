using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed;
    private int index;
    public int startingPoint;
    public Transform[] points;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,points[index].position)<0.02f)
        {
            index++;
            if (index == points.Length)
            {
                index = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, points[index].position,speed*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (transform.position.y < collision.transform.position.y - 0.8f)
            {
                collision.transform.SetParent(transform);
                Animator characterAnimator = collision.gameObject.GetComponent<Animator>();
                characterAnimator.SetBool("Grounded", true);
                characterAnimator.Play("Idle");
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private GetInput getInput;
    private PlayerMove pMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        getInput = collision.GetComponent<GetInput>();
        pMove = collision.GetComponent<PlayerMove>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(getInput.startClimb)
        {
            pMove.onLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pMove.ExitLadder();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

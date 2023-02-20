using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : DestructibleObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnHit()
    {
        anim.SetTrigger("Hit");
    }
    public override void OnDestroy()
    {
        anim.SetTrigger("Destroy");
   
    }
}

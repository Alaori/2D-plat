using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public int hitsToDestroy;
    protected Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeHit()
    {
        hitsToDestroy -= 1;
        OnHit();
        if(hitsToDestroy <=0)
        {
            OnDestroy();
     
        }
    }

    public void CleanUp()
    {
        Destroy(gameObject);
    }
    public virtual void OnHit()
    { }
    public virtual void OnDestroy()
    { }


}

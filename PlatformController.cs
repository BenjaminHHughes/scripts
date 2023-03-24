using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform posA, posB;
    public int Speed;
    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
          targetPos = posB.position;  //sets the default target to posB
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,posA.position)<.1f) targetPos=posB.position;  
        //switches the target position if it gets close to one of them
        if(Vector2.Distance(transform.position,posB.position)<.1f) targetPos=posA.position;     

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime); //moves the platform beween two defined points at a set speed
    }
}

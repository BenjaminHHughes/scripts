using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5; //sets the paddle movespeed
    public float maxX = 8f;

    float movementHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if((movementHorizontal>0 && transform.position.x<maxX) || (movementHorizontal<0 && transform.position.x>-maxX)) //sets a max distance that stops the paddle from going off screen
        {
        transform.position +=Vector3.right * movementHorizontal * speed * Time.deltaTime; //moves the paddle using the arrow keys or wasd
        }
    }
}

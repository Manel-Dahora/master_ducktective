using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This is the player speed, set to be adjustable in the unity interface
    public float speed;
    
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Here I'm getting the raw axis for control 
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //This moves the player while normalizing the speed in the diagonal space
        Vector3 moveDir = new Vector3(h, 0, v);
        moveDir.Normalize();
        moveDir = transform.TransformDirection(moveDir);

        transform.Translate(moveDir * speed * Time.deltaTime);
        // This makes the player face the direction it's moving towards

    }
}

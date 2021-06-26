using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    private Rigidbody rb;

    public float shotForce = 50f;
    public float lifeTime = 2f;
    public int damage = 10;

    public GameObject explosionPrefab; //This is your explosion object that you spawn in

    void Start()
    {
        //You can use GetComponent to get any componnet if it exists on the gameobject
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false; //Use this if you want to turn off gravity on the projectile
        rb.AddForce(transform.forward * shotForce, ForceMode.VelocityChange); //This is how you add a force to your rigidbody

        Destroy(gameObject, lifeTime); //You can add a float as a second argument to tell unity to destroy the gameobject after x amount of seconds
    }

    //I'm switching from OnTriggerEnter to OnCollisionEnter
    private void OnTriggerEnter(Collider other)
    {
        //Your original issue was that you were checking to see if the player existed
        //so I changed it to if the projectile has collided with the player
        if (other.transform.CompareTag("Player"))
        {
            
                other.gameObject.GetComponent<ControlPlayer>().Dano(damage);
                
            
        }

        //So, You were using a GameObject as the position for explosion, so I changed it to where the projectile is when it collided with something
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        DestroyImmediate(explosionPrefab.gameObject, true);
        //This will destroy the gameobject if it collides with something
        Destroy(gameObject);
    }
}

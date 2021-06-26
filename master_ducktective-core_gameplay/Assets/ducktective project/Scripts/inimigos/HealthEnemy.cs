using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public bool immortal;
    public int playerdamage = 10;


    // Update is called once per frame


     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer"))
        {
            Dano();
        }
    }
   public void Dano()
    {
        if(health > 0)
        {
            if (!immortal)
            {
                health = health - playerdamage;
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                StartCoroutine(BossPisca());
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    IEnumerator BossPisca()
    {
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        immortal = false;

    }
}

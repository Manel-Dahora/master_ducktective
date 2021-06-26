using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed = 8f;
    public Rigidbody rb;
    public float lifeDuration = 2f;
    private float lifeTimer;
    public GameObject Explosion;
    public GameObject ExplosionInitiate;
    void Start()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        // faz a bala se mover
        transform.Translate(transform.forward * speed * Time.deltaTime);
        

        //faz a bala desaparecer em 2f
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }


    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //explode, aqui codigo do que a bala faz com o inimigo 
            Instantiate(Explosion, ExplosionInitiate.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            DestroyImmediate(Explosion.gameObject,true);
            
        }
        else if(other.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<HealthEnemy>().Dano();
            Instantiate(Explosion, ExplosionInitiate.transform.position, Quaternion.identity);
        }
        else
        {
            // se o objeto nao ter a tag "enemy", ele destroy a bala em colisão
            Destroy(gameObject);
        }
    }
}

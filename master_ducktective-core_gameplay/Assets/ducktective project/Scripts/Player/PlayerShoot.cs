using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Projectile;
    bool control = true;



    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire") && control == true)
        {
            control = false;
            GameObject ShootyMcShot = Instantiate(Projectile, transform.position, Projectile.transform.rotation);
            ShootyMcShot.transform.position = transform.position;
            StartCoroutine(TempoBala());
        }
    }
    IEnumerator TempoBala()
    {
        yield return new WaitForSeconds(2);
        control = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float shotSpeed;
    public int shotCount = 30;
    private float shotInterval;



    private void Start()

    {

    }

    void Update()
    {

        if (Input.GetKey("e"))
        {
        
            shotInterval += 1;

            if (shotInterval % 5 == 0 && shotCount > 0)
            {
                shotCount -= 1;
               
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);

              

                GetComponent<AudioSource>().Play();



            }

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 30;
            GetComponent<AudioSource>().Play();
        }

    }
}
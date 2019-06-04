using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float shotSpeed;
    public int shotCount = 30;
    private float shotInterval;
    private RaycastHit hit;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    private AudioSource audioSource;
    private float waitingTime = 1.0f ;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        if (Input.GetKey("e"))
        {
            waitingTime -= 0.1f; 
             
            shotInterval += 1;

            if (waitingTime <= 0 && shotCount > 0 && shotInterval %  5 == 0) 
            {
                shotCount -= 1;

               GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y, 0));
               Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
               bulletRb.AddForce(transform.forward * shotSpeed);

               audioSource.PlayOneShot(shotSound);
            }

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 30;
           audioSource.PlayOneShot(reloadSound);
        }

        if (Input.GetKeyUp("e"))
        {
            waitingTime = 1.0f;
        }

    }
}
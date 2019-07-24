using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetShot : MonoBehaviour
{
    public int ShotTime;
    private float shotInterval;
    public GameObject bulletPrefab;
    public float shotSpeed;
    public AudioClip shotSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Shooting()
    {

            shotInterval += 1;
           
            if (shotInterval % 1 == 0)
            {
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);
                audioSource.PlayOneShot(shotSound);
            }
        
     }
        void Start()
          {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Loop());
          }
    private IEnumerator Loop()
    {
        // ループ
        while (true)
        {
           
            yield return new WaitForSeconds(ShotTime+ Random.Range(1f, -1f));
            Shooting();

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "tama")
        {
            ShotTime = 10;
        }
    }
    // Update is called once per frame
    void Update()
     {



     }


    }


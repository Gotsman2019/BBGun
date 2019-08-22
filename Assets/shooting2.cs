using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting2 : MonoBehaviour
{
    private GunShock gunShock;
    public SubCameraTransformChange2 subCameraTransformChange2;
    private bool isShotButtonDown = false;
    private GameObject bazooka;
    private bool isReloadButtonDown = false;
    private int ReloadCount = 0;
    public GameObject bulletPrefab;

    public GameObject bulletPrefab2;

    public float shotSpeed;
    public int shotCount = 5;
    private float shotInterval;
    private RaycastHit hit;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    private AudioSource audioSource;
    public AudioClip Sound1;
    private float waitingTime = 0f;
    private bool reloadcheck;
    public void GetMyReloadButtonDown()
    {

        this.isReloadButtonDown = true;
        ReloadCount = 0;
    }
    public void GetMyReloadUp()
    {
        this.isReloadButtonDown = false;
        ReloadCount = 1;
    }

    public void GetMyshotButtonDown()
    {
      //  audioSource.PlayOneShot(Sound1);
        this.isShotButtonDown = true;
    }
    public void GetMyshotButtonUp()
    {
        this.isShotButtonDown = false;
    }



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        reloadcheck = false;
        bazooka = GameObject.Find("bazooka");
        subCameraTransformChange2 = bazooka.GetComponent<SubCameraTransformChange2>();


}

void Update()
    {

        if (Input.GetKey("e") || (isShotButtonDown))
        {

            waitingTime -= 0.5f;
            reloadcheck = false;
            shotInterval += 1;

            if (waitingTime <= 0 && shotCount > 0 && shotInterval % 30 == 0)
            {
                shotCount -= 1;

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);

                subCameraTransformChange2.Shock();
                audioSource.PlayOneShot(shotSound);
                if (gunShock)
                {
                    gunShock.GunyureData();
                    gunShock.Gunyure();
                }
                GameObject bullet2 = (GameObject)Instantiate(bulletPrefab2, transform.position, Quaternion.Euler(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y, 0.5f));
               
                 Rigidbody bulletRb2 = bullet2.GetComponent<Rigidbody>();
                bulletRb2.AddForce(transform.forward * shotSpeed);



                if (shotCount <= 0)
                    ReloadCount = 0;
            }
        }

        if (Input.GetKey(KeyCode.R) || (isReloadButtonDown))
        {

            if (ReloadCount == 0)
            {
                if (!reloadcheck)
                {
                    shotCount = 5;
                    audioSource.PlayOneShot(reloadSound);
                    reloadcheck = true;
                }

            }
        }

        if (Input.GetKeyUp("e"))
        {
            waitingTime = 1.0f;
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting2 : MonoBehaviour
{
    public SubCameraTransformChange2 subCameraTransformChange2;
    private bool isShotButtonDown = false;
    private GameObject bazooka;
    private bool isReloadButtonDown = false;
    private int ReloadCount = 0;
    public GameObject bulletPrefab;
    public float shotSpeed;
    public int shotCount = 5;
    private float shotInterval;
    private RaycastHit hit;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    private AudioSource audioSource;
    private float waitingTime = 1.0f;
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

            waitingTime -= 0.1f;
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
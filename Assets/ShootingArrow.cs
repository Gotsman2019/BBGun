﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingArrow : MonoBehaviour
{
    public MainCameraShock mainCameraShock;
    private GameObject Guns;
    private GameObject Spine;
    private GunShock gunShock;


    private GameObject MainCamera;
    private GameObject bullet;
    private bool isShotButtonDown = false;
    private Animator animator;
    private bool isReloadButtonDown = false;
    private int ReloadCount = 0;
    public GameObject bulletPrefab;
    public float shotSpeed;
    public int shotCount = 50;
    private float shotInterval;
    private RaycastHit hit;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    public AudioClip Sound1;
    private AudioSource audioSource;
    private float waitingTime = 1.0f;
    private bool reloadcheck;
    private bool Shot = false ;
    private Transform transformya;

    

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

    public void Shutsugen() 
    {

        bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
    }


    public void GetMyshotButtonUp()//ボタンが離されると打つ
    {
        this.isShotButtonDown = false;

        if (Input.GetKey("e") || (!isShotButtonDown))
        {

         // waitingTime -= 0.2f;
            reloadcheck = false;
            //shotInterval += 1;

            //if (waitingTime <= 0 && shotCount > 0 )
            //{

                shotCount -= 1;

               Shutsugen();
               // GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);
                


                audioSource.PlayOneShot(shotSound);

            this.isShotButtonDown = true;




                if (shotCount <= 0)
                    ReloadCount = 0;
            //}


            //animator.SetBool("shooting", true);
        }
        //  animator.SetBool("shooting", false);

    }

    //public void ShotArrow()
    //{
    // //   animator.SetBool("shooting", true);
    //    Shot = true;

    //}
    private void Start()
    {
        Shot = false;
       
        audioSource = GetComponent<AudioSource>();
        reloadcheck = false;
        MainCamera = GameObject.Find("FirstPersonCharacter");
        mainCameraShock = MainCamera.GetComponent<MainCameraShock>();

        Guns = GameObject.Find("shooting");
        animator = Guns.GetComponent<Animator>();
        gunShock = Guns.GetComponent<GunShock>();


    }

    void Update()
    {

        //if (Input.GetKey("e") || (isShotButtonDown))
        //{

            //waitingTime -= 0.2f;
            //reloadcheck = false;
            //shotInterval += 1;

            //if (waitingTime <= 0 && shotCount > 0 && shotInterval % 9 == 0)
            //{
               
            //    shotCount -= 1;

            //    GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.localEulerAngles.x, transform.parent.localEulerAngles.y, 0));
            //    Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            //    bulletRb.AddForce(transform.forward * shotSpeed);

            //    // mainCameraShock.ShockMain();

            //    audioSource.PlayOneShot(shotSound);

            //    //gunShock.MoveGunShock();




            //    if (shotCount <= 0)
            //        ReloadCount = 0;
            //}
        //}

        if (Input.GetKey(KeyCode.R) || (isReloadButtonDown))
        {

            if (ReloadCount == 0)
            {
                if (!reloadcheck)
                {
                    shotCount = 50;
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